using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Response.Payment.NonSecure
{
    /// <summary>
    /// NonSecure satış işlemine ait yanıt parametrelerini temsil eden DTO.
    /// </summary>
    [XmlRoot(ElementName = "PayforResponse")]
    public class NonSecurePaymentResponseDto : IDto
    {
        /// <summary>
        /// Otorizasyon kodu. 
        /// İşlem onaylandığında verilen 6 haneli kod.
        /// </summary>
        [XmlElement(ElementName = "AuthCode")]
        public string? AuthCode { get; set; }

        /// <summary>
        /// Banka Referans Numarası. 
        /// İşlem için bankanın verdiği 19 haneli referans numarası.
        /// </summary>
        [XmlElement(ElementName = "HostRefNum")]
        public string? HostRefNum { get; set; }

        /// <summary>
        /// İşlemin Cevap Kodu. 
        /// İşlem başarılıysa "00" döner.
        /// </summary>
        [XmlElement(ElementName = "ProcReturnCode")]
        public string? ProcReturnCode { get; set; }

        /// <summary>
        /// İşlem ID'si. 
        /// İşlem için verilen 50 haneli benzersiz kimlik.
        /// </summary>
        [XmlElement(ElementName = "TransId")]
        public string? TransId { get; set; }

        /// <summary>
        /// Hata mesajı. 
        /// İşlem başarısız olduğunda verilen hata mesajı.
        /// </summary>
        [XmlElement(ElementName = "ErrMsg")]
        public string? ErrMsg { get; set; }

        /// <summary>
        /// Kart sahibinin adı. 
        /// İşlemde kullanılan kartın sahibinin adı.
        /// </summary>
        [XmlElement(ElementName = "CardHolderName")]
        public string? CardHolderName { get; set; }
    }
}
