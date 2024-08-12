using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Response.SegmentInquiry
{
    /// <summary>
    /// Segment sorgulama işlemi sonucunda dönen tüm yanıt verilerini temsil eder.
    /// Bu sınıf, segment sorgulama işlemi sırasında dönen çeşitli bilgileri içerir.
    /// </summary>
    [XmlRoot(ElementName = "PayforResponse")]
    public class SegmentInquiryResponseDto : IDto
    {
        /// <summary>
        /// İşlem talebine ait benzersiz kimlik bilgisini içerir.
        /// </summary>
        [XmlElement(ElementName = "RequestGuid")]
        public string? RequestGuid { get; set; }

        /// <summary>
        /// İşlem talebinin sisteme eklenme zamanını belirtir.
        /// </summary>
        [XmlElement(ElementName = "InsertDatetime")]
        public string? InsertDatetime { get; set; }

        /// <summary>
        /// Kurum kodunu içerir.
        /// </summary>
        [XmlElement(ElementName = "MbrId")]
        public string? MbrId { get; set; }

        /// <summary>
        /// Üye işyeri numarasını belirtir.
        /// </summary>
        [XmlElement(ElementName = "MerchantID")]
        public string? MerchantID { get; set; }

        /// <summary>
        /// İşlemle ilişkili sipariş numarasını belirtir.
        /// </summary>
        [XmlElement(ElementName = "OrderId")]
        public string? OrderId { get; set; }

        /// <summary>
        /// İşlemin gerçekleştirildiği IP adresini içerir.
        /// </summary>
        [XmlElement(ElementName = "RequestIp")]
        public string? RequestIp { get; set; }

        /// <summary>
        /// İşlem statüsünü belirtir.
        /// </summary>
        [XmlElement(ElementName = "RequestStat")]
        public string? RequestStat { get; set; }

        /// <summary>
        /// İşlemin güvenlik türünü belirtir.
        /// </summary>
        [XmlElement(ElementName = "SecureType")]
        public string? SecureType { get; set; }

        /// <summary>
        /// İşlem miktarını belirtir.
        /// </summary>
        [XmlElement(ElementName = "PurchAmount")]
        public string? PurchAmount { get; set; }

        /// <summary>
        /// İşlemde kullanılan para biriminin katsayısını belirtir.
        /// </summary>
        [XmlElement(ElementName = "Exponent")]
        public string? Exponent { get; set; }

        /// <summary>
        /// İşlemde kullanılan para birimini belirtir.
        /// </summary>
        [XmlElement(ElementName = "Currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// İşleme ait açıklama bilgisini içerir.
        /// </summary>
        [XmlElement(ElementName = "Description")]
        public string? Description { get; set; }

        /// <summary>
        /// Başarılı işlemlerin dönüş URL'sini içerir.
        /// </summary>
        [XmlElement(ElementName = "OkUrl")]
        public string? OkUrl { get; set; }

        /// <summary>
        /// Başarısız işlemlerin dönüş URL'sini içerir.
        /// </summary>
        [XmlElement(ElementName = "FailUrl")]
        public string? FailUrl { get; set; }

        /// <summary>
        /// İşlemde kullanılan Payer Transaction ID'yi belirtir.
        /// </summary>
        [XmlElement(ElementName = "PayerTxnId")]
        public string? PayerTxnId { get; set; }

        /// <summary>
        /// Payer Authentication Code bilgisini içerir.
        /// </summary>
        [XmlElement(ElementName = "PayerAuthenticationCode")]
        public string? PayerAuthenticationCode { get; set; }

        /// <summary>
        /// İşlemde kullanılan Elektronik Ticaret Göstergesi'ni (ECI) belirtir.
        /// </summary>
        [XmlElement(ElementName = "Eci")]
        public string? Eci { get; set; }

        /// <summary>
        /// Merchant tarafından üretilen ve işlemle ilişkili olan Message Digest (MD) bilgisini içerir.
        /// </summary>
        [XmlElement(ElementName = "MD")]
        public string? MD { get; set; }

        /// <summary>
        /// İşlemde kullanılan hash değerini belirtir.
        /// </summary>
        [XmlElement(ElementName = "Hash")]
        public string? Hash { get; set; }

        /// <summary>
        /// Terminal kimliğini içerir.
        /// </summary>
        [XmlElement(ElementName = "TerminalID")]
        public string? TerminalID { get; set; }

        /// <summary>
        /// İşlem tipini belirtir.
        /// </summary>
        [XmlElement(ElementName = "TxnType")]
        public string? TxnType { get; set; }

        /// <summary>
        /// Orijinal sipariş numarasını belirtir.
        /// </summary>
        [XmlElement(ElementName = "OrgOrderId")]
        public string? OrgOrderId { get; set; }

        /// <summary>
        /// Alt üye işyeri kodunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "SubMerchantCode")]
        public string? SubMerchantCode { get; set; }

        /// <summary>
        /// Tekrarlanan işlemlerin sıklığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "recur_frequency")]
        public string? RecurFrequency { get; set; }

        /// <summary>
        /// Tekrarlanan işlemlerin geçerlilik süresini belirtir.
        /// </summary>
        [XmlElement(ElementName = "recur_expiry")]
        public string? RecurExpiry { get; set; }

        /// <summary>
        /// Kart türünü belirtir.
        /// </summary>
        [XmlElement(ElementName = "CardType")]
        public string? CardType { get; set; }

        /// <summary>
        /// Kullanıcı dil bilgisini belirtir.
        /// </summary>
        [XmlElement(ElementName = "Lang")]
        public string? Lang { get; set; }

        /// <summary>
        /// Bonus miktarını belirtir.
        /// </summary>
        [XmlElement(ElementName = "BonusAmount")]
        public string? BonusAmount { get; set; }

        /// <summary>
        /// Taksit sayısını belirtir.
        /// </summary>
        [XmlElement(ElementName = "InstallmentCount")]
        public string? InstallmentCount { get; set; }

        /// <summary>
        /// İşlemde kullanılan rastgele değeri içerir.
        /// </summary>
        [XmlElement(ElementName = "Rnd")]
        public string? Rnd { get; set; }

        /// <summary>
        /// Alpha kodunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "AlphaCode")]
        public string? AlphaCode { get; set; }

        /// <summary>
        /// Elektronik Ticaret (Ecommerce) bilgisini içerir.
        /// </summary>
        [XmlElement(ElementName = "Ecommerce")]
        public string? Ecommerce { get; set; }

        /// <summary>
        /// Üye işyerinin bulunduğu ülke kodunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "MrcCountryCode")]
        public string? MrcCountryCode { get; set; }

        /// <summary>
        /// Üye işyerinin adını belirtir.
        /// </summary>
        [XmlElement(ElementName = "MrcName")]
        public string? MrcName { get; set; }

        /// <summary>
        /// Üye işyerinin ana sayfa URL'sini belirtir.
        /// </summary>
        [XmlElement(ElementName = "MerchantHomeUrl")]
        public string? MerchantHomeUrl { get; set; }

        /// <summary>
        /// Kart sahibinin adını belirtir.
        /// </summary>
        [XmlElement(ElementName = "CardHolderName")]
        public string? CardHolderName { get; set; }

        /// <summary>
        /// Irc detayını belirtir.
        /// </summary>
        [XmlElement(ElementName = "IrcDet")]
        public string? IrcDet { get; set; }

        /// <summary>
        /// Irc kodunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "IrcCode")]
        public string? IrcCode { get; set; }

        /// <summary>
        /// İşlemde kullanılan yazılım versiyonunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "Version")]
        public string? Version { get; set; }

        /// <summary>
        /// İşlemin durumunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "TxnStatus")]
        public string? TxnStatus { get; set; }

        /// <summary>
        /// Cavv algoritmasını belirtir.
        /// </summary>
        [XmlElement(ElementName = "CavvAlg")]
        public string? CavvAlg { get; set; }

        /// <summary>
        /// Pares doğrulama durumunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "ParesVerified")]
        public string? ParesVerified { get; set; }

        /// <summary>
        /// Pares sentez kontrol durumunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "ParesSyntaxOk")]
        public string? ParesSyntaxOk { get; set; }

        /// <summary>
        /// Hata mesajını içerir.
        /// </summary>
        [XmlElement(ElementName = "ErrMsg")]
        public string? ErrMsg { get; set; }

        /// <summary>
        /// Satıcı detayını belirtir.
        /// </summary>
        [XmlElement(ElementName = "VendorDet")]
        public string? VendorDet { get; set; }

        /// <summary>
        /// 3D güvenlik doğrulama durumu.
        /// </summary>
        [XmlElement(ElementName = "D3Status")]
        public string? D3Status { get; set; }

        /// <summary>
        /// İşlem sonucunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "TxnResult")]
        public string? TxnResult { get; set; }

        /// <summary>
        /// Otorizasyon kodunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "AuthCode")]
        public string? AuthCode { get; set; }

        /// <summary>
        /// Host referans numarasını belirtir.
        /// </summary>
        [XmlElement(ElementName = "HostRefNum")]
        public string? HostRefNum { get; set; }

        /// <summary>
        /// İşlem sonucunda dönen işlem geri dönüş kodunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "ProcReturnCode")]
        public string? ProcReturnCode { get; set; }

        /// <summary>
        /// İşlem sonrası yönlendirilmesi gereken URL'yi belirtir.
        /// </summary>
        [XmlElement(ElementName = "ReturnUrl")]
        public string? ReturnUrl { get; set; }

        /// <summary>
        /// Hata verisini içerir.
        /// </summary>
        [XmlElement(ElementName = "ErrorData")]
        public string? ErrorData { get; set; }

        /// <summary>
        /// Batch numarasını belirtir.
        /// </summary>
        [XmlElement(ElementName = "BatchNo")]
        public string? BatchNo { get; set; }

        /// <summary>
        /// İptal tarihini belirtir.
        /// </summary>
        [XmlElement(ElementName = "VoidDate")]
        public string? VoidDate { get; set; }

        /// <summary>
        /// Kart maskelemesini belirtir.
        /// </summary>
        [XmlElement(ElementName = "CardMask")]
        public string? CardMask { get; set; }

        /// <summary>
        /// İşlem talep kimliğini belirtir.
        /// </summary>
        [XmlElement(ElementName = "ReqId")]
        public string? ReqId { get; set; }

        /// <summary>
        /// Kullanılan puan miktarını belirtir.
        /// </summary>
        [XmlElement(ElementName = "UsedPoint")]
        public string? UsedPoint { get; set; }

        /// <summary>
        /// Kaynak türünü belirtir.
        /// </summary>
        [XmlElement(ElementName = "SrcType")]
        public string? SrcType { get; set; }

        /// <summary>
        /// İade edilen tutarı belirtir.
        /// </summary>
        [XmlElement(ElementName = "RefundedAmount")]
        public string? RefundedAmount { get; set; }

        /// <summary>
        /// İade edilen puanı belirtir.
        /// </summary>
        [XmlElement(ElementName = "RefundedPoint")]
        public string? RefundedPoint { get; set; }

        /// <summary>
        /// İşlem talep tarihini belirtir.
        /// </summary>
        [XmlElement(ElementName = "ReqDate")]
        public string? ReqDate { get; set; }

        /// <summary>
        /// İşlem sistem tarihini belirtir.
        /// </summary>
        [XmlElement(ElementName = "SysDate")]
        public string? SysDate { get; set; }

        /// <summary>
        /// F11 değerini belirtir.
        /// </summary>
        [XmlElement(ElementName = "F11")]
        public string? F11 { get; set; }

        /// <summary>
        /// F37 değerini belirtir.
        /// </summary>
        [XmlElement(ElementName = "F37")]
        public string? F37 { get; set; }

        /// <summary>
        /// Tekrarlanan işlem olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "IsRepeatTxn")]
        public string? IsRepeatTxn { get; set; }

        /// <summary>
        /// Cavv sonucu belirtir.
        /// </summary>
        [XmlElement(ElementName = "CavvResult")]
        public string? CavvResult { get; set; }

        /// <summary>
        /// VPOS işlem süresini belirtir.
        /// </summary>
        [XmlElement(ElementName = "VposElapsedTime")]
        public string? VposElapsedTime { get; set; }

        /// <summary>
        /// Bankacılık işlem süresini belirtir.
        /// </summary>
        [XmlElement(ElementName = "BankingElapsedTime")]
        public string? BankingElapsedTime { get; set; }

        /// <summary>
        /// Soket işlem süresini belirtir.
        /// </summary>
        [XmlElement(ElementName = "SocketElapsedTime")]
        public string? SocketElapsedTime { get; set; }

        /// <summary>
        /// HSM işlem süresini belirtir.
        /// </summary>
        [XmlElement(ElementName = "HsmElapsedTime")]
        public string? HsmElapsedTime { get; set; }

        /// <summary>
        /// MPI işlem süresini belirtir.
        /// </summary>
        [XmlElement(ElementName = "MpiElapsedTime")]
        public string? MpiElapsedTime { get; set; }

        /// <summary>
        /// Sipariş kimliği olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "hasOrderId")]
        public string? HasOrderId { get; set; }

        /// <summary>
        /// Şablon türünü belirtir.
        /// </summary>
        [XmlElement(ElementName = "TemplateType")]
        public string? TemplateType { get; set; }

        /// <summary>
        /// Adres sayısı olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "HasAddressCount")]
        public string? HasAddressCount { get; set; }

        /// <summary>
        /// Ödeme kolaylaştırıcı olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "IsPaymentFacilitator")]
        public string? IsPaymentFacilitator { get; set; }

        /// <summary>
        /// Üye işyerinin bulunduğu ülke kodunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "MerchantCountryCode")]
        public string? MerchantCountryCode { get; set; }

        /// <summary>
        /// Orijinal işlem tipini belirtir.
        /// </summary>
        [XmlElement(ElementName = "OrgTxnType")]
        public string? OrgTxnType { get; set; }

        /// <summary>
        /// Orijinal F11 değerini belirtir.
        /// </summary>
        [XmlElement(ElementName = "F11_ORG")]
        public string? F11ORG { get; set; }

        /// <summary>
        /// Orijinal F12 değerini belirtir.
        /// </summary>
        [XmlElement(ElementName = "F12_ORG")]
        public string? F12ORG { get; set; }

        /// <summary>
        /// Orijinal F13 değerini belirtir.
        /// </summary>
        [XmlElement(ElementName = "F13_ORG")]
        public string? F13ORG { get; set; }

        /// <summary>
        /// Orijinal F22 değerini belirtir.
        /// </summary>
        [XmlElement(ElementName = "F22_ORG")]
        public string? F22ORG { get; set; }

        /// <summary>
        /// Orijinal F25 değerini belirtir.
        /// </summary>
        [XmlElement(ElementName = "F25_ORG")]
        public string? F25ORG { get; set; }

        /// <summary>
        /// Orijinal MTI değerini belirtir.
        /// </summary>
        [XmlElement(ElementName = "MTI_ORG")]
        public string? MTIORG { get; set; }

        /// <summary>
        /// DS marka bilgisini belirtir.
        /// </summary>
        [XmlElement(ElementName = "DsBrand")]
        public string? DsBrand { get; set; }

        /// <summary>
        /// Aralık türünü belirtir.
        /// </summary>
        [XmlElement(ElementName = "IntervalType")]
        public string? IntervalType { get; set; }

        /// <summary>
        /// Aralık süresini belirtir.
        /// </summary>
        [XmlElement(ElementName = "IntervalDuration")]
        public string? IntervalDuration { get; set; }

        /// <summary>
        /// Tekrarlama sayısını belirtir.
        /// </summary>
        [XmlElement(ElementName = "RepeatCount")]
        public string? RepeatCount { get; set; }

        /// <summary>
        /// Müşteri kodunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "CustomerCode")]
        public string? CustomerCode { get; set; }

        /// <summary>
        /// Talep edilen üye işyeri alan adını belirtir.
        /// </summary>
        [XmlElement(ElementName = "RequestMerchantDomain")]
        public string? RequestMerchantDomain { get; set; }

        /// <summary>
        /// Talep edilen istemci IP'sini belirtir.
        /// </summary>
        [XmlElement(ElementName = "RequestClientIp")]
        public string? RequestClientIp { get; set; }

        /// <summary>
        /// Yanıt rastgele değerini belirtir.
        /// </summary>
        [XmlElement(ElementName = "ResponseRnd")]
        public string? ResponseRnd { get; set; }

        /// <summary>
        /// Yanıt hash değerini belirtir.
        /// </summary>
        [XmlElement(ElementName = "ResponseHash")]
        public string? ResponseHash { get; set; }

        /// <summary>
        /// Banka içi yanıt kodunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseCode")]
        public string? BankInternalResponseCode { get; set; }

        /// <summary>
        /// Banka içi yanıt mesajını belirtir.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseMessage")]
        public string? BankInternalResponseMessage { get; set; }

        /// <summary>
        /// Banka içi yanıt alt kodunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseSubcode")]
        public string? BankInternalResponseSubcode { get; set; }

        /// <summary>
        /// Banka içi yanıt alt mesajını belirtir.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseSubmessage")]
        public string? BankInternalResponseSubmessage { get; set; }

        /// <summary>
        /// Bayi kodunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "BayiKodu")]
        public string? BayiKodu { get; set; }

        /// <summary>
        /// İptal saatini belirtir.
        /// </summary>
        [XmlElement(ElementName = "VoidTime")]
        public string? VoidTime { get; set; }

        /// <summary>
        /// İptal işlemini gerçekleştiren kullanıcı kodunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "VoidUserCode")]
        public string? VoidUserCode { get; set; }

        /// <summary>
        /// Ödeme bağlantı kimliğini belirtir.
        /// </summary>
        [XmlElement(ElementName = "PaymentLinkId")]
        public string? PaymentLinkId { get; set; }

        /// <summary>
        /// İstemcinin QR kodunun geçerli olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "IsQRValid")]
        public string? IsQRValid { get; set; }

        /// <summary>
        /// İstemcinin FAST kodunun geçerli olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "IsFastValid")]
        public string? IsFastValid { get; set; }

        /// <summary>
        /// İşlemin QR kodu kullanıp kullanmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "IsQR")]
        public string? IsQR { get; set; }

        /// <summary>
        /// İşlemin FAST ödeme sistemi kullanıp kullanmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "IsFast")]
        public string? IsFast { get; set; }

        /// <summary>
        /// QR referans numarasını belirtir.
        /// </summary>
        [XmlElement(ElementName = "QRRefNo")]
        public string? QRRefNo { get; set; }

        /// <summary>
        /// FAST gönderen katılımcı kodunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "FASTGonderenKatilimciKodu")]
        public string? FASTGonderenKatilimciKodu { get; set; }

        /// <summary>
        /// FAST alan katılımcı kodunu belirtir.
        /// </summary>
        [XmlElement(ElementName = "FASTAlanKatilimciKodu")]
        public string? FASTAlanKatilimciKodu { get; set; }

        /// <summary>
        /// FAST referans numarasını belirtir.
        /// </summary>
        [XmlElement(ElementName = "FASTReferansNo")]
        public string? FASTReferansNo { get; set; }

        /// <summary>
        /// FAST gönderen IBAN'ı belirtir.
        /// </summary>
        [XmlElement(ElementName = "FastGonderenIBAN")]
        public string? FastGonderenIBAN { get; set; }

        /// <summary>
        /// FAST gönderen adını belirtir.
        /// </summary>
        [XmlElement(ElementName = "FASTGonderenAdi")]
        public string? FASTGonderenAdi { get; set; }

        /// <summary>
        /// Mobil ECI değerini belirtir.
        /// </summary>
        [XmlElement(ElementName = "MobileECI")]
        public string? MobileECI { get; set; }

        /// <summary>
        /// Hub bağlantı kimliğini belirtir.
        /// </summary>
        [XmlElement(ElementName = "HubConnId")]
        public string? HubConnId { get; set; }

        /// <summary>
        /// Cüzdan verisini belirtir.
        /// </summary>
        [XmlElement(ElementName = "WalletData")]
        public string? WalletData { get; set; }

        /// <summary>
        /// TDS 2DS işlem kimliğini belirtir.
        /// </summary>
        [XmlElement(ElementName = "Tds2dsTransId")]
        public string? Tds2dsTransId { get; set; }

        /// <summary>
        /// 3D host olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "Is3DHost")]
        public string? Is3DHost { get; set; }

        /// <summary>
        /// Artı taksit miktarını belirtir.
        /// </summary>
        [XmlElement(ElementName = "ArtiTaksit")]
        public string? ArtiTaksit { get; set; }

        /// <summary>
        /// Otorizasyon kimliğini belirtir.
        /// </summary>
        [XmlElement(ElementName = "AuthId")]
        public string? AuthId { get; set; }

        /// <summary>
        /// XML isteği tarafından dönen sonucu belirtir.
        /// </summary>
        [XmlElement(ElementName = "PAYFORFROMXMLREQUEST")]
        public string? PayForFromXMLRequest { get; set; }
    }
}
