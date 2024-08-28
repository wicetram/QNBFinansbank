using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Response.RecurringPayment.Check
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinde tekrarlı ödeme kontrol işlemi sonucunda dönen verileri temsil eden DTO sınıfı.
    /// Bu sınıf, XML formatında gelen tekrarlı ödeme kontrol yanıtını içerir.
    /// </summary>
    [XmlRoot(ElementName = "PayforResponse")]
    public class CheckRecurringPaymentResponseDataDto : IDto
    {
        /// <summary>
        /// İşlem onay kodunu temsil eder. Bu kod, işlemin onaylandığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "AuthCode")]
        public string? AuthCode { get; set; }

        /// <summary>
        /// İşlem referans numarasını temsil eder. Bu numara, işlemle ilgili olarak bankanın sisteminde oluşturulan benzersiz referans numarasıdır.
        /// </summary>
        [XmlElement(ElementName = "HostRefNum")]
        public string? HostRefNum { get; set; }

        /// <summary>
        /// İşlem sonucu geri dönüş kodunu temsil eder. Bu kod, işlemin başarılı olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "ProcReturnCode")]
        public string? ProcReturnCode { get; set; }
    }
}