using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Response.BatchClose
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinde toplu kapama (batch close) işleminin yanıt verilerini temsil eder.
    /// Bu sınıf, toplu kapama işlemi sırasında bankadan gelen yanıt verilerini içerir.
    /// </summary>
    [XmlRoot(ElementName = "PayforResponse")]
    public class BatchCloseResponseDto : IDto
    {
        /// <summary>
        /// İşlemin otorizasyon kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "AuthCode")]
        public string? AuthCode { get; set; }

        /// <summary>
        /// Banka referans numarasını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "HostRefNum")]
        public string? HostRefNum { get; set; }

        /// <summary>
        /// İşlemin cevap kodunu temsil eder. Başarılıysa "00" döner.
        /// </summary>
        [XmlElement(ElementName = "ProcReturnCode")]
        public string? ProcReturnCode { get; set; }

        /// <summary>
        /// İşlem kimliğini (transaction ID) temsil eder.
        /// </summary>
        [XmlElement(ElementName = "TransId")]
        public string? TransId { get; set; }

        /// <summary>
        /// İşlem sırasında oluşan hata mesajını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "ErrMsg")]
        public string? ErrMsg { get; set; }

        /// <summary>
        /// Kart sahibinin adını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "CardHolderName")]
        public string? CardHolderName { get; set; }

        /// <summary>
        /// Ek taksit bilgilerini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "ArtiTaksit")]
        public string? ArtiTaksit { get; set; }

        /// <summary>
        /// Banka iç yanıt mesajını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseMessage")]
        public string? BankInternalResponseMessage { get; set; }

        /// <summary>
        /// XML isteğinden gelen ödeme bilgilerini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "PAYFORFROMXMLREQUEST")]
        public string? PayForFromXMLRequest { get; set; }

        /// <summary>
        /// Oturum sistem kullanıcısını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "SESSION_SYSTEM_USER")]
        public string? SessionSystemUser { get; set; }
    }
}
