namespace QNBFinansbank.VirtualPos.Entity.Response.Payment.QR
{
    /// <summary>
    /// QR ödeme işlemi sonrası dönen yanıt verilerini temsil eden DTO.
    /// Bu sınıf, QR ödeme işlemi sonucunda dönen tüm parametreleri içerir.
    /// </summary>
    public class QRPaymentResponseDto : IDto
    {
        /// <summary>
        /// İstek için oluşturulmuş benzersiz GUID.
        /// </summary>
        public string? RequestGuid { get; set; }

        /// <summary>
        /// İşlemin gerçekleştirildiği tarih ve saat bilgisi.
        /// </summary>
        public string? TransactionDate { get; set; }

        /// <summary>
        /// Kurum kodudur.
        /// </summary>
        public string? MbrId { get; set; }

        /// <summary>
        /// Üye işyeri numarası.
        /// </summary>
        public string? MerchantID { get; set; }

        /// <summary>
        /// Üye işyeri tarafından üretilen sipariş numarası.
        /// </summary>
        public string? OrderId { get; set; }

        /// <summary>
        /// İstek IP adresi.
        /// </summary>
        public string? RequestIp { get; set; }

        /// <summary>
        /// İstek durumu.
        /// </summary>
        public string? RequestStat { get; set; }

        /// <summary>
        /// İşlemin güvenlik türü. (Örn: NonSecure)
        /// </summary>
        public string? SecureType { get; set; }

        /// <summary>
        /// İşlem tutarı.
        /// </summary>
        public string? PurchAmount { get; set; }

        /// <summary>
        /// Exponent değeri.
        /// </summary>
        public string? Exponent { get; set; }

        /// <summary>
        /// Kur bilgisi. (Örn: TL:949)
        /// </summary>
        public string? Currency { get; set; }

        /// <summary>
        /// İşlem açıklaması.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// İşlem başarılı olduğunda yönlendirme yapılacak URL.
        /// </summary>
        public string? OkUrl { get; set; }

        /// <summary>
        /// İşlem başarısız olduğunda yönlendirme yapılacak URL.
        /// </summary>
        public string? FailUrl { get; set; }

        /// <summary>
        /// Payer Transaction ID değeri.
        /// </summary>
        public string? PayerTxnId { get; set; }

        /// <summary>
        /// Payer Authentication Code değeri.
        /// </summary>
        public string? PayerAuthenticationCode { get; set; }

        /// <summary>
        /// ECI değeri.
        /// </summary>
        public string? Eci { get; set; }

        /// <summary>
        /// MD değeri.
        /// </summary>
        public string? MD { get; set; }

        /// <summary>
        /// Hash değeri.
        /// </summary>
        public string? Hash { get; set; }

        /// <summary>
        /// Terminal ID değeri.
        /// </summary>
        public string? TerminalID { get; set; }

        /// <summary>
        /// İşlem tipi. (Örn: Auth)
        /// </summary>
        public string? TxnType { get; set; }

        /// <summary>
        /// Orijinal sipariş numarası (Eğer mevcutsa).
        /// </summary>
        public string? OrgOrderId { get; set; }

        /// <summary>
        /// Alt bayi kodu.
        /// </summary>
        public string? SubMerchantCode { get; set; }

        /// <summary>
        /// Tekrarlayan işlemler için frekans değeri.
        /// </summary>
        public string? RecurFrequency { get; set; }

        /// <summary>
        /// Tekrarlayan işlemler için bitiş süresi.
        /// </summary>
        public string? RecurExpiry { get; set; }

        /// <summary>
        /// Kart tipi. (Örn: V - Visa)
        /// </summary>
        public string? CardType { get; set; }

        /// <summary>
        /// Kullanıcı dil bilgisi. (Örn: TR)
        /// </summary>
        public string? Lang { get; set; }

        /// <summary>
        /// Bonus tutarı.
        /// </summary>
        public string? BonusAmount { get; set; }

        /// <summary>
        /// Taksit sayısı.
        /// </summary>
        public string? InstallmentCount { get; set; }

        /// <summary>
        /// Rnd değeri.
        /// </summary>
        public string? Rnd { get; set; }

        /// <summary>
        /// Alpha kodu.
        /// </summary>
        public string? AlphaCode { get; set; }

        /// <summary>
        /// E-ticaret işlemi olup olmadığını belirtir.
        /// </summary>
        public string? Ecommerce { get; set; }

        /// <summary>
        /// Üye işyeri ülke kodu.
        /// </summary>
        public string? MrcCountryCode { get; set; }

        /// <summary>
        /// Üye işyeri adı.
        /// </summary>
        public string? MrcName { get; set; }

        /// <summary>
        /// Üye işyeri ana URL bilgisi.
        /// </summary>
        public string? MerchantHomeUrl { get; set; }

        /// <summary>
        /// Kart sahibinin adı.
        /// </summary>
        public string? CardHolderName { get; set; }

        /// <summary>
        /// IRC detay bilgisi.
        /// </summary>
        public string? IrcDet { get; set; }

        /// <summary>
        /// IRC kodu.
        /// </summary>
        public string? IrcCode { get; set; }

        /// <summary>
        /// Sürüm bilgisi.
        /// </summary>
        public string? Version { get; set; }

        /// <summary>
        /// İşlem durumu.
        /// </summary>
        public string? TxnStatus { get; set; }

        /// <summary>
        /// CAVV algoritması.
        /// </summary>
        public string? CavvAlg { get; set; }

        /// <summary>
        /// PARES doğrulaması.
        /// </summary>
        public string? ParesVerified { get; set; }

        /// <summary>
        /// PARES söz dizimi kontrolü.
        /// </summary>
        public string? ParesSyntaxOk { get; set; }

        /// <summary>
        /// Hata mesajı.
        /// </summary>
        public string? ErrMsg { get; set; }

        /// <summary>
        /// Satıcı detayı.
        /// </summary>
        public string? VendorDet { get; set; }

        /// <summary>
        /// 3D durum bilgisi.
        /// </summary>
        public string? D3Stat { get; set; }

        /// <summary>
        /// İşlem sonucu. (Örn: Success, Failed)
        /// </summary>
        public string? TxnResult { get; set; }

        /// <summary>
        /// Yetkilendirme kodu.
        /// </summary>
        public string? AuthCode { get; set; }

        /// <summary>
        /// Banka otorizasyon sisteminden dönen host referans numarası.
        /// </summary>
        public string? HostRefNum { get; set; }

        /// <summary>
        /// RRN değeri (Retrieval Reference Number).
        /// </summary>
        public string? RRN { get; set; }

        /// <summary>
        /// İşlem dönüş kodu.
        /// </summary>
        public string? ProcReturnCode { get; set; }

        /// <summary>
        /// İade edilecek URL.
        /// </summary>
        public string? ReturnUrl { get; set; }

        /// <summary>
        /// Hata verisi.
        /// </summary>
        public string? ErrorData { get; set; }

        /// <summary>
        /// Batch numarası.
        /// </summary>
        public string? BatchNo { get; set; }

        /// <summary>
        /// İptal tarihi.
        /// </summary>
        public string? VoidDate { get; set; }

        /// <summary>
        /// Kart numarası maskesi.
        /// </summary>
        public string? CardMask { get; set; }

        /// <summary>
        /// İstek ID'si.
        /// </summary>
        public string? ReqId { get; set; }

        /// <summary>
        /// Kullanılan puan miktarı.
        /// </summary>
        public string? UsedPoint { get; set; }

        /// <summary>
        /// Kaynak türü. (Örn: VPO)
        /// </summary>
        public string? SrcType { get; set; }

        /// <summary>
        /// İade edilen tutar.
        /// </summary>
        public string? RefundedAmount { get; set; }

        /// <summary>
        /// İade edilen puan miktarı.
        /// </summary>
        public string? RefundedPoint { get; set; }

        /// <summary>
        /// İstek tarihi.
        /// </summary>
        public string? ReqDate { get; set; }

        /// <summary>
        /// Sistem tarihi.
        /// </summary>
        public string? SysDate { get; set; }

        /// <summary>
        /// F11 alanı değeri.
        /// </summary>
        public string? F11 { get; set; }

        /// <summary>
        /// F37 alanı değeri.
        /// </summary>
        public string? F37 { get; set; }

        /// <summary>
        /// Tekrar eden işlem olup olmadığını belirtir.
        /// </summary>
        public string? IsRepeatTxn { get; set; }

        /// <summary>
        /// CAVV sonucu.
        /// </summary>
        public string? CavvResult { get; set; }

        /// <summary>
        /// VPOS süre bilgisi (milisaniye cinsinden).
        /// </summary>
        public string? VposElapsedTime { get; set; }

        /// <summary>
        /// Bankacılık süre bilgisi (milisaniye cinsinden).
        /// </summary>
        public string? BankingElapsedTime { get; set; }

        /// <summary>
        /// Socket süre bilgisi (milisaniye cinsinden).
        /// </summary>
        public string? SocketElapsedTime { get; set; }

        /// <summary>
        /// HSM süre bilgisi (milisaniye cinsinden).
        /// </summary>
        public string? HsmElapsedTime { get; set; }

        /// <summary>
        /// MPI süre bilgisi (milisaniye cinsinden).
        /// </summary>
        public string? MpiElapsedTime { get; set; }

        /// <summary>
        /// Sipariş ID'sinin olup olmadığını belirtir.
        /// </summary>
        public string? HasOrderId { get; set; }

        /// <summary>
        /// Şablon tipi.
        /// </summary>
        public string? TemplateType { get; set; }

        /// <summary>
        /// Adres sayısı olup olmadığını belirtir.
        /// </summary>
        public string? HasAddressCount { get; set; }

        /// <summary>
        /// Ödeme aracısı olup olmadığını belirtir.
        /// </summary>
        public string? IsPaymentFacilitator { get; set; }

        /// <summary>
        /// Üye işyeri ülke kodu.
        /// </summary>
        public string? MerchantCountryCode { get; set; }

        /// <summary>
        /// Orijinal işlem tipi.
        /// </summary>
        public string? OrgTxnType { get; set; }

        /// <summary>
        /// F11 ORG alanı değeri.
        /// </summary>
        public string? F11_ORG { get; set; }

        /// <summary>
        /// F12 ORG alanı değeri.
        /// </summary>
        public string? F12_ORG { get; set; }

        /// <summary>
        /// F13 ORG alanı değeri.
        /// </summary>
        public string? F13_ORG { get; set; }

        /// <summary>
        /// F22 ORG alanı değeri.
        /// </summary>
        public string? F22_ORG { get; set; }

        /// <summary>
        /// F25 ORG alanı değeri.
        /// </summary>
        public string? F25_ORG { get; set; }

        /// <summary>
        /// MTI ORG alanı değeri.
        /// </summary>
        public string? MTI_ORG { get; set; }

        /// <summary>
        /// DS marka bilgisi.
        /// </summary>
        public string? DsBrand { get; set; }

        /// <summary>
        /// Aralık türü.
        /// </summary>
        public string? IntervalType { get; set; }

        /// <summary>
        /// Aralık süresi.
        /// </summary>
        public string? IntervalDuration { get; set; }

        /// <summary>
        /// Tekrar sayısı.
        /// </summary>
        public string? RepeatCount { get; set; }

        /// <summary>
        /// Müşteri kodu.
        /// </summary>
        public string? CustomerCode { get; set; }

        /// <summary>
        /// İstek üye işyeri domaini.
        /// </summary>
        public string? RequestMerchantDomain { get; set; }

        /// <summary>
        /// İstek müşteri IP adresi.
        /// </summary>
        public string? RequestClientIp { get; set; }

        /// <summary>
        /// Yanıt rastgele değeri.
        /// </summary>
        public string? ResponseRnd { get; set; }

        /// <summary>
        /// Yanıt hash değeri.
        /// </summary>
        public string? ResponseHash { get; set; }

        /// <summary>
        /// Banka iç yanıt kodu.
        /// </summary>
        public string? BankInternalResponseCode { get; set; }

        /// <summary>
        /// Banka iç yanıt mesajı.
        /// </summary>
        public string? BankInternalResponseMessage { get; set; }

        /// <summary>
        /// Banka iç yanıt alt kodu.
        /// </summary>
        public string? BankInternalResponseSubcode { get; set; }

        /// <summary>
        /// Banka iç yanıt alt mesajı.
        /// </summary>
        public string? BankInternalResponseSubmessage { get; set; }

        /// <summary>
        /// Bayi kodu.
        /// </summary>
        public string? BayiKodu { get; set; }

        /// <summary>
        /// İptal süresi.
        /// </summary>
        public string? VoidTime { get; set; }

        /// <summary>
        /// İptal kullanıcı kodu.
        /// </summary>
        public string? VoidUserCode { get; set; }

        /// <summary>
        /// Ödeme bağlantı ID'si.
        /// </summary>
        public string? PaymentLinkId { get; set; }

        /// <summary>
        /// İstemci ID'si.
        /// </summary>
        public string? ClientId { get; set; }

        /// <summary>
        /// QR kodunun geçerli olup olmadığını belirtir.
        /// </summary>
        public string? IsQRValid { get; set; }

        /// <summary>
        /// FAST işleminin geçerli olup olmadığını belirtir.
        /// </summary>
        public string? IsFastValid { get; set; }

        /// <summary>
        /// QR işlemi olup olmadığını belirtir.
        /// </summary>
        public string? IsQR { get; set; }

        /// <summary>
        /// FAST işlemi olup olmadığını belirtir.
        /// </summary>
        public string? IsFast { get; set; }

        /// <summary>
        /// QR referans numarası.
        /// </summary>
        public string? QRRefNo { get; set; }

        /// <summary>
        /// FAST gönderen katılımcı kodu.
        /// </summary>
        public string? FASTGonderenKatilimciKodu { get; set; }

        /// <summary>
        /// FAST alan katılımcı kodu.
        /// </summary>
        public string? FASTAlanKatilimciKodu { get; set; }

        /// <summary>
        /// FAST referans numarası.
        /// </summary>
        public string? FASTReferansNo { get; set; }

        /// <summary>
        /// FAST gönderen IBAN.
        /// </summary>
        public string? FastGonderenIBAN { get; set; }

        /// <summary>
        /// FAST gönderen adı.
        /// </summary>
        public string? FASTGonderenAdi { get; set; }

        /// <summary>
        /// Mobil ECI değeri.
        /// </summary>
        public string? MobileECI { get; set; }

        /// <summary>
        /// Hub bağlantı ID'si.
        /// </summary>
        public string? HubConnId { get; set; }

        /// <summary>
        /// Cüzdan verisi.
        /// </summary>
        public string? WalletData { get; set; }

        /// <summary>
        /// TDS 2DS işlem ID'si.
        /// </summary>
        public string? Tds2dsTransId { get; set; }

        /// <summary>
        /// 3D Host işlemi olup olmadığını belirtir.
        /// </summary>
        public string? Is3DHost { get; set; }

        /// <summary>
        /// Ekstra taksit sayısı.
        /// </summary>
        public string? ArtiTaksit { get; set; }

        /// <summary>
        /// Yetkilendirme ID'si.
        /// </summary>
        public string? AuthId { get; set; }

        /// <summary>
        /// Sistem kullanıcı kodu.
        /// </summary>
        public string? SESSION_SYSTEM_USER { get; set; }
    }
}
