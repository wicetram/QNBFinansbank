namespace QNBFinansbank.VirtualPos.Entity.Response
{
    public class PaymentData : IDto
    {
        /// <summary>
        /// Ödeme işlemi ile ilişkili siparişin benzersiz tanımlayıcısı.
        /// Bu ID, siparişi sistemde tanımlamak ve takip etmek için kullanılır.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Ödeme işlemi ile ilişkili URL adresi.
        /// Bu URL, ödeme sayfasına yönlendirmek veya erişim sağlamak için kullanılabilir.
        /// Varsayılan değer olarak <c>null</c> olabilir, bu durumda URL mevcut olmayabilir.
        /// </summary>
        public string? URL { get; set; }
    }
}
