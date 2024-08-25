namespace QNBFinansbank.VirtualPos.Entity.Request.EOD
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinde EOD (End of Day) rapor isteği için gerekli olan hesap bilgilerini temsil eder.
    /// Bu sınıf, EOD raporu oluşturmak için kullanılacak üye işyeri ve kullanıcı bilgilerini içerir.
    /// </summary>
    public class EODRequestDto : IDto
    {
        /// <summary>
        /// EOD rapor isteği için gerekli olan hesap bilgilerini temsil eder.
        /// Bu alan, üye işyeri bilgileri, kullanıcı kodu ve şifre gibi bilgileri içerir.
        /// </summary>
        public AccountDto? Account { get; set; }

        /// <summary>
        /// EOD rapor işlemi için gerekli olan sipariş bilgilerini temsil eder.
        /// Bu alan, işlemle ilgili sipariş numarası ve tutar gibi bilgileri içerir.
        /// </summary>
        public OrderDto? Order { get; set; }

        /// <summary>
        /// EOD rapor işlemi için sorgulanacak işlem başlangıç tarihidir.
        /// Bu alan, işlemle ilgili sorgu başlangıç tarihini içerir.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// EOD rapor işlemi için sorgulanacak işlem bitiş tarihidir.
        /// Bu alan, işlemle ilgili sorgu bitiş tarihini içerir.
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}