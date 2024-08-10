using QNBFinansbank.VirtualPos.Business.Abstract;
using QNBFinansbank.VirtualPos.Entity.Request;
using QNBFinansbank.VirtualPos.Entity.Request.Cancel;
using QNBFinansbank.VirtualPos.Entity.Request.Check;
using QNBFinansbank.VirtualPos.Entity.Request.Payment;
using QNBFinansbank.VirtualPos.Entity.Request.Payment.NonSecure;
using QNBFinansbank.VirtualPos.Entity.Request.Payment.ThreeD;
using QNBFinansbank.VirtualPos.Entity.Request.Refund;
using QNBFinansbank.VirtualPos.Entity.Response.Cancel;
using QNBFinansbank.VirtualPos.Entity.Response.Check;
using QNBFinansbank.VirtualPos.Entity.Response.Payment;
using QNBFinansbank.VirtualPos.Entity.Response.Payment.NonSecure;
using QNBFinansbank.VirtualPos.Entity.Response.Refund;
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
                        Result = ResponseHandler.GetResult(false, 50000, $"{cancel?.Account?.TxnType} işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}")
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<RefundResponseDto>(response.Content);
                if (result == null)
                {
                    return new CancelResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, 50000, $"{cancel?.Account?.TxnType} işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.ProcReturnCode != "00")
                {
                    return new CancelResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, 50000, $"{cancel?.Account?.TxnType} işlemi başarısız olmuştur. Hata Kodu: {result.ProcReturnCode} | Hata Mesajı: {result.ErrMsg}"),
                    };
                }

                return new CancelResponseDataDto
                {
                    Result = ResponseHandler.GetResult(true, 10000, $"{cancel?.Account?.TxnType} işlemi başarılı."),
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new CancelResponseDataDto
                {
                    Result = ResponseHandler.GetResult(false, 50000, $"{cancel?.Account?.TxnType} işlemi sırasında tanımsız hata. Hata: {ex.Message}")
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
                        Result = ResponseHandler.GetResult(false, 50000, $"{check?.Account?.TxnType} işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}")
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<CheckResponseDto>(response.Content);
                if (result == null)
                {
                    return new CheckResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, 50000, $"{check?.Account?.TxnType} işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.ProcReturnCode != "00")
                {
                    return new CheckResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, 50000, $"{check?.Account?.TxnType} işlemi başarısız olmuştur. Hata Kodu: {result.ProcReturnCode} | Hata Mesajı: {result.ErrMsg}"),
                        CheckResponse = result
                    };
                }

                return new CheckResponseDataDto
                {
                    Result = ResponseHandler.GetResult(true, 10000, $"{check?.Account?.TxnType} işlemi başarılı."),
                    CheckResponse = result
                };

            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new CheckResponseDataDto
                {
                    Result = ResponseHandler.GetResult(false, 50000, $"{check?.Account?.TxnType} işlemi sırasında tanımsız hata. Hata: {ex.Message}")
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
                    Result = ResponseHandler.GetResult(false, 50000, $"İşlem sırasında tanımsız hata. Hata: {ex.Message}")
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
                        Result = ResponseHandler.GetResult(false, 50000, $"{startPayment?.Account?.SecureType} ödeme işlemi başlatılmak istenmiştir, ancak hash değeri oluşturulamadığı için ödeme başlatılamamıştır.")
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
                    Result = ResponseHandler.GetResult(true, 10000, $"{startPayment?.Account?.SecureType} ödeme işlemi başarılı."),
                    Payment = ResponseHandler.GetPayment(startPayment?.Order?.OrderId, html)
                };
            }
            catch (Exception ex)
            {
                return new PaymentResponseDto
                {
                    Result = ResponseHandler.GetResult(false, 50000, $"{startPayment?.Account?.SecureType} ödeme işlemi sırasında tanımsız hata. Hata: {ex.Message}")
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

                if (!response.IsSuccessful && string.IsNullOrEmpty(response.Content))
                {
                    return new PaymentResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, 50000, $"{startPayment?.Account?.SecureType} ödeme işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}")
                    };
                }

                var result = XmlHelper.DeserializeFromXml<NonSecurePaymentResponseDto>(response.Content);
                if (result == null)
                {
                    return new PaymentResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, 50000, $"{startPayment?.Account?.SecureType} ödeme işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                        Payment = ResponseHandler.GetPayment(startPayment?.Order?.OrderId)
                    };
                }

                if (result.ProcReturnCode != "00")
                {
                    return new PaymentResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, 50000, $"{startPayment?.Account?.SecureType} ödeme işlemi başarısız olmuştur. Hata Kodu: {result.ProcReturnCode} | Hata Mesajı: {result.ErrMsg}"),
                        Payment = ResponseHandler.GetPayment(startPayment?.Order?.OrderId)
                    };
                }

                return new PaymentResponseDto
                {
                    Result = ResponseHandler.GetResult(true, 10000, $"{startPayment?.Account?.SecureType} ödeme işlemi başarılı."),
                    Payment = ResponseHandler.GetPayment(startPayment?.Order?.OrderId)
                };
            }
            catch (Exception ex)
            {
                return new PaymentResponseDto
                {
                    Result = ResponseHandler.GetResult(false, 50000, $"{startPayment?.Account?.SecureType} ödeme işlemi sırasında tanımsız hata. Hata: {ex.Message}")
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
                        Result = ResponseHandler.GetResult(false, 50000, $"{refund?.Account?.TxnType} işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}")
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<RefundResponseDto>(response.Content);
                if (result == null)
                {
                    return new RefundResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, 50000, $"{refund?.Account?.TxnType} işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.ProcReturnCode != "00")
                {
                    return new RefundResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, 50000, $"{refund?.Account?.TxnType} işlemi başarısız olmuştur. Hata Kodu: {result.ProcReturnCode} | Hata Mesajı: {result.ErrMsg}"),
                    };
                }

                return new RefundResponseDataDto
                {
                    Result = ResponseHandler.GetResult(true, 10000, $"{refund?.Account?.TxnType} işlemi başarılı."),
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new RefundResponseDataDto
                {
                    Result = ResponseHandler.GetResult(false, 50000, $"{refund?.Account?.TxnType} işlemi sırasında tanımsız hata. Hata: {ex.Message}")
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
