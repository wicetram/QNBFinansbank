using QNBFinansbank.VirtualPos.Business.Abstract;
using QNBFinansbank.VirtualPos.Constant;
using QNBFinansbank.VirtualPos.Entity.Request;
using QNBFinansbank.VirtualPos.Entity.Request.BatchClose;
using QNBFinansbank.VirtualPos.Entity.Request.Cancel;
using QNBFinansbank.VirtualPos.Entity.Request.Check;
using QNBFinansbank.VirtualPos.Entity.Request.History;
using QNBFinansbank.VirtualPos.Entity.Request.Payment;
using QNBFinansbank.VirtualPos.Entity.Request.Payment.NonSecure;
using QNBFinansbank.VirtualPos.Entity.Request.Payment.ThreeD;
using QNBFinansbank.VirtualPos.Entity.Request.Payment.ThreeD.ModelPayment;
using QNBFinansbank.VirtualPos.Entity.Request.PreAuth;
using QNBFinansbank.VirtualPos.Entity.Request.Refund;
using QNBFinansbank.VirtualPos.Entity.Request.RewardPoints.Check;
using QNBFinansbank.VirtualPos.Entity.Request.RewardPoints.Usage;
using QNBFinansbank.VirtualPos.Entity.Response.BatchClose;
using QNBFinansbank.VirtualPos.Entity.Response.Cancel;
using QNBFinansbank.VirtualPos.Entity.Response.Check;
using QNBFinansbank.VirtualPos.Entity.Response.History;
using QNBFinansbank.VirtualPos.Entity.Response.Payment;
using QNBFinansbank.VirtualPos.Entity.Response.Payment.NonSecure;
using QNBFinansbank.VirtualPos.Entity.Response.Payment.ThreeD.ModelPayment;
using QNBFinansbank.VirtualPos.Entity.Response.PreAuth;
using QNBFinansbank.VirtualPos.Entity.Response.Refund;
using QNBFinansbank.VirtualPos.Entity.Response.RewardPoints.Check;
using QNBFinansbank.VirtualPos.Entity.Response.RewardPoints.Usage;
using QNBFinansbank.VirtualPos.Utility;
using QNBFinansbank.VirtualPos.Utility.ApiClient;
using QNBFinansbank.VirtualPos.Utility.Cryptography;
using QNBFinansbank.VirtualPos.Utility.ResponseHandlers;
using QNBFinansbank.VirtualPos.Utility.Serialization;
using RestSharp;

namespace QNBFinansbank.VirtualPos.Business.Concrete
{
    public class VirtualPosManager : IVirtualPosService
    {
        /// <summary>
        /// İptal (Cancel) işlemini gerçekleştirir.
        /// Bu metot, verilen `CancelRequestDataDto` nesnesini kullanarak iptal işlemini başlatır, 
        /// sonuçları kontrol eder ve yanıtı `CancelResponseDataDto` olarak döner.
        /// </summary>
        /// <param name="cancel">İptal işlemi için gerekli olan parametreleri içeren `CancelRequestDataDto` nesnesi.</param>
        /// <returns>
        /// İşlemin sonucunu ve ilgili bilgileri içeren `CancelResponseDataDto` nesnesi.
        /// Başarılı olması durumunda, `Result` alanı başarılı olarak döner. 
        /// Başarısız olması durumunda, hata kodu ve mesajı ile birlikte döner.
        /// </returns>
        public CancelResponseDataDto Cancel(CancelRequestDataDto cancel)
        {
            try
            {
                // İptal isteği için gerekli DTO'nun oluşturulması.
                var dto = new CancelRequestDto
                {
                    Currency = cancel?.Order?.Currency,
                    Lang = cancel?.Order?.Language,
                    OrderId = cancel?.Order?.OrderId,

                    MbrId = cancel?.Account?.MbrId,
                    MerchantID = cancel?.Account?.MerchantId,
                    SecureType = cancel?.Account?.SecureType,
                    TxnType = cancel?.Account?.TxnType,
                    UserCode = cancel?.Account?.UserCode,
                    UserPass = cancel?.Account?.UserPass,

                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, cancel?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful && string.IsNullOrEmpty(response.Content))
                {
                    return new CancelResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{cancel?.Account?.TxnType} işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}")
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<RefundResponseDto>(response.Content);
                if (result == null)
                {
                    return new CancelResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{cancel?.Account?.TxnType} işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.ProcReturnCode != "00")
                {
                    return new CancelResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{cancel?.Account?.TxnType} işlemi başarısız olmuştur. Hata Kodu: {result.ProcReturnCode} | Hata Mesajı: {result.ErrMsg}"),
                    };
                }

                return new CancelResponseDataDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{cancel?.Account?.TxnType} işlemi başarılı."),
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new CancelResponseDataDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{cancel?.Account?.TxnType} işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// Check işlemini gerçekleştirir.
        /// Bu metot, verilen `CheckRequestDataDto` nesnesi ile bir check işlemi başlatır, API çağrısını gerçekleştirir,
        /// yanıtı işler ve sonucu `CheckResponseDataDto` olarak döner.
        /// </summary>
        /// <param name="check">Check işlemi için gerekli olan parametreleri içeren `CheckRequestDataDto` nesnesi.</param>
        /// <returns>
        /// İşlemin sonucunu ve ilgili bilgileri içeren `CheckResponseDataDto` nesnesi.
        /// İşlem başarılıysa, `Result` alanı başarılı olarak döner. 
        /// İşlem başarısızsa, hata kodu ve mesajı ile birlikte döner.
        /// </returns>
        public CheckResponseDataDto Check(CheckRequestDataDto check)
        {
            try
            {
                var dto = new CheckRequestDto
                {
                    Lang = check?.Order?.Language,
                    OrderId = check?.Order?.OrderId,

                    MbrId = check?.Account?.MbrId,
                    MerchantID = check?.Account?.MerchantId,
                    SecureType = check?.Account?.SecureType,
                    TxnType = check?.Account?.TxnType,
                    UserCode = check?.Account?.UserCode,
                    UserPass = check?.Account?.UserPass
                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, check?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful && string.IsNullOrEmpty(response.Content))
                {
                    return new CheckResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{check?.Account?.TxnType} işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}")
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<CheckResponseDto>(response.Content);
                if (result == null)
                {
                    return new CheckResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{check?.Account?.TxnType} işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.ProcReturnCode != "00")
                {
                    return new CheckResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{check?.Account?.TxnType} işlemi başarısız olmuştur. Hata Kodu: {result.ProcReturnCode} | Hata Mesajı: {result.ErrMsg}"),
                        CheckResponse = result
                    };
                }

                return new CheckResponseDataDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{check?.Account?.TxnType} işlemi başarılı."),
                    CheckResponse = result
                };

            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new CheckResponseDataDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{check?.Account?.TxnType} işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// İade (Refund) işlemini gerçekleştirir.
        /// Bu metot, verilen `RefundRequestDataDto` nesnesini kullanarak iade işlemi gerçekleştirir, 
        /// sonuçları kontrol eder ve yanıtı `RefundResponseDataDto` olarak döner.
        /// </summary>
        /// <param name="refund">İade işlemi için gerekli olan parametreleri içeren `RefundRequestDataDto` nesnesi.</param>
        /// <returns>
        /// İşlemin sonucunu ve ilgili bilgileri içeren `RefundResponseDataDto` nesnesi.
        /// Başarılı olması durumunda, `Result` alanı başarılı olarak döner. 
        /// Başarısız olması durumunda, hata kodu ve mesajı ile birlikte döner.
        /// </returns>
        public RefundResponseDataDto Refund(RefundRequestDataDto refund)
        {
            try
            {
                // İade isteği için gerekli DTO'nun oluşturulması.
                var dto = new RefundRequestDto
                {
                    Currency = refund?.Order?.Currency,
                    Lang = refund?.Order?.Language,
                    OrderId = refund?.Order?.OrderId,
                    PurchAmount = refund?.Order?.Amount,

                    MbrId = refund?.Account?.MbrId,
                    MerchantID = refund?.Account?.MerchantId,
                    SecureType = refund?.Account?.SecureType,
                    TxnType = refund?.Account?.TxnType,
                    UserCode = refund?.Account?.UserCode,
                    UserPass = refund?.Account?.UserPass,
                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, refund?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful && string.IsNullOrEmpty(response.Content))
                {
                    return new RefundResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{refund?.Account?.TxnType} işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}")
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<RefundResponseDto>(response.Content);
                if (result == null)
                {
                    return new RefundResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{refund?.Account?.TxnType} işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.ProcReturnCode != "00")
                {
                    return new RefundResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{refund?.Account?.TxnType} işlemi başarısız olmuştur. Hata Kodu: {result.ProcReturnCode} | Hata Mesajı: {result.ErrMsg}"),
                    };
                }

                return new RefundResponseDataDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{refund?.Account?.TxnType} işlemi başarılı."),
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new RefundResponseDataDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{refund?.Account?.TxnType} işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// Ödeme işlemini gerçekleştirir.
        /// Bu metot, verilen `PaymentRequestDataDto` nesnesine göre ödeme işlemini başlatır.
        /// Eğer ödeme işlemi Non-Secure olarak yapılacaksa, `NonSecurePayment` metodunu çağırır; 
        /// aksi takdirde 3D Secure ödeme işlemi için `ThreeDPayment` metodunu çağırır.
        /// </summary>
        /// <param name="startPayment">Ödeme işlemi için gerekli olan parametreleri içeren `PaymentRequestDataDto` nesnesi.</param>
        /// <returns>
        /// İşlemin sonucunu ve ilgili bilgileri içeren `PaymentResponseDto` nesnesi.
        /// Başarılı olması durumunda, `Result` alanı başarılı olarak döner. 
        /// Başarısız olması durumunda, hata kodu ve mesajı ile birlikte döner.
        /// </returns>
        public PaymentResponseDto Payment(PaymentRequestDataDto startPayment)
        {
            try
            {
                if (startPayment?.Order?.PaymentSecurity == 0)
                {
                    return NonSecurePayment(startPayment);
                }
                return ThreeDPayment(startPayment);
            }
            catch (Exception ex)
            {
                return new PaymentResponseDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"İşlem sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// 3D Model ödeme işlemini gerçekleştiren metottur. 
        /// Gönderilen ödeme talebiyle bir POST isteği yapar ve yanıtı DTO formatında döndürür.
        /// </summary>
        /// <param name="threeDModel">3D Model ödeme isteğini temsil eden DTO. Kullanıcı bilgilerini, sipariş numarasını ve diğer gerekli bilgileri içerir.</param>
        /// <returns>
        /// 3D Model ödeme işleminin sonucunu ve ilgili yanıt verilerini içeren bir <see cref="ThreeDModelPaymentResponseDataDto"/> nesnesi döner.
        /// İşlem başarılıysa, <see cref="ThreeDModelPaymentResponseDto"/> nesnesi doldurulmuş olarak döner.
        /// İşlem başarısızsa veya bir hata oluşursa, ilgili hata mesajını içeren bir sonuç döner.
        /// </returns>
        /// <remarks>
        /// Bu metot, ödeme isteği için bir HTTP POST isteği yapar ve yanıtın içeriğini analiz eder.
        /// Yanıt başarılı değilse, hata detayı içeren bir sonuç döner.
        /// Yanıt başarılıysa, yanıt string'ini DTO'ya parse eder ve sonuç olarak döndürür.
        /// Eğer metot sırasında bir hata oluşursa, hata mesajını içeren bir sonuç döner.
        /// </remarks>
        public ThreeDModelPaymentResponseDataDto ThreeDModelPayment(ThreeDModelPaymentRequestDto threeDModel)
        {
            try
            {
                var request = new RestRequest { Method = Method.Post };
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("UserCode", threeDModel.UserCode);
                request.AddParameter("UserPass", threeDModel.UserPass);
                request.AddParameter("OrderId", threeDModel.OrderId);
                request.AddParameter("SecureType", threeDModel.SecureType);
                request.AddParameter("RequestGuid", threeDModel.RequestGuid);

                var client = new RestClient($"{threeDModel?.BaseUrl}");
                var response = client.Execute(request);

                if (!response.IsSuccessful && string.IsNullOrEmpty(response.Content))
                {
                    return new ThreeDModelPaymentResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"3D Model ödeme işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}")
                    };
                }

                var result = ResponseParser.ParseResponseToDto<ThreeDModelPaymentResponseDto>(response.Content);

                if (result.ErrMsg != Results.Success)
                {
                    return new ThreeDModelPaymentResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, "3D Model ödeme işlemi başarısız."),
                        ThreeDModelPayment = result
                    };
                }

                return new ThreeDModelPaymentResponseDataDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, "3D Model ödeme işlemi başarılı."),
                    ThreeDModelPayment = result
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new ThreeDModelPaymentResponseDataDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"3D Model ödeme işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde bir ön otorizasyon (Pre-Auth) işlemini sonlandırır.
        /// Bu metot, verilen <see cref="PreAuthRequestDataDto"/> nesnesine göre işlemi başlatır ve sonuçları kontrol eder.
        /// İşlem sonucu olarak <see cref="PreAuthResponseDataDto"/> nesnesi döner.
        /// </summary>
        /// <param name="preAuthRequest">Ön otorizasyon işlemini sonlandırmak için gerekli olan parametreleri içeren <see cref="PreAuthRequestDataDto"/> nesnesi.</param>
        /// <returns>
        /// İşlemin sonucunu ve ilgili bilgileri içeren <see cref="PreAuthResponseDataDto"/> nesnesi.
        /// Başarılı olması durumunda, <see cref="PreAuthResponseDataDto.Result"/> alanı başarılı olarak döner.
        /// Başarısız olması durumunda, hata kodu ve mesajı ile birlikte döner.
        /// </returns>
        public PreAuthResponseDataDto StopPreAuth(PreAuthRequestDataDto preAuthRequest)
        {
            try
            {
                // Ödeme isteği için gerekli DTO'nun oluşturulması.
                var dto = new PreAuthRequestDto
                {
                    Currency = preAuthRequest?.Order?.Currency,
                    Lang = preAuthRequest?.Order?.Language,
                    OrderId = preAuthRequest?.Order?.OrderId,
                    PurchAmount = preAuthRequest?.Order?.Amount,

                    MbrId = preAuthRequest?.Account?.MbrId,
                    MerchantID = preAuthRequest?.Account?.MerchantId,
                    UserCode = preAuthRequest?.Account?.UserCode,
                    UserPass = preAuthRequest?.Account?.UserPass,

                    SecureType = preAuthRequest?.Account?.SecureType,
                    TxnType = preAuthRequest?.Account?.TxnType,

                    Pan = preAuthRequest?.Card?.CardNo,
                    Cvv2 = preAuthRequest?.Card?.CVC,
                    Expiry = preAuthRequest?.Card?.ExpireDate,
                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, preAuthRequest?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful && string.IsNullOrEmpty(response.Content))
                {
                    return new PreAuthResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{preAuthRequest?.Account?.SecureType} ödeme işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}")
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<PreAuthResponseDto>(response.Content);
                if (result == null)
                {
                    return new PreAuthResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{preAuthRequest?.Account?.SecureType} ödeme işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.ProcReturnCode != Results.Approved)
                {
                    return new PreAuthResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{preAuthRequest?.Account?.SecureType} ödeme işlemi başarısız olmuştur. Hata Kodu: {result.ProcReturnCode} | Hata Mesajı: {result.ErrMsg}"),
                        PreAuthResponse = result
                    };
                }

                return new PreAuthResponseDataDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{preAuthRequest?.Account?.SecureType} ödeme işlemi başarılı."),
                    PreAuthResponse = result
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new PreAuthResponseDataDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{preAuthRequest?.Account?.SecureType} ödeme işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// Para puan sorgulama işlemini gerçekleştirir.
        /// </summary>
        /// <param name="rewardPointsRequestDto">Para puan sorgulama işlemi için gerekli olan tüm bilgileri içeren DTO nesnesi.</param>
        /// <returns>
        /// İşlemin sonucunu ve ilgili bilgileri içeren <see cref="CheckRewardPointsResponseDataDto"/> nesnesi.
        /// Başarılı olması durumunda, <see cref="CheckRewardPointsResponseDataDto.Result"/> alanı başarılı olarak döner.
        /// Başarısız olması durumunda, hata kodu ve mesajı ile birlikte döner.
        /// </returns>
        public CheckRewardPointsResponseDataDto CheckRewardPoints(CheckRewardPointsRequestDataDto rewardPointsRequestDto)
        {
            try
            {
                // Para puan sorgulama isteği için gerekli DTO'nun oluşturulması.
                var dto = new CheckRewardPointsRequestDto
                {
                    Currency = rewardPointsRequestDto?.Order?.Currency,
                    Lang = rewardPointsRequestDto?.Order?.Language,
                    OrderId = rewardPointsRequestDto?.Order?.OrderId,
                    Pan = rewardPointsRequestDto?.Card?.CardNo,
                    MbrId = rewardPointsRequestDto?.Account?.MbrId,
                    MerchantID = rewardPointsRequestDto?.Account?.MerchantId,
                    UserCode = rewardPointsRequestDto?.Account?.UserCode,
                    UserPass = rewardPointsRequestDto?.Account?.UserPass,
                    SecureType = rewardPointsRequestDto?.Account?.SecureType,
                    TxnType = rewardPointsRequestDto?.Account?.TxnType,
                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, rewardPointsRequestDto?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful && string.IsNullOrEmpty(response.Content))
                {
                    return new CheckRewardPointsResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{rewardPointsRequestDto?.Account?.SecureType} ödeme işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}")
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<CheckRewardPointsResponseDto>(response.Content);
                if (result == null)
                {
                    return new CheckRewardPointsResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{rewardPointsRequestDto?.Account?.SecureType} ödeme işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.ProcReturnCode != Results.Approved)
                {
                    return new CheckRewardPointsResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{rewardPointsRequestDto?.Account?.SecureType} ödeme işlemi başarısız olmuştur. Hata Kodu: {result.ProcReturnCode} | Hata Mesajı: {result.ErrMsg}"),
                        Rewards = result
                    };
                }

                return new CheckRewardPointsResponseDataDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{rewardPointsRequestDto?.Account?.SecureType} ödeme işlemi başarılı."),
                    Rewards = result
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new CheckRewardPointsResponseDataDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{rewardPointsRequestDto?.Account?.SecureType} ödeme işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// Para puan kullanımı ile ödeme işlemi gerçekleştirir.
        /// </summary>
        /// <param name="useRewardPointsRequestDto">Para puan kullanımı için gerekli olan tüm bilgileri içeren DTO nesnesi.</param>
        /// <returns>
        /// İşlemin sonucunu ve ilgili bilgileri içeren <see cref="UseRewardPointsResponseDataDto"/> nesnesi.
        /// Başarılı olması durumunda, <see cref="UseRewardPointsResponseDataDto.Result"/> alanı başarılı olarak döner.
        /// Başarısız olması durumunda, hata kodu ve mesajı ile birlikte döner.
        /// </returns>
        public UseRewardPointsResponseDataDto UseRewardPoints(UseRewardPointsRequestDataDto useRewardPointsRequestDto)
        {
            try
            {
                // Para puan ödeme isteği için gerekli DTO'nun oluşturulması.
                var dto = new UseRewardPointsRequestDto
                {
                    Currency = useRewardPointsRequestDto?.Order?.Currency,
                    Lang = useRewardPointsRequestDto?.Order?.Language,
                    OrderId = useRewardPointsRequestDto?.Order?.OrderId,
                    Pan = useRewardPointsRequestDto?.Card?.CardNo,
                    Cvv2 = useRewardPointsRequestDto?.Card?.CVC,
                    Expiry = useRewardPointsRequestDto?.Card?.ExpireDate,
                    BonusAmount = useRewardPointsRequestDto?.Order?.BonusAmount,
                    PurchAmount = useRewardPointsRequestDto?.Order?.Amount,
                    MbrId = useRewardPointsRequestDto?.Account?.MbrId,
                    MerchantID = useRewardPointsRequestDto?.Account?.MerchantId,
                    UserCode = useRewardPointsRequestDto?.Account?.UserCode,
                    UserPass = useRewardPointsRequestDto?.Account?.UserPass,
                    SecureType = useRewardPointsRequestDto?.Account?.SecureType,
                    TxnType = useRewardPointsRequestDto?.Account?.TxnType,

                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, useRewardPointsRequestDto?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful && string.IsNullOrEmpty(response.Content))
                {
                    return new UseRewardPointsResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{useRewardPointsRequestDto?.Account?.SecureType} ödeme işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}")
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<UseRewardPointsResponseDto>(response.Content);
                if (result == null)
                {
                    return new UseRewardPointsResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{useRewardPointsRequestDto?.Account?.SecureType} ödeme işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.ProcReturnCode != Results.Approved)
                {
                    return new UseRewardPointsResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{useRewardPointsRequestDto?.Account?.SecureType} ödeme işlemi başarısız olmuştur. Hata Kodu: {result.ProcReturnCode} | Hata Mesajı: {result.ErrMsg}"),
                        RewardPointsResponse = result
                    };
                }

                return new UseRewardPointsResponseDataDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{useRewardPointsRequestDto?.Account?.SecureType} ödeme işlemi başarılı."),
                    RewardPointsResponse = result
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new UseRewardPointsResponseDataDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{useRewardPointsRequestDto?.Account?.SecureType} ödeme işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinden işlem geçmişini sorgular.
        /// Bu yöntem, işlem geçmişi sorgulama parametrelerini alarak işlem sonucunu döner.
        /// </summary>
        /// <param name="historyRequestDataDto">
        /// İşlem geçmişi sorgulama işlemi için gerekli olan parametreleri içeren bir <see cref="HistoryRequestDataDto"/> nesnesi.
        /// Bu nesne, sorgulama işlemiyle ilgili hesap, sipariş ve tarih bilgilerini içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="HistoryResponseDataDto"/> nesnesi döner.
        /// Bu nesne, işlem geçmişi sorgulama işleminin sonucunu, başarı durumunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        public HistoryResponseDataDto History(HistoryRequestDataDto historyRequestDataDto)
        {
            try
            {
                // İşlem geçmişi sorgulama isteği için gerekli DTO'nun oluşturulması.
                var dto = new HistoryRequestDto
                {
                    Currency = historyRequestDataDto?.Order?.Currency,
                    Lang = historyRequestDataDto?.Order?.Language,
                    OrderId = historyRequestDataDto?.Order?.OrderId,
                    MbrId = historyRequestDataDto?.Account?.MbrId,
                    MerchantID = historyRequestDataDto?.Account?.MerchantId,
                    UserCode = historyRequestDataDto?.Account?.UserCode,
                    UserPass = historyRequestDataDto?.Account?.UserPass,
                    SecureType = historyRequestDataDto?.Account?.SecureType,
                    TxnType = historyRequestDataDto?.Account?.TxnType,
                    ReqDate = historyRequestDataDto?.RequestDate,
                    RequestStartDatetime = historyRequestDataDto?.RequestStartDatetime,
                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, historyRequestDataDto?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful && string.IsNullOrEmpty(response.Content))
                {
                    return new HistoryResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{historyRequestDataDto?.Account?.SecureType} ödeme işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}")
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<HistoryResponseDto>(response.Content);
                if (result == null)
                {
                    return new HistoryResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{historyRequestDataDto?.Account?.SecureType} ödeme işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result?.PaymentRequest?.ProcReturnCode != Results.Approved)
                {
                    return new HistoryResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{historyRequestDataDto?.Account?.SecureType} ödeme işlemi başarısız olmuştur. Hata Kodu: {result?.PaymentRequest?.ProcReturnCode} | Hata Mesajı: {result?.PaymentRequest?.ErrMsg}"),
                        History = result
                    };
                }

                return new HistoryResponseDataDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{historyRequestDataDto?.Account?.SecureType} ödeme işlemi başarılı."),
                    History = result
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new HistoryResponseDataDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{historyRequestDataDto?.Account?.SecureType} ödeme işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinden toplu kapama (batch close) işlemini gerçekleştirir.
        /// Bu yöntem, toplu kapama parametrelerini alarak işlem sonucunu döner.
        /// </summary>
        /// <param name="batchCloseRequestData">
        /// Toplu kapama işlemi için gerekli olan parametreleri içeren bir <see cref="BatchCloseRequestDataDto"/> nesnesi.
        /// Bu nesne, hesap ve işlemle ilgili bilgileri içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="BatchCloseResponseDataDto"/> nesnesi döner.
        /// Bu nesne, toplu kapama işleminin sonucunu, başarı durumunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        public BatchCloseResponseDataDto BatchClose(BatchCloseRequestDataDto batchCloseRequestData)
        {
            try
            {
                // Toplu kapama isteği için gerekli DTO'nun oluşturulması.
                var dto = new BatchCloseRequestDto
                {
                    MbrId = batchCloseRequestData?.Account?.MbrId,
                    MerchantID = batchCloseRequestData?.Account?.MerchantId,
                    UserCode = batchCloseRequestData?.Account?.UserCode,
                    UserPass = batchCloseRequestData?.Account?.UserPass,
                    SecureType = batchCloseRequestData?.Account?.SecureType,
                    TxnType = batchCloseRequestData?.Account?.TxnType,
                    Currency = batchCloseRequestData?.Order?.Currency,
                    Lang = batchCloseRequestData?.Order?.Language
                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, batchCloseRequestData?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful && string.IsNullOrEmpty(response.Content))
                {
                    return new BatchCloseResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{batchCloseRequestData?.Account?.SecureType} ödeme işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}")
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<BatchCloseResponseDto>(response.Content);
                if (result == null)
                {
                    return new BatchCloseResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{batchCloseRequestData?.Account?.SecureType} ödeme işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result?.ProcReturnCode != Results.Approved)
                {
                    return new BatchCloseResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{batchCloseRequestData?.Account?.SecureType} ödeme işlemi başarısız olmuştur. Hata Kodu: {result?.ProcReturnCode} | Hata Mesajı: {result?.ErrMsg}"),
                        BatchClose = result
                    };
                }

                return new BatchCloseResponseDataDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{batchCloseRequestData?.Account?.SecureType} ödeme işlemi başarılı."),
                    BatchClose = result
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new BatchCloseResponseDataDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{batchCloseRequestData?.Account?.SecureType} ödeme işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// NonSecure ödeme işlemi gerçekleştirir.
        /// </summary>
        /// <param name="startPayment">Ödeme işlemi için gerekli olan tüm bilgileri içeren DTO nesnesi.</param>
        /// <returns>Ödeme işleminin sonucunu temsil eden <see cref="PaymentResponseDto"/> nesnesi.</returns>
        private static PaymentResponseDto NonSecurePayment(PaymentRequestDataDto startPayment)
        {
            try
            {
                // Ödeme isteği için gerekli DTO'nun oluşturulması.
                var dto = new NonSecurePaymentRequestDto
                {
                    Currency = startPayment?.Order?.Currency,
                    Lang = startPayment?.Order?.Language,
                    OrderId = startPayment?.Order?.OrderId,
                    PurchAmount = startPayment?.Order?.Amount,
                    InstallmentCount = startPayment?.Order?.Installment == "1" ? "0" : startPayment?.Order?.Installment,

                    MbrId = startPayment?.Account?.MbrId,
                    MerchantID = startPayment?.Account?.MerchantId,
                    UserCode = startPayment?.Account?.UserCode,
                    UserPass = startPayment?.Account?.UserPass,

                    SecureType = startPayment?.Account?.SecureType,
                    TxnType = startPayment?.Account?.TxnType,

                    Pan = startPayment?.Card?.CardNo,
                    Cvv2 = startPayment?.Card?.CVC,
                    Expiry = startPayment?.Card?.ExpireDate,
                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, startPayment?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful && string.IsNullOrEmpty(response.Content))
                {
                    return new PaymentResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{startPayment?.Account?.SecureType} ödeme işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}")
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<NonSecurePaymentResponseDto>(response.Content);
                if (result == null)
                {
                    return new PaymentResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{startPayment?.Account?.SecureType} ödeme işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                        Payment = ResponseHandler.GetPayment(startPayment?.Order?.OrderId)
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.ProcReturnCode != "00")
                {
                    return new PaymentResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{startPayment?.Account?.SecureType} ödeme işlemi başarısız olmuştur. Hata Kodu: {result.ProcReturnCode} | Hata Mesajı: {result.ErrMsg}"),
                        Payment = ResponseHandler.GetPayment(startPayment?.Order?.OrderId)
                    };
                }

                return new PaymentResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{startPayment?.Account?.SecureType} ödeme işlemi başarılı."),
                    Payment = ResponseHandler.GetPayment(startPayment?.Order?.OrderId)
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new PaymentResponseDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{startPayment?.Account?.SecureType} ödeme işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// 3D ödeme işlemini gerçekleştirir.
        /// </summary>
        /// <param name="startPayment">Ödeme işlemi için gerekli olan tüm bilgileri içeren DTO nesnesi.</param>
        /// <returns>Ödeme işleminin sonucunu temsil eden <see cref="PaymentResponseDto"/> nesnesi.</returns>
        private static PaymentResponseDto ThreeDPayment(PaymentRequestDataDto? startPayment)
        {
            try
            {
                string hash = PaymentHashHelper(startPayment?.Account, startPayment?.Order);
                if (string.IsNullOrEmpty(hash))
                {
                    return new PaymentResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{startPayment?.Account?.SecureType} ödeme işlemi başlatılmak istenmiştir, ancak hash değeri oluşturulamadığı için ödeme başlatılamamıştır.")
                    };
                }

                var dto = new ThreeDPaymentRequestDto
                {
                    Currency = startPayment?.Order?.Currency,
                    Lang = startPayment?.Order?.Language,
                    OrderId = startPayment?.Order?.OrderId,
                    PurchAmount = startPayment?.Order?.Amount,
                    InstallmentCount = startPayment?.Order?.Installment == "1" ? "0" : startPayment?.Order?.Installment,

                    MbrId = startPayment?.Account?.MbrId,
                    MerchantID = startPayment?.Account?.MerchantId,
                    UserCode = startPayment?.Account?.UserCode,
                    UserPass = startPayment?.Account?.UserPass,

                    SecureType = startPayment?.Account?.SecureType,
                    TxnType = startPayment?.Account?.TxnType,

                    Pan = startPayment?.Card?.CardNo,
                    Cvv2 = startPayment?.Card?.CVC,
                    Expiry = startPayment?.Card?.ExpireDate,

                    OkUrl = startPayment?.Order?.ReturnUrl,
                    FailUrl = startPayment?.Order?.ReturnUrl,
                    Rnd = startPayment?.Order?.Random,
                    Hash = hash,

                    //PF aşaması henüz tamamlanmadığı için kapatıldı.
                    //PaymentFacilicator = new PaymentFacilicatorRequestDto
                    //{

                    //}
                };

                var collection = NameValueCollectionHelper.ToNameValueCollection(dto);

                string html = NameValueCollectionHelper.GenerateHtmlForm(collection, startPayment?.Account?.BaseUrl);

                return new PaymentResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{startPayment?.Account?.SecureType} ödeme işlemi başarılı."),
                    Payment = ResponseHandler.GetPayment(startPayment?.Order?.OrderId, html)
                };
            }
            catch (Exception ex)
            {
                return new PaymentResponseDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{startPayment?.Account?.SecureType} ödeme işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// Verilen hesap ve sipariş bilgilerini kullanarak bir SHA1 hash oluşturur.
        /// </summary>
        /// <param name="account">Hesap bilgilerini içeren DTO nesnesi.</param>
        /// <param name="order">Sipariş bilgilerini içeren DTO nesnesi.</param>
        /// <returns>
        /// Hesap ve sipariş bilgilerini birleştirerek oluşturulan SHA1 hash değeri.
        /// </returns>
        private static string PaymentHashHelper(AccountDto? account, OrderDto? order)
        {
            string hashString = $"{account?.MbrId}{order?.OrderId}{order?.Amount}{order?.ReturnUrl}{order?.ReturnUrl}{account?.TxnType}{(order?.Installment == "1" ? "0" : order?.Installment)}{order?.Random}{account?.MerchantPass}";
            string hash = CryptoManager.SHA1Encryption(hashString);
            return hash;
        }
    }
}
