using QNBFinansbank.VirtualPos.Entity.Request.Payment.NonSecure;

namespace QNBFinansbank.VirtualPos.Entity.Request.Payment.QR
{
    /// <summary>
    /// QR satış işlemi için gerekli olan parametreleri temsil eden DTO.
    /// Bu sınıf, QR ödeme işlemlerinde kullanılacak olan tüm parametreleri ve NonSecurePaymentRequestDto sınıfından miras alınan parametreleri içerir.
    /// QR satış işlemi yalnızca Non-Secure olarak yapılabilir.
    /// </summary>
    public class QRPaymentRequestDto : NonSecurePaymentRequestDto
    {
    }
}
