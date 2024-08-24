using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Request.Report
{
    [XmlRoot(ElementName = "PayforRequest")]
    public class ReportRequestDataDto : IDto
    {
        [XmlElement(ElementName = "MbrId")]
        public string? MbrId { get; set; }

        [XmlElement(ElementName = "MerchantId")]
        public string? MerchantId { get; set; }

        [XmlElement(ElementName = "UserCode")]
        public string? UserCode { get; set; }

        [XmlElement(ElementName = "UserPass")]
        public string? UserPass { get; set; }

        [XmlElement(ElementName = "OrderId")]
        public string? OrderId { get; set; }

        [XmlElement(ElementName = "ReqDate")]
        public string? ReqDate { get; set; }

        [XmlElement(ElementName = "RequestStartDatetime")]
        public long? RequestStartDatetime { get; set; }

        [XmlElement(ElementName = "SecureType")]
        public string? SecureType { get; set; }

        [XmlElement(ElementName = "TxnType")]
        public string? TxnType { get; set; }

        [XmlElement(ElementName = "Lang")]
        public string? Lang { get; set; }
    }
}
