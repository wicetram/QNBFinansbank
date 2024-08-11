namespace QNBFinansbank.VirtualPos.Entity.Response.Payment.ThreeD.ModelPayment
{
    /// <summary>
    /// 3D Model Payment işlemi için API yanıtını temsil eden DTO sınıfı.
    /// Bu sınıf, 3D Model Payment işlemi sonucunda dönen yanıt verilerini içerir.
    /// </summary>
    public class ThreeDModelPaymentResponseDto : IDto
    {
        /// <summary>
        /// İstek için oluşturulmuş benzersiz GUID.
        /// </summary>
        public string? RequestGuid { get; set; }

        /// <summary>
        /// Sipariş Numarası.
        /// İşleme özgü olarak üretilen benzersiz numara.
        /// </summary>
        public string? OrderId { get; set; }

        /// <summary>
        /// İşlemin güvenlik türü.
        /// (3D Secure model, vb.)
        /// </summary>
        public string? SecureType { get; set; }

        /// <summary>
        /// İşlem tutarı.
        /// İşlemde kullanılan tutar bilgisi.
        /// </summary>
        public string? PurchAmount { get; set; }

        /// <summary>
        /// Payer Transaction ID değeri.
        /// </summary>
        public string? PayerTxnId { get; set; }

        /// <summary>
        /// Payer Authentication Code değeri.
        /// </summary>
        public string? PayerAuthenticationCode { get; set; }

        /// <summary>
        /// Elektronik Ticaret Göstergesi (ECI) değeri.
        /// </summary>
        public string? Eci { get; set; }

        /// <summary>
        /// İşlem için hesaplanan hash değeri.
        /// </summary>
        public string? Hash { get; set; }

        /// <summary>
        /// İşlem tipi.
        /// (Örneğin, Satış:Auth)
        /// </summary>
        public string? TxnType { get; set; }

        /// <summary>
        /// İşlem durumu.
        /// (Başarılı veya başarısız durumu belirten kod)
        /// </summary>
        public string? TxnStatus { get; set; }

        /// <summary>
        /// PARES doğrulama durumu.
        /// </summary>
        public string? ParesVerified { get; set; }

        /// <summary>
        /// PARES söz dizimi kontrol durumu.
        /// </summary>
        public string? ParesSyntaxOk { get; set; }

        /// <summary>
        /// Hata mesajı.
        /// İşlem başarısız olduğunda dönen hata mesajı.
        /// </summary>
        public string? ErrMsg { get; set; }

        /// <summary>
        /// İşlem sonucu.
        /// Örneğin, "Success" veya "Failed".
        /// </summary>
        public string? TxnResult { get; set; }

        /// <summary>
        /// Otorizasyon kodu.
        /// İşlem onaylandığında verilen 6 haneli kod.
        /// </summary>
        public string? AuthCode { get; set; }

        /// <summary>
        /// Banka Referans Numarası.
        /// İşlem için bankanın verdiği 19 haneli referans numarası.
        /// </summary>
        public string? HostRefNum { get; set; }

        /// <summary>
        /// Yanıt için hesaplanan rastgele değer.
        /// </summary>
        public string? ResponseRnd { get; set; }

        /// <summary>
        /// Yanıt hash değeri.
        /// Yanıtın doğruluğunu kontrol etmek için kullanılan hash değeri.
        /// </summary>
        public string? ResponseHash { get; set; }

        /// <summary>
        /// İşlemin Cevap Kodu.
        /// İşlem başarılıysa "00" döner.
        /// </summary>
        public string? ProcReturnCode { get; set; }

        /// <summary>
        /// İşlemde kullanılan terminal ID'si.
        /// </summary>
        public string? TerminalID { get; set; }

        /// <summary>
        /// Kart türü (örneğin, Visa, MasterCard).
        /// </summary>
        public string? CardType { get; set; }

        /// <summary>
        /// İşlemin dili (örneğin, TR, EN).
        /// </summary>
        public string? Lang { get; set; }

        /// <summary>
        /// Döviz Kodu (örneğin, TRY, USD).
        /// </summary>
        public string? Currency { get; set; }

        /// <summary>
        /// Bonus miktarı. İşlemde kullanılan bonus miktarı.
        /// </summary>
        public string? BonusAmount { get; set; }

        /// <summary>
        /// Taksit sayısı.
        /// İşlemin taksitli olup olmadığını belirtir.
        /// </summary>
        public string? InstallmentCount { get; set; }

        /// <summary>
        /// İşlemin yapıldığı ülke kodu.
        /// </summary>
        public string? MrcCountryCode { get; set; }

        /// <summary>
        /// İşlemin yapıldığı mağaza ismi.
        /// </summary>
        public string? MrcName { get; set; }

        /// <summary>
        /// İşlem sonucu dönen rastgele sayı.
        /// </summary>
        public string? Rnd { get; set; }

        /// <summary>
        /// 3D Model ödeme işlemi sonucunda verilen Kart Maskesi.
        /// </summary>
        public string? CardMask { get; set; }

        /// <summary>
        /// İşlemin gerçekleştirildiği tarihte kullanılan F11 alanı.
        /// </summary>
        public string? F11 { get; set; }

        /// <summary>
        /// İşlemin gerçekleştirildiği tarihte kullanılan F37 alanı.
        /// </summary>
        public string? F37 { get; set; }
    }
}