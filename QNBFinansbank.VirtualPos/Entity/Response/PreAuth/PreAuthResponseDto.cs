using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Response.PreAuth
{
    [XmlRoot(ElementName = "PayforResponse")]
    public class PreAuthResponseDto : IDto
    {
        [XmlElement(ElementName = "AuthCode")]
        public string? AuthCode { get; set; }

        [XmlElement(ElementName = "HostRefNum")]
        public string? HostRefNum { get; set; }

        [XmlElement(ElementName = "ProcReturnCode")]
        public string? ProcReturnCode { get; set; }

        [XmlElement(ElementName = "TransId")]
        public string? TransId { get; set; }

        [XmlElement(ElementName = "ErrMsg")]
        public string? ErrMsg { get; set; }

        [XmlElement(ElementName = "CardHolderName")]
        public string? CardHolderName { get; set; }

        [XmlElement(ElementName = "ArtiTaksit")]
        public string? ArtiTaksit { get; set; }

        [XmlElement(ElementName = "BankInternalResponseMessage")]
        public string? BankInternalResponseMessage { get; set; }
    }
}
