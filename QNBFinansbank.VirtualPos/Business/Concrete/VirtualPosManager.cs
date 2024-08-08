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
using QNBFinansbank.VirtualPos.Utility.Cryptography;
using QNBFinansbank.VirtualPos.Utility.ResponseHandlers;
using QNBFinansbank.VirtualPos.Utility.Serialization;
using RestSharp;
using System.Collections.Specialized;
using System.Text;

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
                };

                var collection = NameValueCollectionHelper.ToNameValueCollection(startPayment);

                string html = GenerateHtmlForm(collection, startPayment?.Account?.BaseUrl);

                return new PaymentResponseDto
                {
                    Result = ResponseHandler.GetResult(true, 10000, $"NonSecure ödeme işlemi başarılı."),
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
        /// Verilen NameValueCollection ve action URL'sine göre otomatik olarak submit eden bir HTML formu oluşturur.
        /// </summary>
        /// <param name="collection">Form alanlarını temsil eden NameValueCollection nesnesi.</param>
        /// <param name="actionUrl">Formun gönderileceği URL.</param>
        /// <returns>Otomatik olarak submit eden bir HTML formunu temsil eden string.</returns>
        private static string GenerateHtmlForm(NameValueCollection collection, string? actionUrl)
        {
            StringBuilder sb = new();
            sb.AppendLine("<html>");
            sb.AppendLine("<body onload='document.forms[\"paymentForm\"].submit()'>");
            sb.AppendLine($"<form name='paymentForm' action='{actionUrl}' method='post'>");

            var inputFields = collection.AllKeys
                                        .Select(key => $"<input type='hidden' name='{key}' value='{collection[key]}' />");

            sb.AppendLine(string.Join(Environment.NewLine, inputFields));

            sb.AppendLine("</form>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
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
                        Result = ResponseHandler.GetResult(false, 50000, $"NonSecure ödeme işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}")
                    };
                }

                var result = XmlHelper.DeserializeFromXml<NonSecurePaymentResponseDto>(response.Content);
                if (result == null)
                {
                    return new PaymentResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, 50000, $"NonSecure ödeme işlemi cevabı deserileştirilemediği için işlem başarısız olmuştur."),
                        Payment = ResponseHandler.GetPayment(startPayment?.Order?.OrderId)
                    };
                }

                if (result.ProcReturnCode != "00")
                {
                    return new PaymentResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, 50000, $"NonSecure ödeme işlemi başarısız olmuştur. Hata Kodu: {result.ProcReturnCode} | Hata Mesajı: {result.ErrMsg}"),
                        Payment = ResponseHandler.GetPayment(startPayment?.Order?.OrderId)
                    };
                }

                return new PaymentResponseDto
                {
                    Result = ResponseHandler.GetResult(true, 10000, $"NonSecure ödeme işlemi başarılı."),
                    Payment = ResponseHandler.GetPayment(startPayment?.Order?.OrderId)
                };
            }
            catch (Exception ex)
            {
                return new PaymentResponseDto
                {
                    Result = ResponseHandler.GetResult(false, 50000, $"NonSecure ödeme işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        public RefundResponseDataDto Refund(RefundRequestDataDto refund)
        {
            throw new NotImplementedException();
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
