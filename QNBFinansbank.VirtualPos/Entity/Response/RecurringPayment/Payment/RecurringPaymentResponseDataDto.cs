using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Response.RecurringPayment.Payment
{
    [XmlRoot(ElementName = "PayforResponse")]
    public class RecurringPaymentResponseDataDto : IDto
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
    }
}
