using System.Xml.Serialization;

namespace QNBFinansbank.CashManagement.Entity.Request
{
    [XmlRoot(ElementName = "Envelope", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class GetTransactionRequestDto : IDto
    {
        [XmlElement(ElementName = "Body", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
        public GetTransactionRequestBody? Body { get; set; }
    }

    [XmlRoot(ElementName = "Body", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class GetTransactionRequestBody
    {

        [XmlElement(ElementName = "getTransactionInfo", Namespace = "http://foyekstre.genericekstre.driver.maestro.ibtech.com")]
        public GetTransactionInfo? GetTransactionInfo { get; set; }
    }

    [XmlRoot(ElementName = "getTransactionInfo", Namespace = "http://foyekstre.genericekstre.driver.maestro.ibtech.com")]
    public class GetTransactionInfo
    {

        [XmlElement(ElementName = "transactionInfo", Namespace = "")]
        public TransactionInfoRequest? TransactionInfo { get; set; }
    }

    [XmlRoot(ElementName = "transactionInfo", Namespace = "")]
    public class TransactionInfoRequest
    {

        [XmlElement(ElementName = "password", Namespace = "")]
        public string? Password { get; set; }

        [XmlElement(ElementName = "transactionInfoInputType", Namespace = "")]
        public TransactionInfoInputType? TransactionInfoInputType { get; set; }

        [XmlElement(ElementName = "userName", Namespace = "")]
        public string? UserName { get; set; }
    }

    [XmlRoot(ElementName = "transactionInfoInputType", Namespace = "")]
    public class TransactionInfoInputType
    {

        [XmlElement(ElementName = "accountNo", Namespace = "")]
        public string? AccountNo { get; set; }

        [XmlElement(ElementName = "endDate", Namespace = "")]
        public string? EndDate { get; set; }

        [XmlElement(ElementName = "iban", Namespace = "")]
        public string? Iban { get; set; }

        [XmlElement(ElementName = "startDate", Namespace = "")]
        public string? StartDate { get; set; }
    }
}
