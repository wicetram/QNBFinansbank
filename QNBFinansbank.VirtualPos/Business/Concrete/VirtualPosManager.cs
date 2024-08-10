using QNBFinansbank.VirtualPos.Business.Abstract;
using QNBFinansbank.VirtualPos.Constant;
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
using QNBFinansbank.VirtualPos.Utility.Cryptography;
using QNBFinansbank.VirtualPos.Utility.ResponseHandlers;
using QNBFinansbank.VirtualPos.Utility.Serialization;
using RestSharp;

namespace QNBFinansbank.VirtualPos.Business.Concrete
{
    public class VirtualPosManager : IVirtualPosService
    {
        public CancelResponseDataDto Cancel(CancelRequestDataDto cancel)
        {
            throw new NotImplementedException();
        }

        public CheckResponseDataDto Check(CheckRequestDataDto check)
        {
            throw new NotImplementedException();
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

                string body = XmlHelper.SerializeToXml(dto);

                var request = new RestRequest { Method = Method.Post };
                request.AddHeader("Content-Type", "application/xml");
                request.AddXmlBody(dto, ContentType.Xml);

                var client = new RestClient($"{startPayment?.Account?.BaseUrl}");
                var response = client.Execute(request);

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

                // DTO'nun XML formatında serileştirilmesi.
                string body = XmlHelper.SerializeToXml(dto);

                var request = new RestRequest { Method = Method.Post };
                request.AddHeader("Content-Type", "application/xml");
                request.AddXmlBody(dto, ContentType.Xml);

                // API'ye gönderilecek olan REST istemcisinin oluşturulması.
                var client = new RestClient($"{refund?.Account?.BaseUrl}");
                var response = client.Execute(request);

                // Yanıtın başarı durumuna göre işlem sonucunun döndürülmesi.
                if (!response.IsSuccessful && string.IsNullOrEmpty(response.Content))
                {
                    return new RefundResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, 50000, $"{refund?.Account?.SecureType} işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}")
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = XmlHelper.DeserializeFromXml<RefundResponseDto>(response.Content);
                if (result == null)
                {
                    return new RefundResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, 50000, $"{refund?.Account?.SecureType} işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                    };
                }

                // İşlemin başarı koduna göre sonuç döndürülmesi.
                if (result.ProcReturnCode != "00")
                {
                    return new RefundResponseDataDto
                    {
                        Result = ResponseHandler.GetResult(false, 50000, $"{refund?.Account?.SecureType} işlemi başarısız olmuştur. Hata Kodu: {result.ProcReturnCode} | Hata Mesajı: {result.ErrMsg}"),
                    };
                }

                return new RefundResponseDataDto
                {
                    Result = ResponseHandler.GetResult(true, 10000, $"{refund?.Account?.SecureType} işlemi başarılı."),
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new RefundResponseDataDto
                {
                    Result = ResponseHandler.GetResult(false, 50000, $"{refund?.Account?.SecureType} işlemi sırasında tanımsız hata. Hata: {ex.Message}")
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
