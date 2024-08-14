namespace QNBFinansbank.VirtualPos.Entity.Request.PreAuth
{
    /// <summary>
    /// Ön otorizasyon (Pre-Auth) işlemi için gerekli olan veri transfer objesini (DTO) temsil eder.
    /// Bu sınıf, bir ön otorizasyon talebi sırasında gönderilecek olan hesap ve sipariş bilgilerini içerir.
    /// </summary>
    public class PreAuthRequestDto : IDto
    {
        /// <summary>
        /// Hesap bilgilerini temsil eden DTO.
        /// Bu alan, işlemin yapılacağı hesabın detaylarını içerir.
        /// </summary>
        public AccountDto? Account { get; set; }

        /// <summary>
        /// Sipariş bilgilerini temsil eden DTO.
        /// Bu alan, işlemin yapılacağı siparişe ilişkin detayları içerir.
        /// </summary>
        public OrderDto? Order { get; set; }


        /// <summary>
        /// Kart bilgilerini temsil eden DTO.
        /// Bu alan, işlemin gerçekleştirileceği kartın detaylarını içerir.
        /// </summary>
        public CardDto? Card { get; set; }
    }
}
