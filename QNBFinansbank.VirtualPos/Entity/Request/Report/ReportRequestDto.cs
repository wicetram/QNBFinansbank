namespace QNBFinansbank.VirtualPos.Entity.Request.Report
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinden raporlama işlemi için gerekli olan parametreleri temsil eder.
    /// Bu sınıf, hesap, sipariş ve tarih bilgilerini içeren alanları içerir.
    /// </summary>
    public class ReportRequestDto : IDto
    {
        /// <summary>
        /// Raporlama işlemi için gerekli olan hesap bilgilerini temsil eder.
        /// Bu alan, üye işyeri bilgileri ve güvenlik bilgilerini içerir.
        /// </summary>
        public AccountDto? Account { get; set; }

        /// <summary>
        /// Raporlama işlemi için gerekli olan sipariş bilgilerini temsil eder.
        /// Bu alan, işlemle ilgili sipariş numarası ve tutar gibi bilgileri içerir.
        /// </summary>
        public OrderDto? Order { get; set; }

        /// <summary>
        /// Raporlama işlemi için gerekli olan tarih bilgisini temsil eder.
        /// Bu alan, raporun alınacağı tarihi belirtir.
        /// </summary>
        public DateTime? RequestDate { get; set; }

        /// <summary>
        /// Raporlama işlemi için gerekli olan başlangıç zamanını temsil eder.
        /// Bu alan, raporlamanın başlayacağı zamanı belirtir.
        /// </summary>
        public DateTime? RequestStartDatetime { get; set; }
    }
}
