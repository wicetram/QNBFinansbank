using QNBFinansbank.VirtualPos.Business.Abstract;
using QNBFinansbank.VirtualPos.Entity.Request;
using QNBFinansbank.VirtualPos.Entity.Request.Cancel;
using QNBFinansbank.VirtualPos.Entity.Request.Check;
using QNBFinansbank.VirtualPos.Entity.Request.Payment;
using QNBFinansbank.VirtualPos.Entity.Request.Payment.NonSecure;
using QNBFinansbank.VirtualPos.Entity.Request.Refund;
using QNBFinansbank.VirtualPos.Entity.Response.Cancel;
using QNBFinansbank.VirtualPos.Entity.Response.Check;
using QNBFinansbank.VirtualPos.Entity.Response.Payment;
using QNBFinansbank.VirtualPos.Entity.Response.Payment.NonSecure;
using QNBFinansbank.VirtualPos.Entity.Response.Refund;
using QNBFinansbank.VirtualPos.Utilities;
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

        private PaymentResponseDto ThreeDPayment(PaymentRequestDataDto? startPayment)
        {
            throw new NotImplementedException();
        }

        private PaymentResponseDto NonSecurePayment(PaymentRequestDataDto startPayment)
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

                string body = XMLManager.SerializeToXml(dto);

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

                var result = XMLManager.DeserializeFromXml<NonSecurePaymentResponseDto>(response.Content);
                if (result == null)
                {
                    return new PaymentResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, 50000, $"NonSecure ödeme işlemi cevabı deserileştirilemediği işlem başarısız olmuştur."),
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

        private static string Hash(AccountDto? account, OrderDto? order)
        {
            //MbrId + MrcOrderId + PurchAmount + OkUrl + FailUrl + TxnType + InstallmentCount + Rnd + MerchantPass
            string hashString = $"{account?.MbrId}{order?.OrderId}{order?.Amount}{order?.ReturnUrl}{order?.ReturnUrl}{account?.TxnType}{order?.Installment}{order?.Random}{account?.MerchantPass}";
            string hash = CryptoManager.SHA1Encryption(hashString);
            return hash;
        }
    }
}
