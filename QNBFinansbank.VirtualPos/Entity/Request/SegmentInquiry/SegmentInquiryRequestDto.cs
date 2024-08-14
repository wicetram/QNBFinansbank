namespace QNBFinansbank.VirtualPos.Entity.Request.SegmentInquiry
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinden segment sorgulama işlemi için gerekli olan parametreleri temsil eder.
    /// Bu sınıf, hesap, sipariş ve kart bilgilerini içeren alanları içerir.
    /// </summary>
    public class SegmentInquiryRequestDto : IDto
    {
        /// <summary>
        /// Segment sorgulama işlemi için gerekli olan hesap bilgilerini temsil eder.
        /// Bu alan, üye işyeri bilgileri ve güvenlik bilgilerini içerir.
        /// </summary>
        public AccountDto? Account { get; set; }

        /// <summary>
        /// Segment sorgulama işlemi için gerekli olan sipariş bilgilerini temsil eder.
        /// Bu alan, işlemle ilgili sipariş numarası ve tutar gibi bilgileri içerir.
        /// </summary>
        public OrderDto? Order { get; set; }

        /// <summary>
        /// Segment sorgulama işlemi için gerekli olan kart bilgilerini temsil eder.
        /// Bu alan, işlemde kullanılacak olan kredi kartı bilgilerini içerir.
        /// </summary>
        public CardDto? Card { get; set; }
    }
}
