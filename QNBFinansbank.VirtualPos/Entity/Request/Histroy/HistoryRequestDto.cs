namespace QNBFinansbank.VirtualPos.Entity.Request.History
{
    /// <summary>
    /// İşlem geçmişi sorgulama talebini temsil eden veri transfer nesnesi (DTO).
    /// Bu nesne, belirli bir hesap ve sipariş için işlem geçmişi sorgulama isteğini içerir.
    /// </summary>
    public class HistoryRequestDto : IDto
    {
        /// <summary>
        /// Hesap bilgilerini içeren DTO nesnesi.
        /// Bu bilgiler, kurum kodu, kullanıcı kodu, şifre ve diğer gerekli detayları içerir.
        /// </summary>
        public AccountDto? Account { get; set; }

        /// <summary>
        /// Sipariş bilgilerini içeren DTO nesnesi.
        /// Bu bilgiler, sorgulanacak işlemin detaylarını içerir.
        /// </summary>
        public OrderDto? Order { get; set; }

        /// <summary>
        /// İşlem geçmişi sorgulanacak tarih bilgisi.
        /// Format: YYYYMMDD. Bu tarih, sorgulamak istenilen işlem tarihini belirtir.
        /// </summary>
        public string? RequestDate { get; set; }

        /// <summary>
        /// İşlem geçmişi sorgulamak için başlangıç zamanının epoch değeri.
        /// Bu değer, belirli bir zaman diliminde yapılan işlemleri sorgulamak için kullanılır.
        /// </summary>
        public string? RequestStartDatetime { get; set; }
    }
}
