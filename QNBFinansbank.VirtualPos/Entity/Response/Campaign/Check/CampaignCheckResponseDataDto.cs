using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Response.Campaign.Check
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinden kampanya kontrolü yanıtını temsil eden sınıf.
    /// Bu sınıf, kampanya kontrolüne ait tüm yanıt verilerini içerir.
    /// </summary>
    [XmlRoot(ElementName = "PayforResponse")]
    public class CampaignCheckResponseDataDto : IDto
    {
        /// <summary>
        /// Talep için oluşturulan benzersiz GUID değerini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "RequestGuid")]
        public string? RequestGuid { get; set; }

        /// <summary>
        /// Talebin veritabanına eklenme tarih ve saatini temsil eder.
        /// Bu değer, "dd.MM.yyyy HH:mm:ss" formatında bir tarih ve saat string?idir.
        /// </summary>
        [XmlElement(ElementName = "InsertDatetime")]
        public string? InsertDatetime { get; set; }

        /// <summary>
        /// Üye işyeri numarasını temsil eder.
        /// Bu değer, kampanya kontrolü yapılan üye işyerini belirtir.
        /// </summary>
        [XmlElement(ElementName = "MbrId")]
        public string? MbrId { get; set; }

        /// <summary>
        /// Üye işyeri kodunu temsil eder.
        /// Bu değer, kampanya kontrolü yapılan üye işyeri kodunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "MerchantID")]
        public string? MerchantID { get; set; }

        /// <summary>
        /// Sipariş numarasını temsil eder.
        /// Bu değer, kampanya kontrolü yapılan siparişin numarasını belirtir.
        /// </summary>
        [XmlElement(ElementName = "OrderId")]
        public string? OrderId { get; set; }

        /// <summary>
        /// Talep edilen IP adresini temsil eder.
        /// Bu değer, kampanya kontrolü talebini gönderen cihazın IP adresini belirtir.
        /// </summary>
        [XmlElement(ElementName = "RequestIp")]
        public string? RequestIp { get; set; }

        /// <summary>
        /// Talep durumunu temsil eder.
        /// Bu değer, kampanya kontrolü talebinin durumunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "RequestStat")]
        public string? RequestStat { get; set; }

        /// <summary>
        /// Güvenlik türünü temsil eder.
        /// Bu değer, işlemde kullanılan güvenlik yöntemini belirtir.
        /// </summary>
        [XmlElement(ElementName = "SecureType")]
        public string? SecureType { get; set; }

        /// <summary>
        /// Satın alma tutarını temsil eder.
        /// Bu değer, kampanya kontrolü yapılan işlemin tutarını belirtir.
        /// </summary>
        [XmlElement(ElementName = "PurchAmount")]
        public string? PurchAmount { get; set; }

        /// <summary>
        /// Satın alma işlemi için kullanılan döviz çarpanını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "Exponent")]
        public string? Exponent { get; set; }

        /// <summary>
        /// Döviz kodunu temsil eder.
        /// Bu değer, kampanya kontrolü yapılan işlemin döviz cinsini belirtir.
        /// </summary>
        [XmlElement(ElementName = "Currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// Açıklama alanını temsil eder.
        /// Bu değer, kampanya kontrolü yanıtına ilişkin açıklamaları belirtir.
        /// </summary>
        [XmlElement(ElementName = "Description")]
        public string? Description { get; set; }

        /// <summary>
        /// İşlemin başarılı olduğu durumda yönlendirme yapılacak URL'yi temsil eder.
        /// </summary>
        [XmlElement(ElementName = "OkUrl")]
        public string? OkUrl { get; set; }

        /// <summary>
        /// İşlemin başarısız olduğu durumda yönlendirme yapılacak URL'yi temsil eder.
        /// </summary>
        [XmlElement(ElementName = "FailUrl")]
        public string? FailUrl { get; set; }

        /// <summary>
        /// Ödeyenin işlem kimliğini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "PayerTxnId")]
        public string? PayerTxnId { get; set; }

        /// <summary>
        /// Ödeyenin doğrulama kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "PayerAuthenticationCode")]
        public string? PayerAuthenticationCode { get; set; }

        /// <summary>
        /// İşlem için kullanılan Elektronik Ticaret Tanımlayıcı (ECI) kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "Eci")]
        public string? Eci { get; set; }

        /// <summary>
        /// Kart sahibinin doğrulama bilgisini temsil eden MD değerini belirtir.
        /// </summary>
        [XmlElement(ElementName = "MD")]
        public string? MD { get; set; }

        /// <summary>
        /// İşlemin bütünlüğünü sağlamak için kullanılan hash değerini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "Hash")]
        public string? Hash { get; set; }

        /// <summary>
        /// İşlemin gerçekleştirildiği terminalin kimliğini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "TerminalID")]
        public string? TerminalID { get; set; }

        /// <summary>
        /// İşlem türünü temsil eder.
        /// Bu değer, kampanya kontrolü işleminin türünü belirtir.
        /// </summary>
        [XmlElement(ElementName = "TxnType")]
        public string? TxnType { get; set; }

        /// <summary>
        /// Orijinal sipariş numarasını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "OrgOrderId")]
        public string? OrgOrderId { get; set; }

        /// <summary>
        /// Alt üye işyeri kodunu temsil eder.
        /// Bu değer, alt üye işyerini belirtir.
        /// </summary>
        [XmlElement(ElementName = "SubMerchantCode")]
        public string? SubMerchantCode { get; set; }

        /// <summary>
        /// Tekrarlama sıklığını temsil eder.
        /// Bu değer, kampanya kontrolü için ayarlanan tekrarlama sıklığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "recur_frequency")]
        public string? RecurFrequency { get; set; }

        /// <summary>
        /// Tekrarlama bitiş tarihini temsil eder.
        /// Bu değer, kampanya kontrolü için ayarlanan tekrarlama bitiş tarihini belirtir.
        /// </summary>
        [XmlElement(ElementName = "recur_expiry")]
        public string? RecurExpiry { get; set; }

        /// <summary>
        /// Kart türünü temsil eder.
        /// Bu değer, kampanya kontrolü yapılan kartın türünü belirtir.
        /// </summary>
        [XmlElement(ElementName = "CardType")]
        public string? CardType { get; set; }

        /// <summary>
        /// İşlemin yapıldığı dili temsil eder.
        /// </summary>
        [XmlElement(ElementName = "Lang")]
        public string? Lang { get; set; }

        /// <summary>
        /// Kazanılan bonus miktarını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "BonusAmount")]
        public string? BonusAmount { get; set; }

        /// <summary>
        /// Taksit sayısını temsil eder.
        /// Bu değer, kampanya kontrolü yapılan işlemin kaç taksit üzerinden yapılacağını belirtir.
        /// </summary>
        [XmlElement(ElementName = "InstallmentCount")]
        public string? InstallmentCount { get; set; }

        /// <summary>
        /// Rastgele oluşturulmuş bir değeri temsil eder.
        /// </summary>
        [XmlElement(ElementName = "Rnd")]
        public string? Rnd { get; set; }

        /// <summary>
        /// Alfa kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "AlphaCode")]
        public string? AlphaCode { get; set; }

        /// <summary>
        /// E-ticaret işlemi olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "Ecommerce")]
        public string? Ecommerce { get; set; }

        /// <summary>
        /// Üye işyerinin ülke kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "MrcCountryCode")]
        public string? MrcCountryCode { get; set; }

        /// <summary>
        /// Üye işyerinin adını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "MrcName")]
        public string? MrcName { get; set; }

        /// <summary>
        /// Üye işyerinin ana sayfa URL'sini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "MerchantHomeUrl")]
        public string? MerchantHomeUrl { get; set; }

        /// <summary>
        /// Kart sahibinin adını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "CardHolderName")]
        public string? CardHolderName { get; set; }

        /// <summary>
        /// İşleme ilişkin IRC detaylarını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "IrcDet")]
        public string? IrcDet { get; set; }

        /// <summary>
        /// İşleme ilişkin IRC kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "IrcCode")]
        public string? IrcCode { get; set; }

        /// <summary>
        /// API sürümünü temsil eder.
        /// </summary>
        [XmlElement(ElementName = "Version")]
        public string? Version { get; set; }

        /// <summary>
        /// İşlem durumunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "TxnStatus")]
        public string? TxnStatus { get; set; }

        /// <summary>
        /// CAVV algoritmasını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "CavvAlg")]
        public string? CavvAlg { get; set; }

        /// <summary>
        /// PARes doğrulama sonucunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "ParesVerified")]
        public string? ParesVerified { get; set; }

        /// <summary>
        /// PARes sözdizimi doğrulama sonucunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "ParesSyntaxOk")]
        public string? ParesSyntaxOk { get; set; }

        /// <summary>
        /// Hata mesajını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "ErrMsg")]
        public string? ErrMsg { get; set; }

        /// <summary>
        /// Satıcı detaylarını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "VendorDet")]
        public string? VendorDet { get; set; }

        /// <summary>
        /// 3D güvenlik durumunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "D3Status")]
        public string? D3Status { get; set; }

        /// <summary>
        /// İşlem sonucunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "TxnResult")]
        public string? TxnResult { get; set; }

        /// <summary>
        /// Yetkilendirme kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "AuthCode")]
        public string? AuthCode { get; set; }

        /// <summary>
        /// İşlemin ana referans numarasını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "HostRefNum")]
        public string? HostRefNum { get; set; }

        /// <summary>
        /// İşlem geri dönüş kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "ProcReturnCode")]
        public string? ProcReturnCode { get; set; }

        /// <summary>
        /// Yanıt URL'sini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "ReturnUrl")]
        public string? ReturnUrl { get; set; }

        /// <summary>
        /// Hata verisini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "ErrorData")]
        public string? ErrorData { get; set; }

        /// <summary>
        /// Batch numarasını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "BatchNo")]
        public string? BatchNo { get; set; }

        /// <summary>
        /// İptal tarihini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "VoidDate")]
        public string? VoidDate { get; set; }

        /// <summary>
        /// Kart maske bilgilerini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "CardMask")]
        public string? CardMask { get; set; }

        /// <summary>
        /// Talep kimliğini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "ReqId")]
        public string? ReqId { get; set; }

        /// <summary>
        /// Kullanılan puan miktarını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "UsedPoint")]
        public string? UsedPoint { get; set; }

        /// <summary>
        /// İşlem kaynağını temsil eder.
        /// Bu değer, işlemin hangi kaynak üzerinden yapıldığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "SrcType")]
        public string? SrcType { get; set; }

        /// <summary>
        /// İade edilen tutarı temsil eder.
        /// </summary>
        [XmlElement(ElementName = "RefundedAmount")]
        public string? RefundedAmount { get; set; }

        /// <summary>
        /// İade edilen puan miktarını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "RefundedPoint")]
        public string? RefundedPoint { get; set; }

        /// <summary>
        /// Talep tarihini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "ReqDate")]
        public string? ReqDate { get; set; }

        /// <summary>
        /// Sistem tarihini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "SysDate")]
        public string? SysDate { get; set; }

        /// <summary>
        /// F11 alanını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "F11")]
        public string? F11 { get; set; }

        /// <summary>
        /// F37 alanını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "F37")]
        public string? F37 { get; set; }

        /// <summary>
        /// İşlemin tekrarlanıp tekrarlanmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "IsRepeatTxn")]
        public string? IsRepeatTxn { get; set; }

        /// <summary>
        /// CAVV sonuç değerini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "CavvResult")]
        public string? CavvResult { get; set; }

        /// <summary>
        /// VPOS geçen süreyi temsil eder.
        /// </summary>
        [XmlElement(ElementName = "VposElapsedTime")]
        public string? VposElapsedTime { get; set; }

        /// <summary>
        /// Banka işlem süresini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "BankingElapsedTime")]
        public string? BankingElapsedTime { get; set; }

        /// <summary>
        /// Socket işlem süresini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "SocketElapsedTime")]
        public string? SocketElapsedTime { get; set; }

        /// <summary>
        /// HSM işlem süresini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "HsmElapsedTime")]
        public string? HsmElapsedTime { get; set; }

        /// <summary>
        /// MPI işlem süresini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "MpiElapsedTime")]
        public string? MpiElapsedTime { get; set; }

        /// <summary>
        /// Sipariş kimliğinin olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "hasOrderId")]
        public string? HasOrderId { get; set; }

        /// <summary>
        /// Şablon türünü temsil eder.
        /// </summary>
        [XmlElement(ElementName = "TemplateType")]
        public string? TemplateType { get; set; }

        /// <summary>
        /// Adres sayısının olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "HasAddressCount")]
        public string? HasAddressCount { get; set; }

        /// <summary>
        /// Ödeme aracı olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "IsPaymentFacilitator")]
        public string? IsPaymentFacilitator { get; set; }

        /// <summary>
        /// Üye işyeri ülke kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "MerchantCountryCode")]
        public string? MerchantCountryCode { get; set; }

        /// <summary>
        /// Orijinal işlem türünü temsil eder.
        /// </summary>
        [XmlElement(ElementName = "OrgTxnType")]
        public string? OrgTxnType { get; set; }

        /// <summary>
        /// Orijinal F11 alanını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "F11_ORG")]
        public string? F11ORG { get; set; }

        /// <summary>
        /// Orijinal F12 alanını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "F12_ORG")]
        public string? F12ORG { get; set; }

        /// <summary>
        /// Orijinal F13 alanını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "F13_ORG")]
        public string? F13ORG { get; set; }

        /// <summary>
        /// Orijinal F22 alanını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "F22_ORG")]
        public string? F22ORG { get; set; }

        /// <summary>
        /// Orijinal F25 alanını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "F25_ORG")]
        public string? F25ORG { get; set; }

        /// <summary>
        /// Orijinal MTI kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "MTI_ORG")]
        public string? MTIORG { get; set; }

        /// <summary>
        /// Marka detaylarını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "DsBrand")]
        public string? DsBrand { get; set; }

        /// <summary>
        /// Aralık türünü temsil eder.
        /// </summary>
        [XmlElement(ElementName = "IntervalType")]
        public string? IntervalType { get; set; }

        /// <summary>
        /// Aralık süresini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "IntervalDuration")]
        public string? IntervalDuration { get; set; }

        /// <summary>
        /// Tekrar sayısını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "RepeatCount")]
        public string? RepeatCount { get; set; }

        /// <summary>
        /// Müşteri kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "CustomerCode")]
        public string? CustomerCode { get; set; }

        /// <summary>
        /// Talep edilen üye işyeri alan adını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "RequestMerchantDomain")]
        public string? RequestMerchantDomain { get; set; }

        /// <summary>
        /// Talep edilen istemci IP adresini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "RequestClientIp")]
        public string? RequestClientIp { get; set; }

        /// <summary>
        /// Yanıt için rastgele oluşturulmuş değeri temsil eder.
        /// </summary>
        [XmlElement(ElementName = "ResponseRnd")]
        public string? ResponseRnd { get; set; }

        /// <summary>
        /// Yanıtın bütünlüğünü sağlamak için kullanılan hash değerini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "ResponseHash")]
        public string? ResponseHash { get; set; }

        /// <summary>
        /// Banka içi yanıt kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseCode")]
        public string? BankInternalResponseCode { get; set; }

        /// <summary>
        /// Banka içi yanıt mesajını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseMessage")]
        public string? BankInternalResponseMessage { get; set; }

        /// <summary>
        /// Banka içi yanıt alt kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseSubcode")]
        public string? BankInternalResponseSubcode { get; set; }

        /// <summary>
        /// Banka içi yanıt alt mesajını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseSubmessage")]
        public string? BankInternalResponseSubmessage { get; set; }

        /// <summary>
        /// Bayi kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "BayiKodu")]
        public string? BayiKodu { get; set; }

        /// <summary>
        /// İptal süresini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "VoidTime")]
        public string? VoidTime { get; set; }

        /// <summary>
        /// İptal işlemini gerçekleştiren kullanıcı kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "VoidUserCode")]
        public string? VoidUserCode { get; set; }

        /// <summary>
        /// Ödeme bağlantı kimliğini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "PaymentLinkId")]
        public string? PaymentLinkId { get; set; }

        /// <summary>
        /// QR kodunun geçerli olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "IsQRValid")]
        public string? IsQRValid { get; set; }

        /// <summary>
        /// FAST işleminin geçerli olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "IsFastValid")]
        public string? IsFastValid { get; set; }

        /// <summary>
        /// İşlemin QR kodu üzerinden yapılıp yapılmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "IsQR")]
        public string? IsQR { get; set; }

        /// <summary>
        /// İşlemin FAST üzerinden yapılıp yapılmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "IsFast")]
        public string? IsFast { get; set; }

        /// <summary>
        /// QR referans numarasını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "QRRefNo")]
        public string? QRRefNo { get; set; }

        /// <summary>
        /// FAST işlemini gönderen katılımcı kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "FASTGonderenKatilimciKodu")]
        public string? FASTGonderenKatilimciKodu { get; set; }

        /// <summary>
        /// FAST işlemini alan katılımcı kodunu temsil eder.
        /// </summary>
        [XmlElement(ElementName = "FASTAlanKatilimciKodu")]
        public string? FASTAlanKatilimciKodu { get; set; }

        /// <summary>
        /// FAST referans numarasını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "FASTReferansNo")]
        public string? FASTReferansNo { get; set; }

        /// <summary>
        /// FAST işlemini gönderen IBAN numarasını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "FastGonderenIBAN")]
        public string? FastGonderenIBAN { get; set; }

        /// <summary>
        /// FAST işlemini gönderenin adını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "FASTGonderenAdi")]
        public string? FASTGonderenAdi { get; set; }

        /// <summary>
        /// Mobil ECI değerini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "MobileECI")]
        public string? MobileECI { get; set; }

        /// <summary>
        /// HUB bağlantı kimliğini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "HubConnId")]
        public string? HubConnId { get; set; }

        /// <summary>
        /// Cüzdan verilerini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "WalletData")]
        public string? WalletData { get; set; }

        /// <summary>
        /// 3D Secure 2 işlem kimliğini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "Tds2dsTransId")]
        public string? Tds2dsTransId { get; set; }

        /// <summary>
        /// 3D Host durumunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "Is3DHost")]
        public string? Is3DHost { get; set; }

        /// <summary>
        /// Artı taksit sayısını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "ArtiTaksit")]
        public string? ArtiTaksit { get; set; }

        /// <summary>
        /// Yetkilendirme kimliğini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "AuthId")]
        public string? AuthId { get; set; }

        /// <summary>
        /// Kampanya detaylarını temsil eder.
        /// </summary>
        [XmlElement(ElementName = "Kampanya")]
        public string? Kampanya { get; set; }

        /// <summary>
        /// Oteleme bilgilerini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "Oteleme")]
        public string? Oteleme { get; set; }

        /// <summary>
        /// Payfor XML'den oluşturulan istek verisini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "PAYFORFROMXMLREQUEST")]
        public string? PayforFromXMLRequest { get; set; }

        /// <summary>
        /// Oturum sistem kullanıcı kimliğini temsil eder.
        /// </summary>
        [XmlElement(ElementName = "SESSION_SYSTEM_USER")]
        public string? SessionSystemUser { get; set; }
    }
}