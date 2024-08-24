using Newtonsoft.Json;
using QNBFinansbank.VirtualPos.Business.Abstract;
using QNBFinansbank.VirtualPos.Constant;
using QNBFinansbank.VirtualPos.Entity.Request;
using QNBFinansbank.VirtualPos.Entity.Request.BatchClose;
using QNBFinansbank.VirtualPos.Entity.Request.Cancel;
using QNBFinansbank.VirtualPos.Entity.Request.Check;
using QNBFinansbank.VirtualPos.Entity.Request.EOD;
using QNBFinansbank.VirtualPos.Entity.Request.EOD.QNBFinansbank.VirtualPos.Entity.Request.EOD;
using QNBFinansbank.VirtualPos.Entity.Request.History;
using QNBFinansbank.VirtualPos.Entity.Request.Payment;
using QNBFinansbank.VirtualPos.Entity.Request.Payment.NonSecure;
using QNBFinansbank.VirtualPos.Entity.Request.Payment.PaymentFacilicator;
using QNBFinansbank.VirtualPos.Entity.Request.Payment.ThreeD;
using QNBFinansbank.VirtualPos.Entity.Request.Payment.ThreeD.ModelPayment;
using QNBFinansbank.VirtualPos.Entity.Request.PreAuth;
using QNBFinansbank.VirtualPos.Entity.Request.Refund;
using QNBFinansbank.VirtualPos.Entity.Request.Report;
using QNBFinansbank.VirtualPos.Entity.Request.RewardPoints.Check;
using QNBFinansbank.VirtualPos.Entity.Request.RewardPoints.Usage;
using QNBFinansbank.VirtualPos.Entity.Request.SegmentInquiry;
using QNBFinansbank.VirtualPos.Entity.Response.BatchClose;
using QNBFinansbank.VirtualPos.Entity.Response.Cancel;
using QNBFinansbank.VirtualPos.Entity.Response.Check;
using QNBFinansbank.VirtualPos.Entity.Response.EOD;
using QNBFinansbank.VirtualPos.Entity.Response.History;
using QNBFinansbank.VirtualPos.Entity.Response.Payment;
using QNBFinansbank.VirtualPos.Entity.Response.Payment.NonSecure;
using QNBFinansbank.VirtualPos.Entity.Response.Payment.ThreeD.ModelPayment;
using QNBFinansbank.VirtualPos.Entity.Response.PreAuth;
using QNBFinansbank.VirtualPos.Entity.Response.Refund;
using QNBFinansbank.VirtualPos.Entity.Response.Report;
using QNBFinansbank.VirtualPos.Entity.Response.RewardPoints.Check;
using QNBFinansbank.VirtualPos.Entity.Response.RewardPoints.Usage;
using QNBFinansbank.VirtualPos.Entity.Response.SegmentInquiry;
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
        /// Bu metot, verilen `CancelRequestDto` nesnesini kullanarak iptal işlemini başlatır, 
        /// sonuçları kontrol eder ve yanıtı `CancelResponseDataDto` olarak döner.
        /// </summary>
        /// <param name="cancel">İptal işlemi için gerekli olan parametreleri içeren `CancelRequestDataDto` nesnesi.</param>
        /// <returns>
        /// İşlemin sonucunu ve ilgili bilgileri içeren `CancelResponseDto` nesnesi.
        /// Başarılı olması durumunda, `Result` alanı başarılı olarak döner. 
        /// Başarısız olması durumunda, hata kodu ve mesajı ile birlikte döner.
        /// </returns>
        public CancelResponseDto Cancel(CancelRequestDto cancel)
        {
            try
            {
                // İptal isteği için gerekli DTO'nun oluşturulması.
                var dto = new CancelRequestDataDto
                {
                    Currency = cancel?.Order?.Currency,
                    Lang = cancel?.Order?.Language,
                    OrderId = cancel?.Order?.OrderId,

                    MbrId = cancel?.Account?.MbrId,
                    MerchantID = cancel?.Account?.MerchantId,
                    UserCode = cancel?.Account?.UserCode,
                    UserPass = cancel?.Account?.UserPass,

                    SecureType = cancel?.Account?.SecureType ?? SecureTypes.NonSecure,
                    TxnType = cancel?.Account?.TxnType ?? TxnTypes.Void,
                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, cancel?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    return new CancelResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{cancel?.Account?.TxnType} işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.Cancel, dto, response?.Content)
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<CancelResponseDataDto>(response.Content);
                if (result == null)
                {
                    return new CancelResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{cancel?.Account?.TxnType} işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.Cancel, dto, response?.Content)
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.ProcReturnCode != Results.Approved)
                {
                    return new CancelResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{cancel?.Account?.TxnType} işlemi başarısız olmuştur. Hata Kodu: {result.ProcReturnCode} | Hata Mesajı: {result.ErrMsg}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.Cancel, dto, response?.Content)
                    };
                }

                return new CancelResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{cancel?.Account?.TxnType} işlemi başarılı."),
                    Cancel = result,
                    ApiLog = SerializerHelper.ProcessData(MethodNames.Cancel, dto, response?.Content)
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new CancelResponseDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{cancel?.Account?.TxnType} işlemi sırasında tanımsız hata. Hata: {ex.Message}"),
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
        public CheckResponseDto Check(CheckRequestDto check)
        {
            try
            {
                var dto = new CheckRequestDataDto
                {
                    Lang = check?.Order?.Language,
                    OrderId = check?.Order?.OrderId,

                    MbrId = check?.Account?.MbrId,
                    MerchantID = check?.Account?.MerchantId,
                    UserCode = check?.Account?.UserCode,
                    UserPass = check?.Account?.UserPass,

                    TxnType = check?.Account?.TxnType ?? TxnTypes.OrderInquiry,
                    SecureType = check?.Account?.SecureType ?? SecureTypes.Inquiry,
                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, check?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    return new CheckResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{check?.Account?.TxnType} işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.Check, dto, response?.Content)
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<CheckResponseDataDto>(response.Content);
                if (result == null)
                {
                    return new CheckResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{check?.Account?.TxnType} işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.Check, dto, response?.Content)
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.ProcReturnCode != Results.Approved)
                {
                    return new CheckResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{check?.Account?.TxnType} işlemi başarısız olmuştur. Hata Kodu: {result.ProcReturnCode} | Hata Mesajı: {result.ErrMsg}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.Check, dto, response?.Content)
                    };
                }

                return new CheckResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{check?.Account?.TxnType} işlemi başarılı."),
                    CheckResponse = result,
                    ApiLog = SerializerHelper.ProcessData(MethodNames.Check, dto, response?.Content)
                };

            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new CheckResponseDto
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
        public RefundResponseDto Refund(RefundRequestDto refund)
        {
            try
            {
                // İade isteği için gerekli DTO'nun oluşturulması.
                var dto = new RefundRequestDataDto
                {
                    Currency = refund?.Order?.Currency,
                    Lang = refund?.Order?.Language,
                    OrderId = refund?.Order?.OrderId,
                    PurchAmount = refund?.Order?.Amount,

                    MbrId = refund?.Account?.MbrId,
                    MerchantID = refund?.Account?.MerchantId,
                    UserCode = refund?.Account?.UserCode,
                    UserPass = refund?.Account?.UserPass,

                    TxnType = refund?.Account?.TxnType ?? TxnTypes.Refund,
                    SecureType = refund?.Account?.SecureType ?? SecureTypes.NonSecure,
                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, refund?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    return new RefundResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{refund?.Account?.TxnType} işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.Refund, dto, response?.Content)
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<RefundResponseDataDto>(response.Content);
                if (result == null)
                {
                    return new RefundResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{refund?.Account?.TxnType} işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.Refund, dto, response?.Content)
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.ProcReturnCode != Results.Approved)
                {
                    return new RefundResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{refund?.Account?.TxnType} işlemi başarısız olmuştur. Hata Kodu: {result.ProcReturnCode} | Hata Mesajı: {result.ErrMsg}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.Refund, dto, response?.Content)
                    };
                }

                return new RefundResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{refund?.Account?.TxnType} işlemi başarılı."),
                    Response = result,
                    ApiLog = SerializerHelper.ProcessData(MethodNames.Refund, dto, response?.Content)
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new RefundResponseDto
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
        public PaymentResponseDto Payment(PaymentRequestDto startPayment)
        {
            try
            {
                if (startPayment?.Order?.PaymentSecurity == false)
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
        /// 3D Model ödeme işleminin sonucunu ve ilgili yanıt verilerini içeren bir <see cref="ThreeDModelPaymentResponseDto"/> nesnesi döner.
        /// İşlem başarılıysa, <see cref="ThreeDModelPaymentResponseDataDto"/> nesnesi doldurulmuş olarak döner.
        /// İşlem başarısızsa veya bir hata oluşursa, ilgili hata mesajını içeren bir sonuç döner.
        /// </returns>
        /// <remarks>
        /// Bu metot, ödeme isteği için bir HTTP POST isteği yapar ve yanıtın içeriğini analiz eder.
        /// Yanıt başarılı değilse, hata detayı içeren bir sonuç döner.
        /// Yanıt başarılıysa, yanıt string'ini DTO'ya parse eder ve sonuç olarak döndürür.
        /// Eğer metot sırasında bir hata oluşursa, hata mesajını içeren bir sonuç döner.
        /// </remarks>
        public ThreeDModelPaymentResponseDto ThreeDModelPayment(ThreeDModelPaymentRequestDto threeDModel)
        {
            try
            {
                var request = new RestRequest { Method = Method.Post };
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("UserCode", threeDModel.UserCode);
                request.AddParameter("UserPass", threeDModel.UserPass);
                request.AddParameter("OrderId", threeDModel.OrderId);
                request.AddParameter("SecureType", threeDModel.SecureType ?? SecureTypes.ThreeDModelPayment);
                request.AddParameter("RequestGuid", threeDModel.RequestGuid);

                var client = new RestClient($"{threeDModel?.BaseUrl}");
                var response = client.Execute(request);

                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    return new ThreeDModelPaymentResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"3D Model ödeme işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.ThreeDModelPayment, threeDModel, response?.Content)
                    };
                }

                var result = ResponseParser.ParseResponseToDto<ThreeDModelPaymentResponseDataDto>(response.Content);

                if (result.ErrMsg != Results.Success)
                {
                    return new ThreeDModelPaymentResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"3D Model ödeme işlemi başarısız. Hata detayı: {result.ProcReturnCode} | {result.ErrMsg}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.ThreeDModelPayment, threeDModel, response?.Content)
                    };
                }

                return new ThreeDModelPaymentResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, "3D Model ödeme işlemi başarılı."),
                    ThreeDModelPayment = result,
                    ApiLog = SerializerHelper.ProcessData(MethodNames.ThreeDModelPayment, threeDModel, response?.Content)
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new ThreeDModelPaymentResponseDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"3D Model ödeme işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde bir ön otorizasyon (Pre-Auth) işlemini sonlandırır.
        /// Bu metot, verilen <see cref="PreAuthRequestDto"/> nesnesine göre işlemi başlatır ve sonuçları kontrol eder.
        /// İşlem sonucu olarak <see cref="PreAuthResponseDto"/> nesnesi döner.
        /// </summary>
        /// <param name="preAuthRequest">Ön otorizasyon işlemini sonlandırmak için gerekli olan parametreleri içeren <see cref="PreAuthRequestDto"/> nesnesi.</param>
        /// <returns>
        /// İşlemin sonucunu ve ilgili bilgileri içeren <see cref="PreAuthResponseDto"/> nesnesi.
        /// Başarılı olması durumunda, <see cref="PreAuthResponseDto.Result"/> alanı başarılı olarak döner.
        /// Başarısız olması durumunda, hata kodu ve mesajı ile birlikte döner.
        /// </returns>
        public PreAuthResponseDto StopPreAuth(PreAuthRequestDto preAuthRequest)
        {
            try
            {
                // Ödeme isteği için gerekli DTO'nun oluşturulması.
                var dto = new PreAuthRequestDataDto
                {
                    Currency = preAuthRequest?.Order?.Currency,
                    Lang = preAuthRequest?.Order?.Language,
                    OrderId = preAuthRequest?.Order?.OrderId,
                    PurchAmount = preAuthRequest?.Order?.Amount,

                    MbrId = preAuthRequest?.Account?.MbrId,
                    MerchantID = preAuthRequest?.Account?.MerchantId,
                    UserCode = preAuthRequest?.Account?.UserCode,
                    UserPass = preAuthRequest?.Account?.UserPass,

                    SecureType = preAuthRequest?.Account?.SecureType ?? SecureTypes.NonSecure,
                    TxnType = preAuthRequest?.Account?.TxnType ?? TxnTypes.PostAuth,

                    Pan = preAuthRequest?.Card?.CardNo,
                    Cvv2 = preAuthRequest?.Card?.CVC,
                    Expiry = $"{preAuthRequest?.Card?.ExpireMonth}{preAuthRequest?.Card?.ExpireYear}",
                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, preAuthRequest?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    return new PreAuthResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{preAuthRequest?.Account?.SecureType} ödeme işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.StopPreAuth, dto, response?.Content)
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<PreAuthResponseDataDto>(response.Content);
                if (result == null)
                {
                    return new PreAuthResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{preAuthRequest?.Account?.SecureType} ödeme işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.StopPreAuth, dto, response?.Content)
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.ProcReturnCode != Results.Approved)
                {
                    return new PreAuthResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{preAuthRequest?.Account?.SecureType} ödeme işlemi başarısız olmuştur. Hata Kodu: {result.ProcReturnCode} | Hata Mesajı: {result.ErrMsg}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.StopPreAuth, dto, response?.Content)
                    };
                }

                return new PreAuthResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{preAuthRequest?.Account?.SecureType} ödeme işlemi başarılı."),
                    PreAuthResponse = result,
                    ApiLog = SerializerHelper.ProcessData(MethodNames.StopPreAuth, dto, response?.Content)
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new PreAuthResponseDto
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
        /// İşlemin sonucunu ve ilgili bilgileri içeren <see cref="CheckRewardPointsResponseDto"/> nesnesi.
        /// Başarılı olması durumunda, <see cref="CheckRewardPointsResponseDto.Result"/> alanı başarılı olarak döner.
        /// Başarısız olması durumunda, hata kodu ve mesajı ile birlikte döner.
        /// </returns>
        public CheckRewardPointsResponseDto CheckRewardPoints(CheckRewardPointsRequestDto rewardPointsRequestDto)
        {
            try
            {
                // Para puan sorgulama isteği için gerekli DTO'nun oluşturulması.
                var dto = new CheckRewardPointsRequestDataDto
                {
                    Currency = rewardPointsRequestDto?.Order?.Currency,
                    Lang = rewardPointsRequestDto?.Order?.Language,
                    OrderId = rewardPointsRequestDto?.Order?.OrderId,
                    Pan = rewardPointsRequestDto?.Card?.CardNo,

                    MbrId = rewardPointsRequestDto?.Account?.MbrId,
                    MerchantID = rewardPointsRequestDto?.Account?.MerchantId,
                    UserCode = rewardPointsRequestDto?.Account?.UserCode,
                    UserPass = rewardPointsRequestDto?.Account?.UserPass,

                    SecureType = rewardPointsRequestDto?.Account?.SecureType ?? SecureTypes.Inquiry,
                    TxnType = rewardPointsRequestDto?.Account?.TxnType ?? TxnTypes.ParaPuanInquiry,
                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, rewardPointsRequestDto?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    return new CheckRewardPointsResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{rewardPointsRequestDto?.Account?.SecureType} ödeme işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.CheckRewardPoints, dto, response?.Content)
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<CheckRewardPointsResponseDataDto>(response.Content);
                if (result == null)
                {
                    return new CheckRewardPointsResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{rewardPointsRequestDto?.Account?.SecureType} ödeme işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.CheckRewardPoints, dto, response?.Content)
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.ProcReturnCode != Results.Approved)
                {
                    return new CheckRewardPointsResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{rewardPointsRequestDto?.Account?.SecureType} ödeme işlemi başarısız olmuştur. Hata Kodu: {result.ProcReturnCode} | Hata Mesajı: {result.ErrMsg}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.CheckRewardPoints, dto, response?.Content)
                    };
                }

                return new CheckRewardPointsResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{rewardPointsRequestDto?.Account?.SecureType} ödeme işlemi başarılı."),
                    Rewards = result,
                    ApiLog = SerializerHelper.ProcessData(MethodNames.CheckRewardPoints, dto, response?.Content)
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new CheckRewardPointsResponseDto
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
        /// İşlemin sonucunu ve ilgili bilgileri içeren <see cref="UseRewardPointsResponseDto"/> nesnesi.
        /// Başarılı olması durumunda, <see cref="UseRewardPointsResponseDto.Result"/> alanı başarılı olarak döner.
        /// Başarısız olması durumunda, hata kodu ve mesajı ile birlikte döner.
        /// </returns>
        public UseRewardPointsResponseDto UseRewardPoints(UseRewardPointsRequestDto useRewardPointsRequestDto)
        {
            try
            {
                // Para puan ödeme isteği için gerekli DTO'nun oluşturulması.
                var dto = new UseRewardPointsRequestDataDto
                {
                    Currency = useRewardPointsRequestDto?.Order?.Currency,
                    Lang = useRewardPointsRequestDto?.Order?.Language,
                    OrderId = useRewardPointsRequestDto?.Order?.OrderId,

                    Pan = useRewardPointsRequestDto?.Card?.CardNo,
                    Cvv2 = useRewardPointsRequestDto?.Card?.CVC,
                    Expiry = $"{useRewardPointsRequestDto?.Card?.ExpireMonth}{useRewardPointsRequestDto?.Card?.ExpireYear}",

                    BonusAmount = useRewardPointsRequestDto?.Order?.BonusAmount,
                    PurchAmount = useRewardPointsRequestDto?.Order?.Amount,

                    MbrId = useRewardPointsRequestDto?.Account?.MbrId,
                    MerchantID = useRewardPointsRequestDto?.Account?.MerchantId,
                    UserCode = useRewardPointsRequestDto?.Account?.UserCode,
                    UserPass = useRewardPointsRequestDto?.Account?.UserPass,

                    SecureType = useRewardPointsRequestDto?.Account?.SecureType ?? SecureTypes.NonSecure,
                    TxnType = useRewardPointsRequestDto?.Account?.TxnType ?? TxnTypes.ParaPuanAuth,
                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, useRewardPointsRequestDto?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    return new UseRewardPointsResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{useRewardPointsRequestDto?.Account?.SecureType} ödeme işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.UseRewardPoints, dto, response?.Content)
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<UseRewardPointsResponseDataDto>(response.Content);
                if (result == null)
                {
                    return new UseRewardPointsResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{useRewardPointsRequestDto?.Account?.SecureType} ödeme işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.UseRewardPoints, dto, response?.Content)
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.ProcReturnCode != Results.Approved)
                {
                    return new UseRewardPointsResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{useRewardPointsRequestDto?.Account?.SecureType} ödeme işlemi başarısız olmuştur. Hata Kodu: {result.ProcReturnCode} | Hata Mesajı: {result.ErrMsg}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.UseRewardPoints, dto, response?.Content)
                    };
                }


                return new UseRewardPointsResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{useRewardPointsRequestDto?.Account?.SecureType} ödeme işlemi başarılı."),
                    RewardPointsResponse = result,
                    ApiLog = SerializerHelper.ProcessData(MethodNames.UseRewardPoints, dto, response?.Content)
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new UseRewardPointsResponseDto
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
        /// İşlem geçmişi sorgulama işlemi için gerekli olan parametreleri içeren bir <see cref="HistoryRequestDto"/> nesnesi.
        /// Bu nesne, sorgulama işlemiyle ilgili hesap, sipariş ve tarih bilgilerini içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="HistoryResponseDto"/> nesnesi döner.
        /// Bu nesne, işlem geçmişi sorgulama işleminin sonucunu, başarı durumunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        public HistoryResponseDto History(HistoryRequestDto historyRequestDataDto)
        {
            try
            {
                // İşlem geçmişi sorgulama isteği için gerekli DTO'nun oluşturulması.
                var dto = new HistoryRequestDataDto
                {
                    Currency = historyRequestDataDto?.Order?.Currency,
                    Lang = historyRequestDataDto?.Order?.Language,
                    OrderId = historyRequestDataDto?.Order?.OrderId,

                    ReqDate = historyRequestDataDto?.RequestDate,
                    RequestStartDatetime = historyRequestDataDto?.RequestStartDatetime,

                    MbrId = historyRequestDataDto?.Account?.MbrId,
                    MerchantID = historyRequestDataDto?.Account?.MerchantId,
                    UserCode = historyRequestDataDto?.Account?.UserCode,
                    UserPass = historyRequestDataDto?.Account?.UserPass,

                    SecureType = historyRequestDataDto?.Account?.SecureType ?? SecureTypes.Report,
                    TxnType = historyRequestDataDto?.Account?.TxnType ?? TxnTypes.TxnHistory,
                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, historyRequestDataDto?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    return new HistoryResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{historyRequestDataDto?.Account?.SecureType} ödeme işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.History, dto, response?.Content)
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<HistoryResponseDataDto>(response.Content);
                if (result == null)
                {
                    return new HistoryResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{historyRequestDataDto?.Account?.SecureType} ödeme işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.History, dto, response?.Content)
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result?.PaymentRequest?.ProcReturnCode != Results.Approved)
                {
                    return new HistoryResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{historyRequestDataDto?.Account?.SecureType} ödeme işlemi başarısız olmuştur. Hata Kodu: {result?.PaymentRequest?.ProcReturnCode} | Hata Mesajı: {result?.PaymentRequest?.ErrMsg}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.History, dto, response?.Content)
                    };
                }

                return new HistoryResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{historyRequestDataDto?.Account?.SecureType} ödeme işlemi başarılı."),
                    History = result,
                    ApiLog = SerializerHelper.ProcessData(MethodNames.History, dto, response?.Content)
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new HistoryResponseDto
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
        /// Toplu kapama işlemi için gerekli olan parametreleri içeren bir <see cref="BatchCloseRequestDto"/> nesnesi.
        /// Bu nesne, hesap ve işlemle ilgili bilgileri içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="BatchCloseResponseDto"/> nesnesi döner.
        /// Bu nesne, toplu kapama işleminin sonucunu, başarı durumunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        public BatchCloseResponseDto BatchClose(BatchCloseRequestDto batchCloseRequestData)
        {
            try
            {
                // Toplu kapama isteği için gerekli DTO'nun oluşturulması.
                var dto = new BatchCloseRequestDataDto
                {
                    Currency = batchCloseRequestData?.Order?.Currency,
                    Lang = batchCloseRequestData?.Order?.Language,

                    MbrId = batchCloseRequestData?.Account?.MbrId,
                    MerchantID = batchCloseRequestData?.Account?.MerchantId,
                    UserCode = batchCloseRequestData?.Account?.UserCode,
                    UserPass = batchCloseRequestData?.Account?.UserPass,

                    SecureType = batchCloseRequestData?.Account?.SecureType ?? SecureTypes.NonSecure,
                    TxnType = batchCloseRequestData?.Account?.TxnType ?? TxnTypes.BatchClose,
                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, batchCloseRequestData?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    return new BatchCloseResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{batchCloseRequestData?.Account?.TxnType} işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.BatchClose, dto, response?.Content)
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<BatchCloseResponseDataDto>(response.Content);
                if (result == null)
                {
                    return new BatchCloseResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{batchCloseRequestData?.Account?.TxnType} işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.BatchClose, dto, response?.Content)
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result?.ProcReturnCode != Results.Approved)
                {
                    return new BatchCloseResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{batchCloseRequestData?.Account?.TxnType} işlemi başarısız olmuştur. Hata Kodu: {result?.ProcReturnCode} | Hata Mesajı: {result?.ErrMsg}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.BatchClose, dto, response?.Content)
                    };
                }

                return new BatchCloseResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{batchCloseRequestData?.Account?.TxnType} işlemi başarılı."),
                    BatchClose = result,
                    ApiLog = SerializerHelper.ProcessData(MethodNames.BatchClose, dto, response?.Content)
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new BatchCloseResponseDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{batchCloseRequestData?.Account?.TxnType} işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde segment sorgulama işlemi gerçekleştirir.
        /// Bu yöntem, segment sorgulama parametrelerini alarak işlem sonucunu döner.
        /// </summary>
        /// <param name="segmentInquiryRequestDto">
        /// Segment sorgulama işlemi için gerekli olan parametreleri içeren bir <see cref="SegmentInquiryRequestDto"/> nesnesi.
        /// Bu nesne, sorgulama işlemiyle ilgili hesap, sipariş ve kart bilgilerini içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="SegmentInquiryResponseDto"/> nesnesi döner.
        /// Bu nesne, segment sorgulama işleminin sonucunu, başarı durumunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        public SegmentInquiryResponseDto SegmentInquiry(SegmentInquiryRequestDto segmentInquiryRequestDto)
        {
            try
            {
                // Segment sorgulama isteği için gerekli DTO'nun oluşturulması.
                var dto = new SegmentInquiryRequestDataDto
                {
                    Lang = segmentInquiryRequestDto?.Order?.Language,
                    Pan = segmentInquiryRequestDto?.Card?.CardNo,
                    Expiry = $"{segmentInquiryRequestDto?.Card?.ExpireMonth}{segmentInquiryRequestDto?.Card?.ExpireYear}",

                    MbrId = segmentInquiryRequestDto?.Account?.MbrId,
                    MerchantID = segmentInquiryRequestDto?.Account?.MerchantId,
                    UserCode = segmentInquiryRequestDto?.Account?.UserCode,
                    UserPass = segmentInquiryRequestDto?.Account?.UserPass,

                    SecureType = segmentInquiryRequestDto?.Account?.SecureType ?? SecureTypes.Inquiry,
                    TxnType = segmentInquiryRequestDto?.Account?.TxnType ?? TxnTypes.SegmentInquiry,
                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, segmentInquiryRequestDto?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    return new SegmentInquiryResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{segmentInquiryRequestDto?.Account?.TxnType} işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.SegmentInquiry, dto, response?.Content)
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<SegmentInquiryResponseDataDto>(response.Content);
                if (result == null)
                {
                    return new SegmentInquiryResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{segmentInquiryRequestDto?.Account?.TxnType} işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.SegmentInquiry, dto, response?.Content)
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result?.ProcReturnCode != Results.Approved)
                {
                    return new SegmentInquiryResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{segmentInquiryRequestDto?.Account?.TxnType} işlemi başarısız olmuştur. Hata Kodu: {result?.ProcReturnCode} | Hata Mesajı: {result?.ErrMsg}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.SegmentInquiry, dto, response?.Content)
                    };
                }

                return new SegmentInquiryResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{segmentInquiryRequestDto?.Account?.TxnType} işlemi başarılı."),
                    SegmentInquiryResponse = result,
                    ApiLog = SerializerHelper.ProcessData(MethodNames.SegmentInquiry, dto, response?.Content)
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new SegmentInquiryResponseDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{segmentInquiryRequestDto?.Account?.TxnType} işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde raporlama işlemi gerçekleştirir.
        /// Bu yöntem, raporlama parametrelerini alarak işlem sonucunu döner.
        /// </summary>
        /// <param name="reportRequest">
        /// Raporlama işlemi için gerekli olan parametreleri içeren bir <see cref="ReportRequestDto"/> nesnesi.
        /// Bu nesne, raporlama işlemiyle ilgili hesap, sipariş ve tarih bilgilerini içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="ReportResponseDto"/> nesnesi döner.
        /// Bu nesne, raporlama işleminin sonucunu, başarı durumunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        public ReportResponseDto Report(ReportRequestDto reportRequest)
        {
            try
            {
                long? requestStartTime = reportRequest?.RequestStartDatetime.HasValue == true ? ((DateTimeOffset)reportRequest.RequestStartDatetime.Value).ToUnixTimeSeconds() : null;

                string? requestDate = reportRequest?.RequestDate.HasValue == true ? reportRequest?.RequestDate?.ToString("yyyyMMdd") : null;

                // Rapor isteği için gerekli DTO'nun oluşturulması.
                var dto = new ReportRequestDataDto
                {
                    Lang = reportRequest?.Order?.Language,
                    OrderId = reportRequest?.Order?.OrderId,

                    ReqDate = requestDate,
                    RequestStartDatetime = requestStartTime,

                    MbrId = reportRequest?.Account?.MbrId,
                    MerchantId = reportRequest?.Account?.MerchantId,
                    UserCode = reportRequest?.Account?.UserCode,
                    UserPass = reportRequest?.Account?.UserPass,

                    SecureType = reportRequest?.Account?.SecureType ?? SecureTypes.Report,
                    TxnType = reportRequest?.Account?.TxnType ?? TxnTypes.TxnHistory,
                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, reportRequest?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    return new ReportResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{reportRequest?.Account?.TxnType} işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.Report, dto, response?.Content)
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<ReportResponseDataDto>(response.Content);
                if (result == null)
                {
                    return new ReportResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{reportRequest?.Account?.TxnType} işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.Report, dto, response?.Content)
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result?.PaymentRequestExtended?.PaymentRequest?.ProcReturnCode != Results.Approved)
                {
                    return new ReportResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{reportRequest?.Account?.TxnType} işlemi başarısız olmuştur. Hata Kodu: {result?.PaymentRequestExtended?.PaymentRequest?.ProcReturnCode} | Hata Mesajı: {result?.PaymentRequestExtended?.PaymentRequest?.ErrMsg}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.Report, dto, response?.Content)
                    };
                }

                return new ReportResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{reportRequest?.Account?.TxnType} işlemi başarılı."),
                    Report = result,
                    ApiLog = SerializerHelper.ProcessData(MethodNames.Report, dto, response?.Content)
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new ReportResponseDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{reportRequest?.Account?.TxnType} işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// QNB Finansbank Sanal Pos üzerinde EOD (End of Day) raporlama işlemi gerçekleştirir.
        /// Bu yöntem, EOD raporlama parametrelerini alarak işlem sonucunu döner.
        /// </summary>
        /// <param name="eodRequest">
        /// EOD raporlama işlemi için gerekli olan parametreleri içeren bir <see cref="EODRequestDto"/> nesnesi.
        /// Bu nesne, raporlama işlemiyle ilgili hesap, sipariş, başlangıç ve bitiş tarih bilgilerini içerebilir.
        /// </param>
        /// <returns>
        /// İşlemin sonucunu içeren bir <see cref="EODResponseDto"/> nesnesi döner.
        /// Bu nesne, EOD raporlama işleminin sonucunu, başarı durumunu, hata mesajlarını ve diğer ilgili bilgileri içerir.
        /// </returns>
        public EODResponseDto EOD(EODRequestDto eodRequest)
        {
            try
            {
                // EOD Rapor isteği için gerekli DTO'nun oluşturulması.
                var dto = new EODRequestDataDto
                {
                    Lang = eodRequest?.Order?.Language,
                    Currency = eodRequest?.Order?.Currency,
                    ReqDate = eodRequest?.StartDate?.ToString("yyyyMMdd"),
                    EndDate = eodRequest?.EndDate?.ToString("yyyyMMdd"),

                    MbrId = eodRequest?.Account?.MbrId,
                    MerchantID = eodRequest?.Account?.MerchantId,
                    UserCode = eodRequest?.Account?.UserCode,
                    UserPass = eodRequest?.Account?.UserPass,

                    SecureType = eodRequest?.Account?.SecureType ?? SecureTypes.Report,
                    TxnType = eodRequest?.Account?.TxnType ?? TxnTypes.EodDetail,
                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, eodRequest?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    return new EODResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{eodRequest?.Account?.TxnType} işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.EOD, dto, response?.Content)
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = JsonConvert.DeserializeObject<List<List<EODResponseDataDto>>>(response.Content);
                if (result == null)
                {
                    return new EODResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{eodRequest?.Account?.TxnType} işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.EOD, dto, response?.Content)
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.Count == 0)
                {
                    return new EODResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{eodRequest?.Account?.TxnType} işlemi başarısız olmuştur."),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.EOD, dto, response?.Content)
                    };
                }

                return new EODResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{eodRequest?.Account?.TxnType} işlemi başarılı."),
                    EOD = result,
                    ApiLog = SerializerHelper.ProcessData(MethodNames.EOD, dto, response?.Content)
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new EODResponseDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{eodRequest?.Account?.TxnType} işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// NonSecure ödeme işlemi gerçekleştirir.
        /// </summary>
        /// <param name="startPayment">Ödeme işlemi için gerekli olan tüm bilgileri içeren DTO nesnesi.</param>
        /// <returns>Ödeme işleminin sonucunu temsil eden <see cref="PaymentResponseDto"/> nesnesi.</returns>
        private static PaymentResponseDto NonSecurePayment(PaymentRequestDto startPayment)
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

                    SecureType = startPayment?.Account?.SecureType ?? SecureTypes.NonSecure,
                    TxnType = startPayment?.Account?.TxnType ?? TxnTypes.Auth,

                    Pan = startPayment?.Card?.CardNo,
                    Cvv2 = startPayment?.Card?.CVC,
                    Expiry = $"{startPayment?.Card?.ExpireMonth}{startPayment?.Card?.ExpireYear}",

                    PaymentFacilicator = new PaymentFacilicatorRequestDto
                    {
                        PaymentFacilitatorId = startPayment?.Submerchant?.SubMerchantFacilicatorId,
                        SubMerchantCode = startPayment?.Submerchant?.SubmerchantIdCode,
                        IndSalesOrgId = startPayment?.Order?.OrderId,
                        SubmerchantMCC = startPayment?.Submerchant?.SubMerchantMcc,
                        CardAcceptorName = startPayment?.Submerchant?.SubmerchantName,
                        CardAcceptorCity = startPayment?.Submerchant?.SubMerchantCity,
                        CardAcceptorPostalCode = startPayment?.Submerchant?.SubMerchantPostalCode,
                        CardAcceptorStreet = startPayment?.Submerchant?.SubMerchantCity,
                        CardAcceptorCountry = startPayment?.Submerchant?.SubMerchantCountry,
                        CardAcceptorState = startPayment?.Submerchant?.SubMerchantCity
                    }
                };

                var response = RestClientHelper.RestXmlExecuteHelper(dto, Method.Post, startPayment?.Account?.BaseUrl);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    return new PaymentResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{startPayment?.Account?.SecureType} ödeme işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}"),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.Payment, dto, response?.Content)
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<NonSecurePaymentResponseDto>(response.Content);
                if (result == null)
                {
                    return new PaymentResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{startPayment?.Account?.SecureType} ödeme işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                        Payment = ResponseHandler.GetPayment(startPayment?.Order?.OrderId),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.Payment, dto, response?.Content)
                    };
                }

                if (result.ProcReturnCode != Results.Approved)
                {
                    return new PaymentResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"{startPayment?.Account?.SecureType} ödeme işlemi başarısız olmuştur. Hata Kodu: {result?.ProcReturnCode} | Hata Mesajı: {result?.ErrMsg}"),
                        Payment = ResponseHandler.GetPayment(startPayment?.Order?.OrderId),
                        ApiLog = SerializerHelper.ProcessData(MethodNames.Payment, dto, response?.Content)
                    };
                }

                return new PaymentResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{startPayment?.Account?.SecureType} ödeme işlemi başarılı."),
                    Payment = ResponseHandler.GetPayment(startPayment?.Order?.OrderId),
                    ApiLog = SerializerHelper.ProcessData(MethodNames.Payment, dto, response?.Content)
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
        private static PaymentResponseDto ThreeDPayment(PaymentRequestDto? startPayment)
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
                    Expiry = $"{startPayment?.Card?.ExpireMonth}{startPayment?.Card?.ExpireYear}",

                    OkUrl = startPayment?.Order?.ReturnUrl,
                    FailUrl = startPayment?.Order?.ReturnUrl,
                    Rnd = startPayment?.Order?.Random,
                    Hash = hash,

                    //PaymentFacilicator = new PaymentFacilicatorRequestDto
                    //{
                    //    PaymentFacilitatorId = startPayment?.Submerchant?.SubMerchantFacilicatorId,
                    //    SubMerchantCode = startPayment?.Submerchant?.SubmerchantIdCode,
                    //    IndSalesOrgId = startPayment?.Order?.OrderId,
                    //    SubmerchantMCC = startPayment?.Submerchant?.SubMerchantMcc,
                    //    CardAcceptorName = startPayment?.Submerchant?.SubmerchantName,
                    //    CardAcceptorCity = startPayment?.Submerchant?.SubMerchantCity,
                    //    CardAcceptorPostalCode = startPayment?.Submerchant?.SubMerchantPostalCode,
                    //    CardAcceptorStreet = startPayment?.Submerchant?.SubMerchantCity,
                    //    CardAcceptorCountry = startPayment?.Submerchant?.SubMerchantCountry,
                    //    CardAcceptorState = startPayment?.Submerchant?.SubMerchantCity
                    //}
                };

                var collection = NameValueCollectionHelper.ToNameValueCollection(dto);

                string html = NameValueCollectionHelper.GenerateHtmlForm(collection, startPayment?.Account?.BaseUrl);

                return new PaymentResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"{startPayment?.Account?.SecureType} ödeme işlemi başarılı."),
                    Payment = ResponseHandler.GetPayment(startPayment?.Order?.OrderId, html),
                    ApiLog = SerializerHelper.ProcessData(MethodNames.Payment, dto, html)
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
