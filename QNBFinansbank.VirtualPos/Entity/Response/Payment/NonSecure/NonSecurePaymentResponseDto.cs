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

        /// <summary>
        /// Ekstra taksit sayısı. 
        /// İşlem sırasında kullanılan ekstra taksit sayısı.
        /// </summary>
        [XmlElement(ElementName = "ArtiTaksit")]
        public string? ArtiTaksit { get; set; }

        /// <summary>
        /// Bankanın iç yanıt mesajı. 
        /// Banka tarafından verilen işlemle ilgili ek bilgi içeren mesaj.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseMessage")]
        public string? BankInternalResponseMessage { get; set; }

        /// <summary>
        /// Payfor XML istek verisi. 
        /// İşlem sırasında kullanılan orijinal XML istek verisi.
        /// </summary>
        [XmlElement(ElementName = "PAYFORFROMXMLREQUEST")]
        public string? PayForFromXMLRequest { get; set; }

        /// <summary>
        /// Sistem kullanıcı kodu. 
        /// İşlemi gerçekleştiren sistem kullanıcısının kodu.
        /// </summary>
        [XmlElement(ElementName = "SESSION_SYSTEM_USER")]
        public string? SessionSystemUser { get; set; }
    }
}
