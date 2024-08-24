using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Response.Report
{
    [XmlRoot(ElementName = "TxnHistoryReport")]
    public class ReportResponseDataDto : IDto
    {
        [XmlElement(ElementName = "PaymentRequestExtended")]
        public PaymentRequestExtended? PaymentRequestExtended { get; set; }
    }

    [XmlRoot(ElementName = "PaymentRequestExtended")]
    public class PaymentRequestExtended
    {
        [XmlElement(ElementName = "PaymentRequest")]
        public PaymentRequest? PaymentRequest { get; set; }

        [XmlElement(ElementName = "ExtraParameters")]
        public ExtraParameters? ExtraParameters { get; set; }

        [XmlElement(ElementName = "IsOnUsCard")]
        public IsOnUsCard? IsOnUsCard { get; set; }
    }

    [XmlRoot(ElementName = "PaymentRequest")]
    public class PaymentRequest
    {
        [XmlElement(ElementName = "UseExistingDataWhenInserting")]
        public string? UseExistingDataWhenInserting { get; set; }

        [XmlElement(ElementName = "RequestGuid")]
        public string? RequestGuid { get; set; }

        [XmlElement(ElementName = "status")]
        public string? Status { get; set; }

        [XmlElement(ElementName = "InsertDatetime")]
        public string? InsertDatetime { get; set; }

        [XmlElement(ElementName = "lastUpdated")]
        public string? LastUpdated { get; set; }

        [XmlElement(ElementName = "MbrId")]
        public string? MbrId { get; set; }

        [XmlElement(ElementName = "MerchantID")]
        public string? MerchantID { get; set; }

        [XmlElement(ElementName = "OrderId")]
        public string? OrderId { get; set; }

        [XmlElement(ElementName = "PaymentSeq")]
        public string? PaymentSeq { get; set; }

        [XmlElement(ElementName = "RequestIp")]
        public string? RequestIp { get; set; }

        [XmlElement(ElementName = "RequestStat")]
        public string? RequestStat { get; set; }

        [XmlElement(ElementName = "RequestStartDatetime")]
        public string? RequestStartDatetime { get; set; }

        [XmlElement(ElementName = "MpiStartDatetime")]
        public string? MpiStartDatetime { get; set; }

        [XmlElement(ElementName = "MpiEndDatetime")]
        public string? MpiEndDatetime { get; set; }

        [XmlElement(ElementName = "PaymentStartDatetime")]
        public string? PaymentStartDatetime { get; set; }

        [XmlElement(ElementName = "PaymentEndDatetime")]
        public string? PaymentEndDatetime { get; set; }

        [XmlElement(ElementName = "RequestEndDatetime")]
        public string? RequestEndDatetime { get; set; }

        [XmlElement(ElementName = "Pan")]
        public string? Pan { get; set; }

        [XmlElement(ElementName = "Expiry")]
        public string? Expiry { get; set; }

        [XmlElement(ElementName = "SecureType")]
        public string? SecureType { get; set; }

        [XmlElement(ElementName = "PurchAmount")]
        public string? PurchAmount { get; set; }

        [XmlElement(ElementName = "TxnAmount")]
        public DateTime TxnAmount { get; set; }

        [XmlElement(ElementName = "Exponent")]
        public string? Exponent { get; set; }

        [XmlElement(ElementName = "Currency")]
        public string? Currency { get; set; }

        [XmlElement(ElementName = "UserCode")]
        public string? UserCode { get; set; }

        [XmlElement(ElementName = "Description")]
        public string? Description { get; set; }

        [XmlElement(ElementName = "OkUrl")]
        public string? OkUrl { get; set; }

        [XmlElement(ElementName = "FailUrl")]
        public string? FailUrl { get; set; }

        [XmlElement(ElementName = "PayerTxnId")]
        public string? PayerTxnId { get; set; }

        [XmlElement(ElementName = "PayerAuthenticationCode")]
        public string? PayerAuthenticationCode { get; set; }

        [XmlElement(ElementName = "Eci")]
        public string? Eci { get; set; }

        [XmlElement(ElementName = "MD")]
        public string? MD { get; set; }

        [XmlElement(ElementName = "Hash")]
        public string? Hash { get; set; }

        [XmlElement(ElementName = "TerminalID")]
        public string? TerminalID { get; set; }

        [XmlElement(ElementName = "TxnType")]
        public string? TxnType { get; set; }

        [XmlElement(ElementName = "TerminalTxnType")]
        public string? TerminalTxnType { get; set; }

        [XmlElement(ElementName = "MOTO")]
        public string? MOTO { get; set; }

        [XmlElement(ElementName = "OrgOrderId")]
        public string? OrgOrderId { get; set; }

        [XmlElement(ElementName = "SubMerchantCode")]
        public string? SubMerchantCode { get; set; }

        [XmlElement(ElementName = "recur_frequency")]
        public string? RecurFrequency { get; set; }

        [XmlElement(ElementName = "recur_expiry")]
        public string? RecurExpiry { get; set; }

        [XmlElement(ElementName = "CardType")]
        public string? CardType { get; set; }

        [XmlElement(ElementName = "Lang")]
        public string? Lang { get; set; }

        [XmlElement(ElementName = "Expsign")]
        public string? Expsign { get; set; }

        [XmlElement(ElementName = "BonusAmount")]
        public string? BonusAmount { get; set; }

        [XmlElement(ElementName = "InstallmentCount")]
        public string? InstallmentCount { get; set; }

        [XmlElement(ElementName = "Rnd")]
        public string? Rnd { get; set; }

        [XmlElement(ElementName = "AlphaCode")]
        public string? AlphaCode { get; set; }

        [XmlElement(ElementName = "Ecommerce")]
        public string? Ecommerce { get; set; }

        [XmlElement(ElementName = "Accept")]
        public string? Accept { get; set; }

        [XmlElement(ElementName = "Agent")]
        public string? Agent { get; set; }

        [XmlElement(ElementName = "MrcCountryCode")]
        public string? MrcCountryCode { get; set; }

        [XmlElement(ElementName = "MrcName")]
        public string? MrcName { get; set; }

        [XmlElement(ElementName = "MerchantHomeUrl")]
        public string? MerchantHomeUrl { get; set; }

        [XmlElement(ElementName = "CardHolderName")]
        public string? CardHolderName { get; set; }

        [XmlElement(ElementName = "IrcDet")]
        public string? IrcDet { get; set; }

        [XmlElement(ElementName = "IrcCode")]
        public string? IrcCode { get; set; }

        [XmlElement(ElementName = "Version")]
        public string? Version { get; set; }

        [XmlElement(ElementName = "TxnStatus")]
        public string? TxnStatus { get; set; }

        [XmlElement(ElementName = "CavvAlg")]
        public string? CavvAlg { get; set; }

        [XmlElement(ElementName = "ParesVerified")]
        public string? ParesVerified { get; set; }

        [XmlElement(ElementName = "ParesSyntaxOk")]
        public string? ParesSyntaxOk { get; set; }

        [XmlElement(ElementName = "ErrMsg")]
        public string? ErrMsg { get; set; }

        [XmlElement(ElementName = "VendorDet")]
        public string? VendorDet { get; set; }

        [XmlElement(ElementName = "D3Stat")]
        public string? D3Stat { get; set; }

        [XmlElement(ElementName = "TxnResult")]
        public string? TxnResult { get; set; }

        [XmlElement(ElementName = "AuthCode")]
        public string? AuthCode { get; set; }

        [XmlElement(ElementName = "HostRefNum")]
        public string? HostRefNum { get; set; }

        [XmlElement(ElementName = "ProcReturnCode")]
        public string? ProcReturnCode { get; set; }

        [XmlElement(ElementName = "ReturnUrl")]
        public string? ReturnUrl { get; set; }

        [XmlElement(ElementName = "ErrorData")]
        public string? ErrorData { get; set; }

        [XmlElement(ElementName = "BatchNo")]
        public string? BatchNo { get; set; }

        [XmlElement(ElementName = "VoidDate")]
        public string? VoidDate { get; set; }

        [XmlElement(ElementName = "CardMask")]
        public string? CardMask { get; set; }

        [XmlElement(ElementName = "ReqId")]
        public string? ReqId { get; set; }

        [XmlElement(ElementName = "UsedPoint")]
        public string? UsedPoint { get; set; }

        [XmlElement(ElementName = "SrcType")]
        public string? SrcType { get; set; }

        [XmlElement(ElementName = "RefundedAmount")]
        public string? RefundedAmount { get; set; }

        [XmlElement(ElementName = "RefundedPoint")]
        public string? RefundedPoint { get; set; }

        [XmlElement(ElementName = "ReqDate")]
        public string? ReqDate { get; set; }

        [XmlElement(ElementName = "SysDate")]
        public string? SysDate { get; set; }

        [XmlElement(ElementName = "F11")]
        public string? F11 { get; set; }

        [XmlElement(ElementName = "F37")]
        public string? F37 { get; set; }

        [XmlElement(ElementName = "F37_ORG")]
        public string? F37ORG { get; set; }

        [XmlElement(ElementName = "Mti")]
        public string? Mti { get; set; }

        [XmlElement(ElementName = "Pcode")]
        public string? Pcode { get; set; }

        [XmlElement(ElementName = "F12")]
        public string? F12 { get; set; }

        [XmlElement(ElementName = "F13")]
        public string? F13 { get; set; }

        [XmlElement(ElementName = "F22")]
        public string? F22 { get; set; }

        [XmlElement(ElementName = "F25")]
        public string? F25 { get; set; }

        [XmlElement(ElementName = "F32")]
        public string? F32 { get; set; }

        [XmlElement(ElementName = "IsRepeatTxn")]
        public string? IsRepeatTxn { get; set; }

        [XmlElement(ElementName = "CavvResult")]
        public string? CavvResult { get; set; }

        [XmlElement(ElementName = "VposElapsedTime")]
        public string? VposElapsedTime { get; set; }

        [XmlElement(ElementName = "BankingElapsedTime")]
        public string? BankingElapsedTime { get; set; }

        [XmlElement(ElementName = "SocketElapsedTime")]
        public string? SocketElapsedTime { get; set; }

        [XmlElement(ElementName = "HsmElapsedTime")]
        public string? HsmElapsedTime { get; set; }

        [XmlElement(ElementName = "MpiElapsedTime")]
        public string? MpiElapsedTime { get; set; }

        [XmlElement(ElementName = "hasOrderId")]
        public string? HasOrderId { get; set; }

        [XmlElement(ElementName = "TemplateType")]
        public string? TemplateType { get; set; }

        [XmlElement(ElementName = "HasAddressCount")]
        public string? HasAddressCount { get; set; }

        [XmlElement(ElementName = "IsPaymentFacilitator")]
        public string? IsPaymentFacilitator { get; set; }

        [XmlElement(ElementName = "OrgTxnType")]
        public string? OrgTxnType { get; set; }

        [XmlElement(ElementName = "F11_ORG")]
        public string? F11ORG { get; set; }

        [XmlElement(ElementName = "F12_ORG")]
        public string? F12ORG { get; set; }

        [XmlElement(ElementName = "F13_ORG")]
        public string? F13ORG { get; set; }

        [XmlElement(ElementName = "F22_ORG")]
        public string? F22ORG { get; set; }

        [XmlElement(ElementName = "F25_ORG")]
        public string? F25ORG { get; set; }

        [XmlElement(ElementName = "MTI_ORG")]
        public string? MTIORG { get; set; }

        [XmlElement(ElementName = "DsBrand")]
        public string? DsBrand { get; set; }

        [XmlElement(ElementName = "IntervalType")]
        public string? IntervalType { get; set; }

        [XmlElement(ElementName = "IntervalDuration")]
        public string? IntervalDuration { get; set; }

        [XmlElement(ElementName = "RepeatCount")]
        public string? RepeatCount { get; set; }

        [XmlElement(ElementName = "CustomerCode")]
        public string? CustomerCode { get; set; }

        [XmlElement(ElementName = "RequestMerchantDomain")]
        public string? RequestMerchantDomain { get; set; }

        [XmlElement(ElementName = "RequestClientIp")]
        public string? RequestClientIp { get; set; }

        [XmlElement(ElementName = "ResponseRnd")]
        public string? ResponseRnd { get; set; }

        [XmlElement(ElementName = "ResponseHash")]
        public string? ResponseHash { get; set; }

        [XmlElement(ElementName = "BankSpecificRequest")]
        public string? BankSpecificRequest { get; set; }

        [XmlElement(ElementName = "BankInternalResponseCode")]
        public string? BankInternalResponseCode { get; set; }

        [XmlElement(ElementName = "BankInternalResponseMessage")]
        public string? BankInternalResponseMessage { get; set; }

        [XmlElement(ElementName = "BankInternalResponseSubcode")]
        public string? BankInternalResponseSubcode { get; set; }

        [XmlElement(ElementName = "BankInternalResponseSubmessage")]
        public string? BankInternalResponseSubmessage { get; set; }

        [XmlElement(ElementName = "BayiKodu")]
        public string? BayiKodu { get; set; }

        [XmlElement(ElementName = "VoidTime")]
        public string? VoidTime { get; set; }

        [XmlElement(ElementName = "VoidUserCode")]
        public string? VoidUserCode { get; set; }

        [XmlElement(ElementName = "PaymentLinkId")]
        public string? PaymentLinkId { get; set; }

        [XmlElement(ElementName = "ClientId")]
        public string? ClientId { get; set; }

        [XmlElement(ElementName = "IsQR")]
        public string? IsQR { get; set; }

        [XmlElement(ElementName = "IsFast")]
        public string? IsFast { get; set; }

        [XmlElement(ElementName = "QRRefNo")]
        public string? QRRefNo { get; set; }

        [XmlElement(ElementName = "FASTGonderenKatilimciKodu")]
        public string? FASTGonderenKatilimciKodu { get; set; }

        [XmlElement(ElementName = "FASTAlanKatilimciKodu")]
        public string? FASTAlanKatilimciKodu { get; set; }

        [XmlElement(ElementName = "FASTReferansNo")]
        public string? FASTReferansNo { get; set; }

        [XmlElement(ElementName = "FastGonderenIBAN")]
        public string? FastGonderenIBAN { get; set; }

        [XmlElement(ElementName = "FASTGonderenAdi")]
        public string? FASTGonderenAdi { get; set; }

        [XmlElement(ElementName = "MobileECI")]
        public string? MobileECI { get; set; }

        [XmlElement(ElementName = "HubConnId")]
        public string? HubConnId { get; set; }

        [XmlElement(ElementName = "WalletData")]
        public string? WalletData { get; set; }

        [XmlElement(ElementName = "Tds2dsTransId")]
        public string? Tds2dsTransId { get; set; }

        [XmlElement(ElementName = "Is3DHost")]
        public string? Is3DHost { get; set; }

        [XmlElement(ElementName = "ArtiTaksit")]
        public string? ArtiTaksit { get; set; }

        [XmlElement(ElementName = "AuthId")]
        public string? AuthId { get; set; }

        [XmlAttribute(AttributeName = "xmlns")]
        public string? Xmlns { get; set; }

        [XmlText]
        public string? Text { get; set; }
    }

    [XmlRoot(ElementName = "IsOnUsCard")]
    public class IsOnUsCard
    {
        [XmlAttribute(AttributeName = "xmlns")]
        public string? Xmlns { get; set; }

        [XmlText]
        public string? Text { get; set; }
    }

    [XmlRoot(ElementName = "ExtraParameters")]
    public class ExtraParameters
    {
        [XmlElement(ElementName = "ArrayOfString")]
        public List<ArrayOfString>? ArrayOfString { get; set; }
    }

    [XmlRoot(ElementName = "ArrayOfString")]
    public class ArrayOfString
    {
        [XmlElement(ElementName = "string")]
        public List<string>? String { get; set; }
    }
}
