using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Response.Campaign.Usage
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinden gerçekleştirilen kampanya kullanım işleminin yanıtını temsil eder.
    /// Bu sınıf, işlem sonucuna dair çeşitli bilgileri içerir.
    /// </summary>
    [XmlRoot(ElementName = "PayforResponse")]
    public class CampaignUsageResponseDataDto : IDto
    {
        /// <summary>
        /// İşlem onay kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "AuthCode")]
        public string? AuthCode { get; set; }

        /// <summary>
        /// İşlem referans numarasını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "HostRefNum")]
        public string? HostRefNum { get; set; }

        /// <summary>
        /// İşlem sonucu geri dönüş kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "ProcReturnCode")]
        public string? ProcReturnCode { get; set; }

        /// <summary>
        /// İşlem kimliğini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "TransId")]
        public string? TransId { get; set; }

        /// <summary>
        /// Hata mesajını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "ErrMsg")]
        public string? ErrMsg { get; set; }

        /// <summary>
        /// Kart sahibinin adını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "CardHolderName")]
        public string? CardHolderName { get; set; }

        /// <summary>
        /// Ek taksit sayısını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "ArtiTaksit")]
        public string? ArtiTaksit { get; set; }

        /// <summary>
        /// Banka iç yanıt mesajını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseMessage")]
        public string? BankInternalResponseMessage { get; set; }

        /// <summary>
        /// Opsiyonel kampanyayı temsil eder.
        /// </summary>
        [XmlElement(ElementName = "OptionalCampaign")]
        public string? OptionalCampaign { get; set; }

        /// <summary>
        /// Seçmeli kampanya durumunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "SecmeliKampanyaDurumu")]
        public string? SecmeliKampanyaDurumu { get; set; }

        /// <summary>
        /// Öteleme kampanya kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "OtelemeKampanyaKodu")]
        public string? OtelemeKampanyaKodu { get; set; }

        /// <summary>
        /// Öteleme sayısını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "OtelemeSayisi")]
        public string? OtelemeSayisi { get; set; }

        /// <summary>
        /// Ek taksit kampanya kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "ArtiTaksitKampanyaKodu")]
        public string? ArtiTaksitKampanyaKodu { get; set; }

        /// <summary>
        /// Ek taksit sayısını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "ArtiTaksitSayisi")]
        public string? ArtiTaksitSayisi { get; set; }

        /// <summary>
        /// XML üzerinden gelen Payfor isteğini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "PAYFORFROMXMLREQUEST")]
        public string? PayforFromXMLRequest { get; set; }

        /// <summary>
        /// Oturum sistem kullanıcı bilgisini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "SESSION_SYSTEM_USER")]
        public string? SessionSystemUser { get; set; }
    }
}