namespace QNBFinansbank.VirtualPos.Entity.Request
{
    public class OrderDto : IDto
    {
        /// <summary>
        /// Taksit sayısı. 
        /// Bu özellik, ödeme işlemi için belirlenen taksit sayısını belirtir. Örneğin, "1" (peşin ödeme) veya "3" (3 taksit) gibi değerler alabilir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? Installment { get; set; }

        /// <summary>
        /// Kur bilgisi. 
        /// Bu özellik, ödeme işleminin gerçekleştirileceği para birimini belirtir. Örneğin, "949" (Türk Lirası), "840 " (Amerikan Doları) gibi değerler alabilir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? Currency { get; set; }

        /// <summary>
        /// İşlem sonrası kullanıcının geri döneceği site. 
        /// Bu URL, ödeme işlemi tamamlandığında kullanıcının yönlendirileceği geri dönüş adresidir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? ReturnUrl { get; set; }

        /// <summary>
        /// İşleme özgü numara. 
        /// Bu numara, her bir ödeme işlemi için benzersiz bir tanımlayıcıdır ve işlemi takip etmek için kullanılır.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? OrderId { get; set; }

        /// <summary>
        /// İşlemin tutarı. 
        /// Bu özellik, ödeme miktarını belirtir. Kuruş ayraç operatörü olarak (.) kullanılmalı ve kuruş hanesi 2 karakter olmalıdır. 
        /// Örneğin, "100.50" (100 Türk Lirası 50 kuruş) gibi.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? Amount { get; set; }

        /// <summary>
        /// İşlemin ödül tutarı. 
        /// Bu özellik, ödeme miktarında kullanılacak olan ödül tutarını belirtir. Kuruş ayraç operatörü olarak (.) kullanılmalı ve kuruş hanesi 2 karakter olmalıdır. 
        /// Örneğin, "100.50" (100 Türk Lirası 50 kuruş) gibi.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? BonusAmount { get; set; }

        /// <summary>
        /// Dil bilgisi. 
        /// Bu özellik, ödeme işlemi sırasında kullanılacak dili belirtir. Örneğin, "tr" (Türkçe), "en" (İngilizce) gibi değerler alabilir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// İşlemin güvenlik tipi. 
        /// Bu özellik, ödeme işleminin güvenlik seviyesini belirtir. Örneğin, <c>false</c> (NonSecure), <c>true</c> (3D Secure) gibi değerler alabilir.
        /// Varsayılan değeri <c>true</c> olarak ayarlıdır.
        /// </summary>
        public bool PaymentSecurity { get; set; } = true;

        /// <summary>
        /// Rastgele değer. 
        /// Bu özellik, işlemle ilgili rastgele bir değer içerir ve genellikle güvenlik amacıyla kullanılır.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? Random { get; set; }
    }
}
