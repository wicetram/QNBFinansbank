using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Request.RewardPoints.Usage
{
    [XmlRoot(ElementName = "PayforRequest")]
    public class UseRewardPointsRequestDataDto : IDto
    {
        [XmlElement(ElementName = "MbrId")]
        public string? MbrId { get; set; }

        [XmlElement(ElementName = "MerchantID")]
        public string? MerchantID { get; set; }

        [XmlElement(ElementName = "UserCode")]
        public string? UserCode { get; set; }

        [XmlElement(ElementName = "UserPass")]
        public string? UserPass { get; set; }

        [XmlElement(ElementName = "OrderId")]
        public string? OrderId { get; set; }

        [XmlElement(ElementName = "SecureType")]
        public string? SecureType { get; set; }

        [XmlElement(ElementName = "TxnType")]
        public string? TxnType { get; set; }

        [XmlElement(ElementName = "PurchAmount")]
        public string? PurchAmount { get; set; }

        [XmlElement(ElementName = "BonusAmount")]
        public string? BonusAmount { get; set; }

        [XmlElement(ElementName = "Currency")]
        public string? Currency { get; set; }

        [XmlElement(ElementName = "Pan")]
        public string? Pan { get; set; }

        [XmlElement(ElementName = "Expiry")]
        public string? Expiry { get; set; }

        [XmlElement(ElementName = "Cvv2")]
        public string? Cvv2 { get; set; }

        [XmlElement(ElementName = "Lang")]
        public string? Lang { get; set; }
    }
}
