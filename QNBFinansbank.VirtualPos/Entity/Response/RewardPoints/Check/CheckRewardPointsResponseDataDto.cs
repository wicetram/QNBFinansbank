using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Response.RewardPoints.Check
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinde para puan sorgulama işlemi yanıtını temsil eden DTO sınıfı.
    /// Bu sınıf, para puan sorgulama işlemi sonucunda dönen verileri içerir.
    /// </summary>
    [XmlRoot(ElementName = "PayforResponse")]
    public class CheckRewardPointsResponseDataDto
    {
        /// <summary>
        /// İstek için oluşturulmuş benzersiz GUID.
        /// </summary>
        [XmlElement(ElementName = "RequestGuid")]
        public string? RequestGuid { get; set; }

        /// <summary>
        /// İstek verisinin sisteme kaydedildiği tarih ve saat bilgisi.
        /// </summary>
        [XmlElement(ElementName = "InsertDatetime")]
        public string? InsertDatetime { get; set; }

        /// <summary>
        /// Kurum kodu. (Banka tarafından verilir)
        /// </summary>
        [XmlElement(ElementName = "MbrId")]
        public string? MbrId { get; set; }

        /// <summary>
        /// Üye işyeri numarası. (Bankadan temin edilir)
        /// </summary>
        [XmlElement(ElementName = "MerchantID")]
        public string? MerchantID { get; set; }

        /// <summary>
        /// Sipariş numarası.
        /// İşleme özgü olarak üretilen benzersiz numara.
        /// </summary>
        [XmlElement(ElementName = "OrderId")]
        public string? OrderId { get; set; }

        /// <summary>
        /// İstek yapılan IP adresi.
        /// </summary>
        [XmlElement(ElementName = "RequestIp")]
        public string? RequestIp { get; set; }

        /// <summary>
        /// İsteğin durumunu temsil eden kod.
        /// </summary>
        [XmlElement(ElementName = "RequestStat")]
        public string? RequestStat { get; set; }

        /// <summary>
        /// İşlemin güvenlik türünü belirtir. (Örneğin, Inquiry)
        /// </summary>
        [XmlElement(ElementName = "SecureType")]
        public string? SecureType { get; set; }

        /// <summary>
        /// İşlem tutarı.
        /// İşlemde kullanılan tutar bilgisi.
        /// </summary>
        [XmlElement(ElementName = "PurchAmount")]
        public string? PurchAmount { get; set; }

        /// <summary>
        /// Tutarın üssünü belirtir. (Genellikle 2 olarak kullanılır)
        /// </summary>
        [XmlElement(ElementName = "Exponent")]
        public string? Exponent { get; set; }

        /// <summary>
        /// İşlemde kullanılan para birimi. (Örneğin, TL:949, USD:840)
        /// </summary>
        [XmlElement(ElementName = "Currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// İşlem açıklaması.
        /// </summary>
        [XmlElement(ElementName = "Description")]
        public string? Description { get; set; }

        /// <summary>
        /// İşlem başarılı olduğunda yönlendirilmesi gereken URL.
        /// </summary>
        [XmlElement(ElementName = "OkUrl")]
        public string? OkUrl { get; set; }

        /// <summary>
        /// İşlem başarısız olduğunda yönlendirilmesi gereken URL.
        /// </summary>
        [XmlElement(ElementName = "FailUrl")]
        public string? FailUrl { get; set; }

        /// <summary>
        /// Payer Transaction ID değeri.
        /// </summary>
        [XmlElement(ElementName = "PayerTxnId")]
        public string? PayerTxnId { get; set; }

        /// <summary>
        /// Payer Authentication Code değeri.
        /// </summary>
        [XmlElement(ElementName = "PayerAuthenticationCode")]
        public string? PayerAuthenticationCode { get; set; }

        /// <summary>
        /// Elektronik Ticaret Göstergesi (ECI) değeri.
        /// </summary>
        [XmlElement(ElementName = "Eci")]
        public string? Eci { get; set; }

        /// <summary>
        /// MD değerini temsil eden veri.
        /// </summary>
        [XmlElement(ElementName = "MD")]
        public string? MD { get; set; }

        /// <summary>
        /// İşlem için hesaplanan hash değeri.
        /// </summary>
        [XmlElement(ElementName = "Hash")]
        public string? Hash { get; set; }

        /// <summary>
        /// Terminal ID değeri.
        /// </summary>
        [XmlElement(ElementName = "TerminalID")]
        public string? TerminalID { get; set; }

        /// <summary>
        /// İşlem tipi. (Örneğin, Para Puan Sorgulama: ParaPuanInquiry)
        /// </summary>
        [XmlElement(ElementName = "TxnType")]
        public string? TxnType { get; set; }

        /// <summary>
        /// Orijinal sipariş numarası.
        /// </summary>
        [XmlElement(ElementName = "OrgOrderId")]
        public string? OrgOrderId { get; set; }

        /// <summary>
        /// Alt bayi kodu.
        /// </summary>
        [XmlElement(ElementName = "SubMerchantCode")]
        public string? SubMerchantCode { get; set; }

        /// <summary>
        /// Tekrarlayan ödeme sıklığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "recur_frequency")]
        public string? RecurFrequency { get; set; }

        /// <summary>
        /// Tekrarlayan ödemenin bitiş tarihini belirtir.
        /// </summary>
        [XmlElement(ElementName = "recur_expiry")]
        public string? RecurExpiry { get; set; }

        /// <summary>
        /// Kart türü.
        /// </summary>
        [XmlElement(ElementName = "CardType")]
        public string? CardType { get; set; }

        /// <summary>
        /// Kullanıcı dil bilgisi. (Örneğin, Türkçe: TR, İngilizce: EN)
        /// </summary>
        [XmlElement(ElementName = "Lang")]
        public string? Lang { get; set; }

        /// <summary>
        /// Bonus puan tutarı.
        /// </summary>
        [XmlElement(ElementName = "BonusAmount")]
        public string? BonusAmount { get; set; }

        /// <summary>
        /// Taksit sayısı.
        /// </summary>
        [XmlElement(ElementName = "InstallmentCount")]
        public string? InstallmentCount { get; set; }

        /// <summary>
        /// Rastgele oluşturulan bir değer.
        /// </summary>
        [XmlElement(ElementName = "Rnd")]
        public string? Rnd { get; set; }

        /// <summary>
        /// Alfabetik kod.
        /// </summary>
        [XmlElement(ElementName = "AlphaCode")]
        public string? AlphaCode { get; set; }

        /// <summary>
        /// Elektronik ticaret göstergesi.
        /// </summary>
        [XmlElement(ElementName = "Ecommerce")]
        public string? Ecommerce { get; set; }

        /// <summary>
        /// Üye işyerinin bulunduğu ülke kodu.
        /// </summary>
        [XmlElement(ElementName = "MrcCountryCode")]
        public string? MrcCountryCode { get; set; }

        /// <summary>
        /// Üye işyeri adı.
        /// </summary>
        [XmlElement(ElementName = "MrcName")]
        public string? MrcName { get; set; }

        /// <summary>
        /// Üye işyerinin ana sayfa URL'si.
        /// </summary>
        [XmlElement(ElementName = "MerchantHomeUrl")]
        public string? MerchantHomeUrl { get; set; }

        /// <summary>
        /// Kart sahibinin adı.
        /// </summary>
        [XmlElement(ElementName = "CardHolderName")]
        public string? CardHolderName { get; set; }

        /// <summary>
        /// IRC detayı.
        /// </summary>
        [XmlElement(ElementName = "IrcDet")]
        public string? IrcDet { get; set; }

        /// <summary>
        /// IRC kodu.
        /// </summary>
        [XmlElement(ElementName = "IrcCode")]
        public string? IrcCode { get; set; }

        /// <summary>
        /// Yanıtın versiyon numarası.
        /// </summary>
        [XmlElement(ElementName = "Version")]
        public string? Version { get; set; }

        /// <summary>
        /// İşlemin durumu.
        /// Başarı durumu veya hata durumunu belirten kod.
        /// </summary>
        [XmlElement(ElementName = "TxnStatus")]
        public string? TxnStatus { get; set; }

        /// <summary>
        /// CAVV algoritması.
        /// </summary>
        [XmlElement(ElementName = "CavvAlg")]
        public string? CavvAlg { get; set; }

        /// <summary>
        /// Pares doğrulama durumu.
        /// </summary>
        [XmlElement(ElementName = "ParesVerified")]
        public string? ParesVerified { get; set; }

        /// <summary>
        /// Pares söz dizimi doğrulama durumu.
        /// </summary>
        [XmlElement(ElementName = "ParesSyntaxOk")]
        public string? ParesSyntaxOk { get; set; }

        /// <summary>
        /// Hata mesajı.
        /// İşlem sırasında oluşan hata mesajını içerir.
        /// </summary>
        [XmlElement(ElementName = "ErrMsg")]
        public string? ErrMsg { get; set; }

        /// <summary>
        /// Satıcı detayı.
        /// </summary>
        [XmlElement(ElementName = "VendorDet")]
        public string? VendorDet { get; set; }

        /// <summary>
        /// 3D Durumu.
        /// </summary>
        [XmlElement(ElementName = "D3Status")]
        public string? D3Status { get; set; }

        /// <summary>
        /// İşlem sonucu.
        /// (Başarı veya başarısızlık durumunu belirtir)
        /// </summary>
        [XmlElement(ElementName = "TxnResult")]
        public string? TxnResult { get; set; }

        /// <summary>
        /// Otorizasyon kodu.
        /// İşlem onaylandığında verilen 6 haneli kod.
        /// </summary>
        [XmlElement(ElementName = "AuthCode")]
        public string? AuthCode { get; set; }

        /// <summary>
        /// Banka Referans Numarası.
        /// İşlem için bankanın verdiği 19 haneli referans numarası.
        /// </summary>
        [XmlElement(ElementName = "HostRefNum")]
        public string? HostRefNum { get; set; }

        /// <summary>
        /// İşlemin Cevap Kodu.
        /// İşlem başarılıysa "00" döner.
        /// </summary>
        [XmlElement(ElementName = "ProcReturnCode")]
        public string? ProcReturnCode { get; set; }

        /// <summary>
        /// Geri dönüş URL'si.
        /// </summary>
        [XmlElement(ElementName = "ReturnUrl")]
        public string? ReturnUrl { get; set; }

        /// <summary>
        /// Hata verisi.
        /// </summary>
        [XmlElement(ElementName = "ErrorData")]
        public string? ErrorData { get; set; }

        /// <summary>
        /// Toplu işlem numarası.
        /// </summary>
        [XmlElement(ElementName = "BatchNo")]
        public string? BatchNo { get; set; }

        /// <summary>
        /// İptal tarihi.
        /// </summary>
        [XmlElement(ElementName = "VoidDate")]
        public string? VoidDate { get; set; }

        /// <summary>
        /// Kart numarasının maske hali.
        /// </summary>
        [XmlElement(ElementName = "CardMask")]
        public string? CardMask { get; set; }

        /// <summary>
        /// İstek ID'si.
        /// </summary>
        [XmlElement(ElementName = "ReqId")]
        public string? ReqId { get; set; }

        /// <summary>
        /// Kullanılmış puan.
        /// </summary>
        [XmlElement(ElementName = "UsedPoint")]
        public string? UsedPoint { get; set; }

        /// <summary>
        /// Kaynak türü.
        /// </summary>
        [XmlElement(ElementName = "SrcType")]
        public string? SrcType { get; set; }

        /// <summary>
        /// İade edilen miktar.
        /// </summary>
        [XmlElement(ElementName = "RefundedAmount")]
        public string? RefundedAmount { get; set; }

        /// <summary>
        /// İade edilen puan.
        /// </summary>
        [XmlElement(ElementName = "RefundedPoint")]
        public string? RefundedPoint { get; set; }

        /// <summary>
        /// İstek tarihi.
        /// </summary>
        [XmlElement(ElementName = "ReqDate")]
        public string? ReqDate { get; set; }

        /// <summary>
        /// Sistem tarihi.
        /// </summary>
        [XmlElement(ElementName = "SysDate")]
        public string? SysDate { get; set; }

        /// <summary>
        /// F11 alanı.
        /// </summary>
        [XmlElement(ElementName = "F11")]
        public string? F11 { get; set; }

        /// <summary>
        /// F37 alanı.
        /// </summary>
        [XmlElement(ElementName = "F37")]
        public string? F37 { get; set; }

        /// <summary>
        /// Tekrarlanan işlem durumu.
        /// </summary>
        [XmlElement(ElementName = "IsRepeatTxn")]
        public string? IsRepeatTxn { get; set; }

        /// <summary>
        /// CAVV sonucu.
        /// </summary>
        [XmlElement(ElementName = "CavvResult")]
        public string? CavvResult { get; set; }

        /// <summary>
        /// VPOS tarafından hesaplanan işlem süresi.
        /// </summary>
        [XmlElement(ElementName = "VposElapsedTime")]
        public string? VposElapsedTime { get; set; }

        /// <summary>
        /// Banka tarafından hesaplanan işlem süresi.
        /// </summary>
        [XmlElement(ElementName = "BankingElapsedTime")]
        public string? BankingElapsedTime { get; set; }

        /// <summary>
        /// Soket üzerinden geçen işlem süresi.
        /// </summary>
        [XmlElement(ElementName = "SocketElapsedTime")]
        public string? SocketElapsedTime { get; set; }

        /// <summary>
        /// HSM tarafından hesaplanan işlem süresi.
        /// </summary>
        [XmlElement(ElementName = "HsmElapsedTime")]
        public string? HsmElapsedTime { get; set; }

        /// <summary>
        /// MPI tarafından hesaplanan işlem süresi.
        /// </summary>
        [XmlElement(ElementName = "MpiElapsedTime")]
        public string? MpiElapsedTime { get; set; }

        /// <summary>
        /// Sipariş ID'si olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "hasOrderId")]
        public string? HasOrderId { get; set; }

        /// <summary>
        /// Şablon türü.
        /// </summary>
        [XmlElement(ElementName = "TemplateType")]
        public string? TemplateType { get; set; }

        /// <summary>
        /// Adres sayısı olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "HasAddressCount")]
        public string? HasAddressCount { get; set; }

        /// <summary>
        /// Ödeme kolaylaştırıcısı olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "IsPaymentFacilitator")]
        public string? IsPaymentFacilitator { get; set; }

        /// <summary>
        /// Üye işyerinin bulunduğu ülke kodu.
        /// </summary>
        [XmlElement(ElementName = "MerchantCountryCode")]
        public string? MerchantCountryCode { get; set; }

        /// <summary>
        /// Orijinal işlem tipi.
        /// </summary>
        [XmlElement(ElementName = "OrgTxnType")]
        public string? OrgTxnType { get; set; }

        /// <summary>
        /// F11_ORG alanı.
        /// </summary>
        [XmlElement(ElementName = "F11_ORG")]
        public string? F11ORG { get; set; }

        /// <summary>
        /// F12_ORG alanı.
        /// </summary>
        [XmlElement(ElementName = "F12_ORG")]
        public string? F12ORG { get; set; }

        /// <summary>
        /// F13_ORG alanı.
        /// </summary>
        [XmlElement(ElementName = "F13_ORG")]
        public string? F13ORG { get; set; }

        /// <summary>
        /// F22_ORG alanı.
        /// </summary>
        [XmlElement(ElementName = "F22_ORG")]
        public string? F22ORG { get; set; }

        /// <summary>
        /// F25_ORG alanı.
        /// </summary>
        [XmlElement(ElementName = "F25_ORG")]
        public string? F25ORG { get; set; }

        /// <summary>
        /// MTI_ORG alanı.
        /// </summary>
        [XmlElement(ElementName = "MTI_ORG")]
        public string? MTIORG { get; set; }

        /// <summary>
        /// DS markası.
        /// </summary>
        [XmlElement(ElementName = "DsBrand")]
        public string? DsBrand { get; set; }

        /// <summary>
        /// Zaman aralığı türü.
        /// </summary>
        [XmlElement(ElementName = "IntervalType")]
        public string? IntervalType { get; set; }

        /// <summary>
        /// Zaman aralığı süresi.
        /// </summary>
        [XmlElement(ElementName = "IntervalDuration")]
        public string? IntervalDuration { get; set; }

        /// <summary>
        /// Tekrarlama sayısı.
        /// </summary>
        [XmlElement(ElementName = "RepeatCount")]
        public string? RepeatCount { get; set; }

        /// <summary>
        /// Müşteri kodu.
        /// </summary>
        [XmlElement(ElementName = "CustomerCode")]
        public string? CustomerCode { get; set; }

        /// <summary>
        /// İstek yapılan üye işyeri alanı.
        /// </summary>
        [XmlElement(ElementName = "RequestMerchantDomain")]
        public string? RequestMerchantDomain { get; set; }

        /// <summary>
        /// İstek yapılan istemci IP adresi.
        /// </summary>
        [XmlElement(ElementName = "RequestClientIp")]
        public string? RequestClientIp { get; set; }

        /// <summary>
        /// Yanıt için rastgele oluşturulan bir değer.
        /// </summary>
        [XmlElement(ElementName = "ResponseRnd")]
        public string? ResponseRnd { get; set; }

        /// <summary>
        /// Yanıt için hesaplanan hash değeri.
        /// </summary>
        [XmlElement(ElementName = "ResponseHash")]
        public string? ResponseHash { get; set; }

        /// <summary>
        /// Banka içi yanıt kodu.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseCode")]
        public string? BankInternalResponseCode { get; set; }

        /// <summary>
        /// Banka içi yanıt mesajı.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseMessage")]
        public string? BankInternalResponseMessage { get; set; }

        /// <summary>
        /// Banka içi yanıt alt kodu.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseSubcode")]
        public string? BankInternalResponseSubcode { get; set; }

        /// <summary>
        /// Banka içi yanıt alt mesajı.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseSubmessage")]
        public string? BankInternalResponseSubmessage { get; set; }

        /// <summary>
        /// Bayi kodu.
        /// </summary>
        [XmlElement(ElementName = "BayiKodu")]
        public string? BayiKodu { get; set; }

        /// <summary>
        /// İptal zamanı.
        /// </summary>
        [XmlElement(ElementName = "VoidTime")]
        public string? VoidTime { get; set; }

        /// <summary>
        /// İptal eden kullanıcının kodu.
        /// </summary>
        [XmlElement(ElementName = "VoidUserCode")]
        public string? VoidUserCode { get; set; }

        /// <summary>
        /// Ödeme bağlantı kimliği.
        /// </summary>
        [XmlElement(ElementName = "PaymentLinkId")]
        public string? PaymentLinkId { get; set; }

        /// <summary>
        /// İstemci kimliği.
        /// </summary>
        [XmlElement(ElementName = "ClientId")]
        public string? ClientId { get; set; }

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
        /// QR işlemi olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "IsQR")]
        public string? IsQR { get; set; }

        /// <summary>
        /// FAST işlemi olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "IsFast")]
        public string? IsFast { get; set; }

        /// <summary>
        /// QR referans numarası.
        /// </summary>
        [XmlElement(ElementName = "QRRefNo")]
        public string? QRRefNo { get; set; }

        /// <summary>
        /// FAST gönderen katılımcı kodu.
        /// </summary>
        [XmlElement(ElementName = "FASTGonderenKatilimciKodu")]
        public string? FASTGonderenKatilimciKodu { get; set; }

        /// <summary>
        /// FAST alan katılımcı kodu.
        /// </summary>
        [XmlElement(ElementName = "FASTAlanKatilimciKodu")]
        public string? FASTAlanKatilimciKodu { get; set; }

        /// <summary>
        /// FAST referans numarası.
        /// </summary>
        [XmlElement(ElementName = "FASTReferansNo")]
        public string? FASTReferansNo { get; set; }

        /// <summary>
        /// FAST gönderen IBAN numarası.
        /// </summary>
        [XmlElement(ElementName = "FastGonderenIBAN")]
        public string? FastGonderenIBAN { get; set; }

        /// <summary>
        /// FAST gönderenin adı.
        /// </summary>
        [XmlElement(ElementName = "FASTGonderenAdi")]
        public string? FASTGonderenAdi { get; set; }

        /// <summary>
        /// Mobil ECI değeri.
        /// </summary>
        [XmlElement(ElementName = "MobileECI")]
        public string? MobileECI { get; set; }

        /// <summary>
        /// Hub bağlantı kimliği.
        /// </summary>
        [XmlElement(ElementName = "HubConnId")]
        public string? HubConnId { get; set; }

        /// <summary>
        /// Cüzdan verisi.
        /// </summary>
        [XmlElement(ElementName = "WalletData")]
        public string? WalletData { get; set; }

        /// <summary>
        /// TDS 2DS işlem kimliği.
        /// </summary>
        [XmlElement(ElementName = "Tds2dsTransId")]
        public string? Tds2dsTransId { get; set; }

        /// <summary>
        /// 3D ana bilgisayar olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "Is3DHost")]
        public string? Is3DHost { get; set; }

        /// <summary>
        /// Ekstra taksit olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "ArtiTaksit")]
        public string? ArtiTaksit { get; set; }

        /// <summary>
        /// XML istekten gelen ödeme verisi.
        /// </summary>
        [XmlElement(ElementName = "PAYFORFROMXMLREQUEST")]
        public string? PayForFromXMLRequest { get; set; }

        /// <summary>
        /// Sistem kullanıcısı oturumu.
        /// </summary>
        [XmlElement(ElementName = "SESSION_SYSTEM_USER")]
        public string? SessionSystemUser { get; set; }

        /// <summary>
        /// Kullanılabilir nakit puan tutarı.
        /// </summary>
        [XmlElement(ElementName = "KullanilabilirNakitPuanTutari")]
        public string? KullanilabilirNakitPuanTutari { get; set; }
    }
}