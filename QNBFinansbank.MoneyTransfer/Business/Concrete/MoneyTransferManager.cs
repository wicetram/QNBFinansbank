using Newtonsoft.Json;
using QNBFinansbank.MoneyTransfer.Business.Abstract;
using QNBFinansbank.MoneyTransfer.Constant;
using QNBFinansbank.MoneyTransfer.Entity.Request.Check;
using QNBFinansbank.MoneyTransfer.Entity.Request.Transfer;
using QNBFinansbank.MoneyTransfer.Entity.Response.Check;
using QNBFinansbank.MoneyTransfer.Entity.Response.Transfer;
using QNBFinansbank.MoneyTransfer.Utility.ResponseHandler;
using QNBFinansbank.MoneyTransfer.Utility.Serialization;
using RestSharp;

namespace QNBFinansbank.MoneyTransfer.Business.Concrete
{
    public class MoneyTransferManager : IMoneyTransferService
    {
        /// <summary>
        /// Yapılan para transfer işlemlerini kontrol eden metottur. 
        /// Gönderilen kontrol talebiyle bir POST isteği yapar ve yanıtı DTO formatında döndürür.
        /// </summary>
        /// <param name="checkTransferRequestDto">
        /// Para transfer kontrol isteğini temsil eden DTO. Hesap bilgileri, tarih aralığı ve diğer gerekli bilgileri içerir.
        /// </param>
        /// <returns>
        /// Para transfer kontrol işleminin sonucunu ve ilgili yanıt verilerini içeren bir <see cref="CheckTransferResponseDto"/> nesnesi döner.
        /// İşlem başarılıysa, <see cref="CheckTransferResponseDataDto"/> nesnesi doldurulmuş olarak döner.
        /// İşlem başarısızsa veya bir hata oluşursa, ilgili hata mesajını içeren bir sonuç döner.
        /// </returns>
        /// <remarks>
        /// Bu metot, transfer kontrol isteği için bir HTTP POST isteği yapar ve yanıtın içeriğini analiz eder.
        /// Yanıt başarılı değilse, hata detayı içeren bir sonuç döner.
        /// Yanıt başarılıysa, yanıt string'ini DTO'ya parse eder ve sonuç olarak döndürür.
        /// Eğer metot sırasında bir hata oluşursa, hata mesajını içeren bir sonuç döner.
        /// </remarks>
        public CheckTransferResponseDto Check(CheckTransferRequestDto checkTransferRequestDto)
        {
            try
            {
                var requestDto = new CheckTransferRequestDataDto
                {
                    VersionNumber = "1",
                    AccountNumber = checkTransferRequestDto?.Account?.AccountCode?.Substring(17, 9),
                    StartDate = checkTransferRequestDto?.StartDate.ToString("yyyyMMdd"),
                    EndDate = checkTransferRequestDto?.EndDate.ToString("yyyyMMdd"),
                    FirmCode = checkTransferRequestDto?.Account?.FirmCode,
                    FirmReferansNumber = checkTransferRequestDto?.RequestId,
                    PackedId = ""
                };

                var request = new RestRequest { Method = Method.Post };
                request.AddHeader("x-servicename", $"{checkTransferRequestDto?.Account?.Action}");
                request.AddHeader("x-username", $"{checkTransferRequestDto?.Account?.Username}");
                request.AddHeader("x-password", $"{checkTransferRequestDto?.Account?.Password}");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(requestDto), ParameterType.RequestBody);

                var client = new RestClient($"{checkTransferRequestDto?.Account?.BaseUrl}");
                var response = client.Execute(request);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    return new CheckTransferResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"Para transfer kontrol işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.Check, requestDto, response?.Content)
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = JsonConvert.DeserializeObject<CheckTransferResponseDataDto>(response.Content);
                if (result == null)
                {
                    return new CheckTransferResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"Para transfer kontrol işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.Check, requestDto, response?.Content)
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result?.TableList?.FirstOrDefault()?.ResultCode != Results.Success)
                {
                    return new CheckTransferResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"Para transfer kontrol işlemi başarısız. Hata detayı: {result?.TableList?.FirstOrDefault()?.ResultCode} | {result?.TableList?.FirstOrDefault()?.ResultDescription}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.Check, requestDto, response?.Content)
                    };
                }

                return new CheckTransferResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"Para transfer işlemi başarılı."),
                    CheckTransferResponse = result,
                    ApiLog = SerializerHelper.ProcessData(MethodNames.Check, requestDto, response?.Content)
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new CheckTransferResponseDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"Para transfer kontrol işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// IBAN kullanarak para transferi işlemini gerçekleştiren metottur. 
        /// Gönderilen transfer talebiyle bir POST isteği yapar ve yanıtı DTO formatında döndürür.
        /// </summary>
        /// <param name="transferRequestDto">
        /// IBAN para transferi isteğini temsil eden DTO. Gönderen ve alıcı bilgileri, transfer miktarı gibi gerekli bilgileri içerir.
        /// </param>
        /// <returns>
        /// IBAN para transferi işleminin sonucunu ve ilgili yanıt verilerini içeren bir <see cref="TransferResponseDto"/> nesnesi döner.
        /// İşlem başarılıysa, <see cref="TransferResponseDataDto"/> nesnesi doldurulmuş olarak döner.
        /// İşlem başarısızsa veya bir hata oluşursa, ilgili hata mesajını içeren bir sonuç döner.
        /// </returns>
        /// <remarks>
        /// Bu metot, IBAN para transferi isteği için bir HTTP POST isteği yapar ve yanıtın içeriğini analiz eder.
        /// Yanıt başarılı değilse, hata detayı içeren bir sonuç döner.
        /// Yanıt başarılıysa, yanıt string'ini DTO'ya parse eder ve sonuç olarak döndürür.
        /// Eğer metot sırasında bir hata oluşursa, hata mesajını içeren bir sonuç döner.
        /// </remarks>
        public TransferResponseDto CreditCardMoneyTransfer(TransferRequestDto transferRequestDto)
        {
            try
            {
                var requestDto = new TransferRequestDataDto
                {
                    AccountNumber = transferRequestDto?.Account?.AccountCode,
                    Amount = transferRequestDto?.Transfer?.Amount,
                    Currency = transferRequestDto?.Account?.Currency,
                    Description = transferRequestDto?.Transfer?.Description,
                    FirmCode = transferRequestDto?.Account?.FirmCode,
                    FirmReferansNumber = transferRequestDto?.Transfer?.RequestId,
                    PackedId = transferRequestDto?.Transfer?.RequestId,
                    ReceiverName = transferRequestDto?.Receiver?.FullName,
                    CreditCardNumber = transferRequestDto?.Receiver?.Iban,
                    TargetBankCode = transferRequestDto?.Receiver?.ReceiverBankCode,
                    TargetBranchCode = "", //karta transferde şube kodu zorunlu
                    SuperiorName = transferRequestDto?.Sender?.NameSurname,
                    VersionNumber = "1"
                };

                var request = new RestRequest { Method = Method.Post };
                request.AddHeader("x-servicename", $"{transferRequestDto?.Account?.Action}");
                request.AddHeader("x-username", $"{transferRequestDto?.Account?.Username}");
                request.AddHeader("x-password", $"{transferRequestDto?.Account?.Password}");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(requestDto), ParameterType.RequestBody);

                var client = new RestClient($"{transferRequestDto?.Account?.BaseUrl}");
                var response = client.Execute(request);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    return new TransferResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"Para transfer işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.CreditCardMoneyTransfer, requestDto, response?.Content)
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = JsonConvert.DeserializeObject<TransferResponseDataDto>(response.Content);
                if (result == null)
                {
                    return new TransferResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"Para transfer işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.CreditCardMoneyTransfer, requestDto, response?.Content)
                    };
                }

                string? resultDescription = result.ResultDescription;
                if (!string.IsNullOrEmpty(resultDescription) && resultDescription == "��lem Ba�ar�yla Ger�ekle�mi�tir.")
                {
                    result.ResultDescription = "İşlem Başarıyla Gerçekleşmiştir.";
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.ResultCode != Results.Success)
                {
                    return new TransferResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"Para transfer işlemi başarısız. Hata detayı: {result?.ResultCode} | {result?.ResultDescription}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.CreditCardMoneyTransfer, requestDto, response?.Content)
                    };
                }

                return new TransferResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"Para transfer işlemi başarılı."),
                    Transfer = result,
                    ApiLog = SerializerHelper.ProcessData(MethodNames.CreditCardMoneyTransfer, requestDto, response?.Content)
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new TransferResponseDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"Para transfer işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// Kredi kartı kullanarak para transferi işlemini gerçekleştiren metottur. 
        /// Gönderilen transfer talebiyle bir POST isteği yapar ve yanıtı DTO formatında döndürür.
        /// </summary>
        /// <param name="transferRequestDto">
        /// Kredi kartı para transferi isteğini temsil eden DTO. Gönderen ve alıcı bilgileri, transfer miktarı gibi gerekli bilgileri içerir.
        /// </param>
        /// <returns>
        /// Kredi kartı para transferi işleminin sonucunu ve ilgili yanıt verilerini içeren bir <see cref="TransferResponseDto"/> nesnesi döner.
        /// İşlem başarılıysa, <see cref="TransferResponseDataDto"/> nesnesi doldurulmuş olarak döner.
        /// İşlem başarısızsa veya bir hata oluşursa, ilgili hata mesajını içeren bir sonuç döner.
        /// </returns>
        /// <remarks>
        /// Bu metot, kredi kartı para transferi isteği için bir HTTP POST isteği yapar ve yanıtın içeriğini analiz eder.
        /// Yanıt başarılı değilse, hata detayı içeren bir sonuç döner.
        /// Yanıt başarılıysa, yanıt string'ini DTO'ya parse eder ve sonuç olarak döndürür.
        /// Eğer metot sırasında bir hata oluşursa, hata mesajını içeren bir sonuç döner.
        /// </remarks>
        public TransferResponseDto IBANMoneyTransfer(TransferRequestDto transferRequestDto)
        {
            try
            {
                var requestDto = new TransferRequestDataDto
                {
                    AccountNumber = transferRequestDto?.Account?.AccountCode?.Substring(17, 9),
                    Amount = transferRequestDto?.Transfer?.Amount,
                    Currency = transferRequestDto?.Account?.Currency,
                    Description = transferRequestDto?.Transfer?.Description,
                    FirmCode = transferRequestDto?.Account?.FirmCode,
                    FirmReferansNumber = transferRequestDto?.Transfer?.RequestId,
                    PackedId = transferRequestDto?.Transfer?.RequestId,
                    ReceiverName = transferRequestDto?.Receiver?.FullName,
                    TargetAccount = transferRequestDto?.Receiver?.Iban,
                    SuperiorName = transferRequestDto?.Sender?.NameSurname,
                    VersionNumber = "1"
                };

                var request = new RestRequest { Method = Method.Post };
                request.AddHeader("x-servicename", $"{transferRequestDto?.Account?.Action}");
                request.AddHeader("x-username", $"{transferRequestDto?.Account?.Username}");
                request.AddHeader("x-password", $"{transferRequestDto?.Account?.Password}");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(requestDto), ParameterType.RequestBody);

                var client = new RestClient($"{transferRequestDto?.Account?.BaseUrl}");
                var response = client.Execute(request);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    return new TransferResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"Para transfer işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.IBANMoneyTransfer, requestDto, response?.Content)
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = JsonConvert.DeserializeObject<TransferResponseDataDto>(response.Content);
                if (result == null)
                {
                    return new TransferResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"Para transfer işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.IBANMoneyTransfer, requestDto, response?.Content)
                    };
                }

                string? resultDescription = result.ResultDescription;
                if (!string.IsNullOrEmpty(resultDescription) && resultDescription == "��lem Ba�ar�yla Ger�ekle�mi�tir.")
                {
                    result.ResultDescription = "İşlem Başarıyla Gerçekleşmiştir.";
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.ResultCode != Results.Success)
                {
                    return new TransferResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"Para transfer işlemi başarısız. Hata detayı: {result?.ResultCode} | {result?.ResultDescription}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.IBANMoneyTransfer, requestDto, response?.Content)
                    };
                }

                return new TransferResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"Para transfer işlemi başarılı."),
                    Transfer = result,
                    ApiLog = SerializerHelper.ProcessData(MethodNames.IBANMoneyTransfer, requestDto, response?.Content)
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new TransferResponseDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"Para transfer işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }
    }
}
