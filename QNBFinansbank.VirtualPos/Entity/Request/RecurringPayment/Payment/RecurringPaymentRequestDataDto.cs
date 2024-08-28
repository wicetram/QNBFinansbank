using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Request.RecurringPayment.Payment
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinde tekrarlı ödeme işlemi için gerekli verileri temsil eder.
    /// Bu sınıf, XML formatında gönderilecek olan tekrarlı ödeme talebini oluşturur.
    /// </summary>
    [XmlRoot(ElementName = "PayforRequest")]
    public class RecurringPaymentRequestDataDto : IDto
    {
        /// <summary>
        /// Üye işyeri kimliğini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "MbrId")]
        public string? MbrId { get; set; }

        /// <summary>
        /// İşlemi gerçekleştiren satıcının kimliğini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "MerchantId")]
        public string? MerchantId { get; set; }

        /// <summary>
        /// Kullanıcının kimliğini veya kullanıcı adını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "UserCode")]
        public string? UserCode { get; set; }

        /// <summary>
        /// Kullanıcının şifresini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "UserPass")]
        public string? UserPass { get; set; }

        /// <summary>
        /// İşlem türünü belirtir. Bu durumda, "RECURRINGPAYMENT" değeri kullanılır.
        /// </summary>
        [XmlElement(ElementName = "RequestType")]
        public string? RequestType { get; set; }

        /// <summary>
        /// Ödeme işlemi için kullanılan kart numarasını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "Pan")]
        public string? Pan { get; set; }

        /// <summary>
        /// Kartın son kullanma tarihini YYMM formatında belirtir.
        /// </summary>
        [XmlElement(ElementName = "Expiry")]
        public string? Expiry { get; set; }

        /// <summary>
        /// İşlemin yapılacağı para birimini temsil eder. (Örn: 949 = Türk Lirası)
        /// </summary>
        [XmlElement(ElementName = "Currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// Satın alma tutarını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "PurchAmount")]
        public string? PurchAmount { get; set; }

        /// <summary>
        /// İşlemle ilgili açıklama veya referans bilgisini belirtir.
        /// </summary>
        [XmlElement(ElementName = "Description")]
        public string? Description { get; set; }

        /// <summary>
        /// İşlemin hangi dilde yapılacağını belirtir. (Örn: "TR" = Türkçe)
        /// </summary>
        [XmlElement(ElementName = "Lang")]
        public string? Lang { get; set; }

        /// <summary>
        /// Satıcının işlem için atadığı benzersiz sipariş kimliğini belirtir.
        /// </summary>
        [XmlElement(ElementName = "MrcOrderId")]
        public string? MrcOrderId { get; set; }

        /// <summary>
        /// Taksit sayısını belirtir. Eğer taksitli ödeme yapılacaksa kullanılır.
        /// </summary>
        [XmlElement(ElementName = "InstallmentCount")]
        public string? InstallmentCount { get; set; }

        /// <summary>
        /// Tekrarlı ödeme işleminin başlayacağı tarihi YYMMDD formatında belirtir.
        /// </summary>
        [XmlElement(ElementName = "StartDate")]
        public string? StartDate { get; set; }

        /// <summary>
        /// Ödemelerin hangi sıklıkla yapılacağını belirtir. (Örn: Günlük, Haftalık, Aylık, Yıllık)
        /// </summary>
        [XmlElement(ElementName = "IntervalType")]
        public int? IntervalType { get; set; }

        /// <summary>
        /// IntervalType ile belirtilen aralığın kaç birim süreceğini belirtir.
        /// </summary>
        [XmlElement(ElementName = "IntervalDuration")]
        public int? IntervalDuration { get; set; } = 1;

        /// <summary>
        /// Tekrarlı ödeme işleminin kaç kez tekrarlanacağını belirtir.
        /// </summary>
        [XmlElement(ElementName = "RepeatCount")]
        public int? RepeatCount { get; set; } = 12;

        /// <summary>
        /// Ödeme işlemi yapılan kart sahibinin adını belirtir.
        /// </summary>
        [XmlElement(ElementName = "CardHolderName")]
        public string? CardHolderName { get; set; }
    }
}
