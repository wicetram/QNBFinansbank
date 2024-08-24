using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QNBFinansbank.CashManagement.Business.Abstract;
using QNBFinansbank.CashManagement.Constant;
using QNBFinansbank.CashManagement.Entity.Request.GetTransaction;
using QNBFinansbank.CashManagement.Entity.Response.GetTransaction;
using QNBFinansbank.CashManagement.Utility.ResponseHandlers;
using QNBFinansbank.CashManagement.Utility.Serialization;
using RestSharp;
using System.Xml.Linq;

namespace QNBFinansbank.CashManagement.Business.Concrete
{
    public class CashManagementManager : ICashManagementService
    {
        /// <summary>
        /// Hesap hareketlerini getiren metottur.
        /// Gönderilen işlem talebiyle bir POST isteği yapar ve yanıtı DTO formatında döndürür.
        /// </summary>
        /// <param name="transactionRequestDto">
        /// Hesap hareketleri sorgulama isteğini temsil eden DTO. Hesap bilgileri, tarih aralığı ve diğer gerekli bilgileri içerir.
        /// </param>
        /// <returns>
        /// Hesap hareketleri işleminin sonucunu ve ilgili yanıt verilerini içeren bir <see cref="GetTransactionResponseDto"/> nesnesi döner.
        /// İşlem başarılıysa, <see cref="GetTransactionResponseDataDto"/> nesnesi doldurulmuş olarak döner.
        /// İşlem başarısızsa veya bir hata oluşursa, ilgili hata mesajını içeren bir sonuç döner.
        /// </returns>
        /// <remarks>
        /// Bu metot, hesap hareketleri sorgulama isteği için bir HTTP POST isteği yapar ve yanıtın içeriğini analiz eder.
        /// Yanıt başarılı değilse, hata detayı içeren bir sonuç döner.
        /// Yanıt başarılıysa, yanıt string'ini DTO'ya parse eder ve sonuç olarak döndürür.
        /// Eğer metot sırasında bir hata oluşursa, hata mesajını içeren bir sonuç döner.
        /// </remarks>
        public GetTransactionResponseDto GetTransaction(GetTransactionRequestDto transactionRequestDto)
        {
            try
            {
                var dto = new GetTransactionRequestDataDto
                {
                    Body = new GetTransactionRequestBody
                    {
                        GetTransactionInfo = new GetTransactionInfo
                        {
                            TransactionInfo = new TransactionInfoRequest
                            {
                                UserName = transactionRequestDto?.Account?.Username,
                                Password = transactionRequestDto?.Account?.Password,
                                TransactionInfoInputType = new TransactionInfoInputType
                                {
                                    AccountNo = transactionRequestDto?.Account?.AccountNo,
                                    Iban = transactionRequestDto?.Account?.IBAN,
                                    StartDate = transactionRequestDto?.TransactionInfo?.StartDate?.ToString("yyyy-MM-ddTHH:mm:ss"),
                                    EndDate = transactionRequestDto?.TransactionInfo?.EndDate?.ToString("yyyy-MM-ddTHH:mm:ss"),
                                }
                            }
                        }
                    }
                };

                string body = XmlHelper.SerializeToXml(dto);

                var request = new RestRequest { Method = Method.Post };
                request.AddHeader("SoapAction", $"{transactionRequestDto?.Account?.Action}");
                request.AddHeader("Content-Type", "application/soap+xml;charset=UTF-8");
                request.AddXmlBody(body, ContentType.Xml);

                // API'ye gönderilecek olan REST istemcisinin oluşturulması.
                var client = new RestClient($"{transactionRequestDto?.Account?.BaseUrl}");
                var response = client.Execute(request);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    return new GetTransactionResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"Hesap hareketleri işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.GetTransaction, dto, response?.Content)
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = GetList(response.Content);

                if (result?.ErrorCode != Results.ErrorCode)
                {
                    return new GetTransactionResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"Hesap hareketleri işlemi başarısız. Hata detayı: {result?.ErrorCode} | {result?.ErrorDescription}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.GetTransaction, dto, response?.Content)
                    };
                }

                // İşleme ait sonuç döndürülmesi.
                return new GetTransactionResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"Hesap hareketleri işlemi başarılı."),
                    Transaction = result,
                    ApiLog = SerializerHelper.ProcessData(MethodNames.GetTransaction, dto, response?.Content)
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new GetTransactionResponseDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"Hesap hareketleri işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// Hesap hareketleri yanıtını işleyip sonuçları döndüren metottur.
        /// Yanıt XML verisini JSON formatına çevirir ve uygun DTO'ya parse eder.
        /// </summary>
        /// <param name="content">API'den gelen XML yanıt stringi.</param>
        /// <returns>
        /// Hesap hareketleri yanıt verilerini içeren <see cref="GetTransactionResponseDataDto"/> nesnesi döner.
        /// Eğer yanıt verisi boşsa veya hata içeriyorsa, ilgili hata bilgileri ile birlikte döner.
        /// </returns>
        private static GetTransactionResponseDataDto GetList(string? content)
        {
            GetTransactionResponseDataDto result = new();
            List<GetTransactionsData>? transaction = [];

            try
            {
                if (string.IsNullOrEmpty(content))
                {
                    result.ErrorCode = ResultCode.FailCode.ToString();
                    result.ErrorDescription = "İşleme ait geri dönüş nesnesi boş";
                    return result;
                }

                XDocument doc = XDocument.Parse(content);
                string jsonText = JsonConvert.SerializeXNode(doc);

                JObject jsonObj = JObject.Parse(jsonText);

                // errorCode ve errorDescription alanlarını kontrol et
                string? errorCode = (string?)jsonObj
                    ["soapenv:Envelope"]?
                    ["soapenv:Body"]?
                    ["ns:getTransactionInfoResponse"]?
                    ["return"]?
                    ["errorCode"];

                string? errorDescription = (string?)jsonObj
                    ["soapenv:Envelope"]?
                    ["soapenv:Body"]?
                    ["ns:getTransactionInfoResponse"]?
                    ["return"]?
                    ["errorDescription"];

                var transactionInfoReturnType = jsonObj
                    ["soapenv:Envelope"]?
                    ["soapenv:Body"]?
                    ["ns:getTransactionInfoResponse"]?
                    ["return"]?
                    ["transactionInfoReturnType"];

                if (transactionInfoReturnType != null)
                {
                    var transactionInfos = transactionInfoReturnType["transactionInfos"];

                    // transactionInfos'un bir liste olup olmadığını kontrol et
                    if (transactionInfos is JArray array)
                    {
                        // Liste ise
                        transaction = JsonConvert.DeserializeObject<List<GetTransactionsData>>(JsonConvert.SerializeObject(array)) ?? [];
                    }
                    else if (transactionInfos is JObject obj)
                    {
                        // Tek bir nesne ise
                        var singleTransaction = JsonConvert.DeserializeObject<GetTransactionsData>(JsonConvert.SerializeObject(obj));
                        if (singleTransaction != null)
                        {
                            transaction.Add(singleTransaction);
                        }
                    }
                }

                result.ErrorCode = errorCode;
                result.ErrorDescription = errorDescription;
                result.Datas = transaction;
            }
            catch (Exception)
            {
            }

            return result;
        }
    }
}
