namespace QNBFinansbank.VirtualPos.Entity
{
    public class StartPaymentRequestDto : IDto
    {
        /// <summary>
        /// Kurum kodu
        /// </summary>
        public string? MbrId { get; set; }

        /// <summary>
        /// Üye işyeri numarası
        /// </summary>
        public string? MerchantId { get; set; }

        /// <summary>
        /// 3D Secure şifresi
        /// </summary>
        public string? MerchantPass { get; set; }

        /// <summary>
        /// Kullanıcı kodu
        /// </summary>
        public string? UserCode { get; set; }

        /// <summary>
        /// Kullanıcı şifresi
        /// </summary>
        public string? UserPass { get; set; }

        /// <summary>
        /// Sanal pos işlem güvenlik türü
        /// </summary>
        public string? SecureType { get; set; }
        
        /// <summary>
        /// İşlem tipi
        /// </summary>
        public string? TxnType { get; set; }
        
        /// <summary>
        /// Taksit sayısı
        /// </summary>
        public string? Installment { get; set; }
        
        /// <summary>
        /// Kur bilgisi
        /// </summary>
        public string? Currency { get; set; }
        
        /// <summary>
        /// İşlem sonrası kullanıcının geri döneceği site
        /// </summary>
        public string? ReturnUrl { get; set; }
        
        /// <summary>
        /// İşleme özgü numara
        /// </summary>
        public string? OrderId { get; set; }
        
        /// <summary>
        /// İşlemin tutarı. Kuruş ayraç operatörü (.) kullanılmalı ve kuruş hanesi 2 karakter olmalıdır.
        /// </summary>
        public string? Amount { get; set; }
        
        /// <summary>
        /// Dil bilgisi
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// İşlemin güvenlik tipi
        /// </summary>
        public int PaymentSecurity { get; set; }
    }
}
