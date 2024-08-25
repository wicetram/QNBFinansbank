using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Request.Campaign.Usage
{
    [XmlRoot(ElementName = "PayforRequest")]
    public class CampaignUsageRequestDataDto : IDto
    {
        [XmlElement(ElementName = "MbrId")]
        public string? MbrId { get; set; }

        [XmlElement(ElementName = "MerchantId")]
        public string? MerchantId { get; set; }

        [XmlElement(ElementName = "UserCode")]
        public string? UserCode { get; set; }

        [XmlElement(ElementName = "UserPass")]
        public string? UserPass { get; set; }

        [XmlElement(ElementName = "SecureType")]
        public string? SecureType { get; set; }

        [XmlElement(ElementName = "TxnType")]
        public string? TxnType { get; set; }

        [XmlElement(ElementName = "OrderId")]
        public string? OrderId { get; set; }

        [XmlElement(ElementName = "PurchAmount")]
        public string? PurchAmount { get; set; }

        [XmlElement(ElementName = "InstallmentCount")]
        public string? InstallmentCount { get; set; }

        [XmlElement(ElementName = "Pan")]
        public string? Pan { get; set; }

        [XmlElement(ElementName = "Expiry")]
        public string? Expiry { get; set; }

        [XmlElement(ElementName = "Cvv2")]
        public string? Cvv2 { get; set; }

        [XmlElement(ElementName = "MOTO")]
        public string? MOTO { get; set; }

        [XmlElement(ElementName = "OptionalCampaign")]
        public string? OptionalCampaign { get; set; }

        [XmlElement(ElementName = "SecmeliKampanyaDurumu")]
        public string? SecmeliKampanyaDurumu { get; set; }

        [XmlElement(ElementName = "OtelemeKampanyaKodu")]
        public string? OtelemeKampanyaKodu { get; set; }

        [XmlElement(ElementName = "OtelemeSayisi")]
        public string? OtelemeSayisi { get; set; }

        [XmlElement(ElementName = "ArtiTaksitKampanyaKodu")]
        public string? ArtiTaksitKampanyaKodu { get; set; }

        [XmlElement(ElementName = "ArtiTaksitSayisi")]
        public string? ArtiTaksitSayisi { get; set; }

        [XmlElement(ElementName = "Currency")]
        public string? Currency { get; set; }

        [XmlElement(ElementName = "Lang")]
        public string? Lang { get; set; }
    }
}
