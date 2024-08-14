using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Response.Check
{
    /// <summary>
    /// Sipariş Sorgulama (Order Inquiry) işlemine ait yanıt parametrelerini temsil eden DTO.
    /// Bu sınıf, sipariş sorgulama işlemi sonucunda dönen tüm parametreleri içerir.
    /// </summary>
    [XmlRoot(ElementName = "PayforResponse")]
    public class CheckResponseDataDto : IDto
    {
        /// <summary>
        /// İstek için oluşturulmuş benzersiz GUID.
        /// </summary>
        [XmlElement(ElementName = "RequestGuid")]
        public string? RequestGuid { get; set; }

        /// <summary>
        /// İşlemin sisteme kaydedildiği tarih ve saat bilgisi.
        /// </summary>
        [XmlElement(ElementName = "InsertDatetime")]
        public string? InsertDatetime { get; set; }

        /// <summary>
        /// Kurum kodudur.
        /// Banka tarafından verilen 4 karakter uzunluğunda benzersiz kod.
        /// </summary>
        [XmlElement(ElementName = "MbrId")]
        public string? MbrId { get; set; }

        /// <summary>
        /// Üye işyeri numarası.
        /// Bankadan temin edilen 15 karaktere kadar uzunlukta olabilen benzersiz numara.
        /// </summary>
        [XmlElement(ElementName = "MerchantID")]
        public string? MerchantID { get; set; }

        /// <summary>
        /// Sipariş Numarası.
        /// İşleme özgü olarak üretilen benzersiz numara.
        /// </summary>
        [XmlElement(ElementName = "OrderId")]
        public string? OrderId { get; set; }

        /// <summary>
        /// İstek IP adresi.
        /// İşlemin yapıldığı IP adresi.
        /// </summary>
        [XmlElement(ElementName = "RequestIp")]
        public string? RequestIp { get; set; }

        /// <summary>
        /// İstek durumu.
        /// İşlemin durumu hakkında bilgi.
        /// </summary>
        [XmlElement(ElementName = "RequestStat")]
        public string? RequestStat { get; set; }

        /// <summary>
        /// İşlemin güvenlik türü.
        /// Örneğin, NonSecure veya 3D Secure.
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
        /// Exponent değeri.
        /// İşlemde kullanılan exponent bilgisi.
        /// </summary>
        [XmlElement(ElementName = "Exponent")]
        public string? Exponent { get; set; }

        /// <summary>
        /// Kur bilgisi.
        /// Döviz kodunu belirtir. Örneğin, TL için "949".
        /// </summary>
        [XmlElement(ElementName = "Currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// İşlem açıklaması.
        /// İşlemin açıklama bilgisi.
        /// </summary>
        [XmlElement(ElementName = "Description")]
        public string? Description { get; set; }

        /// <summary>
        /// İşlem başarılı olduğunda yönlendirme yapılacak URL.
        /// </summary>
        [XmlElement(ElementName = "OkUrl")]
        public string? OkUrl { get; set; }

        /// <summary>
        /// İşlem başarısız olduğunda yönlendirme yapılacak URL.
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
        /// ECI değeri.
        /// Elektronik Ticaret Göstergesi (ECI) değeri.
        /// </summary>
        [XmlElement(ElementName = "Eci")]
        public string? Eci { get; set; }

        /// <summary>
        /// MD değeri.
        /// 3D Secure işleminde kullanılan Merchant Data (MD) bilgisi.
        /// </summary>
        [XmlElement(ElementName = "MD")]
        public string? MD { get; set; }

        /// <summary>
        /// Hash değeri.
        /// İşlem için hesaplanan hash değeri.
        /// </summary>
        [XmlElement(ElementName = "Hash")]
        public string? Hash { get; set; }

        /// <summary>
        /// Terminal ID değeri.
        /// İşlemde kullanılan terminal kimliği.
        /// </summary>
        [XmlElement(ElementName = "TerminalID")]
        public string? TerminalID { get; set; }

        /// <summary>
        /// İşlem tipi.
        /// Örneğin, sipariş sorgulama işlemi için "OrderInquiry" olarak kullanılır.
        /// </summary>
        [XmlElement(ElementName = "TxnType")]
        public string? TxnType { get; set; }

        /// <summary>
        /// Orijinal sipariş numarası (Eğer mevcutsa).
        /// </summary>
        [XmlElement(ElementName = "OrgOrderId")]
        public string? OrgOrderId { get; set; }

        /// <summary>
        /// Alt bayi kodu.
        /// </summary>
        [XmlElement(ElementName = "SubMerchantCode")]
        public string? SubMerchantCode { get; set; }

        /// <summary>
        /// Tekrarlayan işlemler için frekans değeri.
        /// </summary>
        [XmlElement(ElementName = "recur_frequency")]
        public string? RecurFrequency { get; set; }

        /// <summary>
        /// Tekrarlayan işlemler için bitiş süresi.
        /// </summary>
        [XmlElement(ElementName = "recur_expiry")]
        public string? RecurExpiry { get; set; }

        /// <summary>
        /// Kart tipi.
        /// İşlemde kullanılan kart türü (Visa, MasterCard, vb.).
        /// </summary>
        [XmlElement(ElementName = "CardType")]
        public string? CardType { get; set; }

        /// <summary>
        /// Kullanıcı dil bilgisi.
        /// Maksimum 2 karakter uzunluğunda olup, Türkçe için "TR", İngilizce için "EN" değerlerini alabilir.
        /// </summary>
        [XmlElement(ElementName = "Lang")]
        public string? Lang { get; set; }

        /// <summary>
        /// Bonus tutarı.
        /// İşlemde kullanılan bonus miktarı.
        /// </summary>
        [XmlElement(ElementName = "BonusAmount")]
        public string? BonusAmount { get; set; }

        /// <summary>
        /// Taksit sayısı.
        /// İşlemde kullanılan taksit sayısı.
        /// </summary>
        [XmlElement(ElementName = "InstallmentCount")]
        public string? InstallmentCount { get; set; }

        /// <summary>
        /// Rastgele değer.
        /// İşlem sırasında kullanılan rastgele değer (random).
        /// </summary>
        [XmlElement(ElementName = "Rnd")]
        public string? Rnd { get; set; }

        /// <summary>
        /// Alfa kodu.
        /// İşlemde kullanılan alfa kodu.
        /// </summary>
        [XmlElement(ElementName = "AlphaCode")]
        public string? AlphaCode { get; set; }

        /// <summary>
        /// E-ticaret işlemi olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "Ecommerce")]
        public string? Ecommerce { get; set; }

        /// <summary>
        /// Üye işyeri ülke kodu.
        /// </summary>
        [XmlElement(ElementName = "MrcCountryCode")]
        public string? MrcCountryCode { get; set; }

        /// <summary>
        /// Üye işyeri adı.
        /// </summary>
        [XmlElement(ElementName = "MrcName")]
        public string? MrcName { get; set; }

        /// <summary>
        /// Üye işyeri ana URL bilgisi.
        /// </summary>
        [XmlElement(ElementName = "MerchantHomeUrl")]
        public string? MerchantHomeUrl { get; set; }

        /// <summary>
        /// Kart sahibinin adı.
        /// İşlemde kullanılan kartın sahibinin adı.
        /// </summary>
        [XmlElement(ElementName = "CardHolderName")]
        public string? CardHolderName { get; set; }

        /// <summary>
        /// IRC detay bilgisi.
        /// </summary>
        [XmlElement(ElementName = "IrcDet")]
        public string? IrcDet { get; set; }

        /// <summary>
        /// IRC kodu.
        /// </summary>
        [XmlElement(ElementName = "IrcCode")]
        public string? IrcCode { get; set; }

        /// <summary>
        /// Sürüm bilgisi.
        /// </summary>
        [XmlElement(ElementName = "Version")]
        public string? Version { get; set; }

        /// <summary>
        /// İşlem durumu.
        /// </summary>
        [XmlElement(ElementName = "TxnStatus")]
        public string? TxnStatus { get; set; }

        /// <summary>
        /// CAVV algoritması.
        /// </summary>
        [XmlElement(ElementName = "CavvAlg")]
        public string? CavvAlg { get; set; }

        /// <summary>
        /// PARES doğrulaması.
        /// </summary>
        [XmlElement(ElementName = "ParesVerified")]
        public string? ParesVerified { get; set; }

        /// <summary>
        /// PARES söz dizimi kontrolü.
        /// </summary>
        [XmlElement(ElementName = "ParesSyntaxOk")]
        public string? ParesSyntaxOk { get; set; }

        /// <summary>
        /// Hata mesajı.
        /// İşlem başarısız olduğunda verilen hata mesajı.
        /// </summary>
        [XmlElement(ElementName = "ErrMsg")]
        public string? ErrMsg { get; set; }

        /// <summary>
        /// Satıcı detayı.
        /// </summary>
        [XmlElement(ElementName = "VendorDet")]
        public string? VendorDet { get; set; }

        /// <summary>
        /// 3D Secure durum bilgisi.
        /// </summary>
        [XmlElement(ElementName = "D3Status")]
        public string? D3Status { get; set; }

        /// <summary>
        /// İşlem sonucu.
        /// Örneğin, "Success" veya "Failed".
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
        /// İşlem başarılıysa "00" döner. Maksimum 7 karakter uzunluğunda.
        /// </summary>
        [XmlElement(ElementName = "ProcReturnCode")]
        public string? ProcReturnCode { get; set; }

        /// <summary>
        /// İade edilecek URL.
        /// </summary>
        [XmlElement(ElementName = "ReturnUrl")]
        public string? ReturnUrl { get; set; }

        /// <summary>
        /// Hata verisi.
        /// </summary>
        [XmlElement(ElementName = "ErrorData")]
        public string? ErrorData { get; set; }

        /// <summary>
        /// Batch numarası.
        /// İşlem batch numarası.
        /// </summary>
        [XmlElement(ElementName = "BatchNo")]
        public string? BatchNo { get; set; }

        /// <summary>
        /// İptal tarihi.
        /// </summary>
        [XmlElement(ElementName = "VoidDate")]
        public string? VoidDate { get; set; }

        /// <summary>
        /// Kart numarası maskesi.
        /// </summary>
        [XmlElement(ElementName = "CardMask")]
        public string? CardMask { get; set; }

        /// <summary>
        /// İstek ID'si.
        /// </summary>
        [XmlElement(ElementName = "ReqId")]
        public string? ReqId { get; set; }

        /// <summary>
        /// Kullanılan puan miktarı.
        /// </summary>
        [XmlElement(ElementName = "UsedPoint")]
        public string? UsedPoint { get; set; }

        /// <summary>
        /// Kaynak türü.
        /// Örneğin, VPO.
        /// </summary>
        [XmlElement(ElementName = "SrcType")]
        public string? SrcType { get; set; }

        /// <summary>
        /// İade edilen tutar.
        /// </summary>
        [XmlElement(ElementName = "RefundedAmount")]
        public string? RefundedAmount { get; set; }

        /// <summary>
        /// İade edilen puan miktarı.
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
        /// F11 alanı değeri.
        /// </summary>
        [XmlElement(ElementName = "F11")]
        public string? F11 { get; set; }

        /// <summary>
        /// F37 alanı değeri.
        /// </summary>
        [XmlElement(ElementName = "F37")]
        public string? F37 { get; set; }

        /// <summary>
        /// Tekrar eden işlem olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "IsRepeatTxn")]
        public string? IsRepeatTxn { get; set; }

        /// <summary>
        /// CAVV sonucu.
        /// </summary>
        [XmlElement(ElementName = "CavvResult")]
        public string? CavvResult { get; set; }

        /// <summary>
        /// VPOS süre bilgisi (milisaniye cinsinden).
        /// </summary>
        [XmlElement(ElementName = "VposElapsedTime")]
        public string? VposElapsedTime { get; set; }

        /// <summary>
        /// Bankacılık süre bilgisi (milisaniye cinsinden).
        /// </summary>
        [XmlElement(ElementName = "BankingElapsedTime")]
        public string? BankingElapsedTime { get; set; }

        /// <summary>
        /// Socket süre bilgisi (milisaniye cinsinden).
        /// </summary>
        [XmlElement(ElementName = "SocketElapsedTime")]
        public string? SocketElapsedTime { get; set; }

        /// <summary>
        /// HSM süre bilgisi (milisaniye cinsinden).
        /// </summary>
        [XmlElement(ElementName = "HsmElapsedTime")]
        public string? HsmElapsedTime { get; set; }

        /// <summary>
        /// MPI süre bilgisi (milisaniye cinsinden).
        /// </summary>
        [XmlElement(ElementName = "MpiElapsedTime")]
        public string? MpiElapsedTime { get; set; }

        /// <summary>
        /// Sipariş ID'sinin olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "hasOrderId")]
        public string? HasOrderId { get; set; }

        /// <summary>
        /// Şablon tipi.
        /// </summary>
        [XmlElement(ElementName = "TemplateType")]
        public string? TemplateType { get; set; }

        /// <summary>
        /// Adres sayısı olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "HasAddressCount")]
        public string? HasAddressCount { get; set; }

        /// <summary>
        /// Ödeme aracısı olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "IsPaymentFacilitator")]
        public string? IsPaymentFacilitator { get; set; }

        /// <summary>
        /// Üye işyeri ülke kodu.
        /// </summary>
        [XmlElement(ElementName = "MerchantCountryCode")]
        public string? MerchantCountryCode { get; set; }

        /// <summary>
        /// Orijinal işlem tipi.
        /// </summary>
        [XmlElement(ElementName = "OrgTxnType")]
        public string? OrgTxnType { get; set; }

        /// <summary>
        /// F11 ORG alanı değeri.
        /// </summary>
        [XmlElement(ElementName = "F11_ORG")]
        public string? F11ORG { get; set; }

        /// <summary>
        /// F12 ORG alanı değeri.
        /// </summary>
        [XmlElement(ElementName = "F12_ORG")]
        public string? F12ORG { get; set; }

        /// <summary>
        /// F13 ORG alanı değeri.
        /// </summary>
        [XmlElement(ElementName = "F13_ORG")]
        public string? F13ORG { get; set; }

        /// <summary>
        /// F22 ORG alanı değeri.
        /// </summary>
        [XmlElement(ElementName = "F22_ORG")]
        public string? F22ORG { get; set; }

        /// <summary>
        /// F25 ORG alanı değeri.
        /// </summary>
        [XmlElement(ElementName = "F25_ORG")]
        public string? F25ORG { get; set; }

        /// <summary>
        /// MTI ORG alanı değeri.
        /// </summary>
        [XmlElement(ElementName = "MTI_ORG")]
        public string? MTIORG { get; set; }

        /// <summary>
        /// DS marka bilgisi.
        /// </summary>
        [XmlElement(ElementName = "DsBrand")]
        public string? DsBrand { get; set; }

        /// <summary>
        /// Aralık türü.
        /// Tekrarlayan işlem için kullanılan aralık türü.
        /// </summary>
        [XmlElement(ElementName = "IntervalType")]
        public string? IntervalType { get; set; }

        /// <summary>
        /// Aralık süresi.
        /// Tekrarlayan işlem için kullanılan aralık süresi.
        /// </summary>
        [XmlElement(ElementName = "IntervalDuration")]
        public string? IntervalDuration { get; set; }

        /// <summary>
        /// Tekrar sayısı.
        /// Tekrarlayan işlem için kullanılan tekrar sayısı.
        /// </summary>
        [XmlElement(ElementName = "RepeatCount")]
        public string? RepeatCount { get; set; }

        /// <summary>
        /// Müşteri kodu.
        /// </summary>
        [XmlElement(ElementName = "CustomerCode")]
        public string? CustomerCode { get; set; }

        /// <summary>
        /// İstek üye işyeri domaini.
        /// </summary>
        [XmlElement(ElementName = "RequestMerchantDomain")]
        public string? RequestMerchantDomain { get; set; }

        /// <summary>
        /// İstek müşteri IP adresi.
        /// </summary>
        [XmlElement(ElementName = "RequestClientIp")]
        public string? RequestClientIp { get; set; }

        /// <summary>
        /// Yanıt rastgele değeri.
        /// </summary>
        [XmlElement(ElementName = "ResponseRnd")]
        public string? ResponseRnd { get; set; }

        /// <summary>
        /// Yanıt hash değeri.
        /// </summary>
        [XmlElement(ElementName = "ResponseHash")]
        public string? ResponseHash { get; set; }

        /// <summary>
        /// Banka iç yanıt kodu.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseCode")]
        public string? BankInternalResponseCode { get; set; }

        /// <summary>
        /// Banka iç yanıt mesajı.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseMessage")]
        public string? BankInternalResponseMessage { get; set; }

        /// <summary>
        /// Banka iç yanıt alt kodu.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseSubcode")]
        public string? BankInternalResponseSubcode { get; set; }

        /// <summary>
        /// Banka iç yanıt alt mesajı.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseSubmessage")]
        public string? BankInternalResponseSubmessage { get; set; }

        /// <summary>
        /// Bayi kodu.
        /// </summary>
        [XmlElement(ElementName = "BayiKodu")]
        public string? BayiKodu { get; set; }

        /// <summary>
        /// İptal süresi.
        /// </summary>
        [XmlElement(ElementName = "VoidTime")]
        public string? VoidTime { get; set; }

        /// <summary>
        /// İptal kullanıcı kodu.
        /// </summary>
        [XmlElement(ElementName = "VoidUserCode")]
        public string? VoidUserCode { get; set; }

        /// <summary>
        /// Ödeme bağlantı ID'si.
        /// </summary>
        [XmlElement(ElementName = "PaymentLinkId")]
        public string? PaymentLinkId { get; set; }

        /// <summary>
        /// İstemci ID'si.
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
        /// FAST gönderen IBAN.
        /// </summary>
        [XmlElement(ElementName = "FastGonderenIBAN")]
        public string? FastGonderenIBAN { get; set; }

        /// <summary>
        /// FAST gönderen adı.
        /// </summary>
        [XmlElement(ElementName = "FASTGonderenAdi")]
        public string? FASTGonderenAdi { get; set; }

        /// <summary>
        /// Mobil ECI değeri.
        /// </summary>
        [XmlElement(ElementName = "MobileECI")]
        public string? MobileECI { get; set; }

        /// <summary>
        /// Hub bağlantı ID'si.
        /// </summary>
        [XmlElement(ElementName = "HubConnId")]
        public string? HubConnId { get; set; }

        /// <summary>
        /// Cüzdan verisi.
        /// </summary>
        [XmlElement(ElementName = "WalletData")]
        public string? WalletData { get; set; }

        /// <summary>
        /// TDS 2DS işlem ID'si.
        /// </summary>
        [XmlElement(ElementName = "Tds2dsTransId")]
        public string? Tds2dsTransId { get; set; }

        /// <summary>
        /// 3D Host işlemi olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "Is3DHost")]
        public string? Is3DHost { get; set; }

        /// <summary>
        /// Ekstra taksit sayısı.
        /// İşlem sırasında kullanılan ekstra taksit sayısı.
        /// </summary>
        [XmlElement(ElementName = "ArtiTaksit")]
        public string? ArtiTaksit { get; set; }

        /// <summary>
        /// Yetkilendirme ID'si.
        /// </summary>
        [XmlElement(ElementName = "AuthId")]
        public string? AuthId { get; set; }

        /// <summary>
        /// Payfor XML istek verisi.
        /// İşlem sırasında kullanılan orijinal XML istek verisi.
        /// </summary>
        [XmlElement(ElementName = "PAYFORFROMXMLREQUEST")]
        public int PayForFromXMLRequest { get; set; }

        /// <summary>
        /// İptal edilip edilmediğini belirtir.
        /// </summary>
        [XmlElement(ElementName = "IsVoided")]
        public string? IsVoided { get; set; }

        /// <summary>
        /// İade edilip edilmediğini belirtir.
        /// </summary>
        [XmlElement(ElementName = "IsRefunded")]
        public string? IsRefunded { get; set; }

        /// <summary>
        /// İşlem tarihi.
        /// İşlemin gerçekleştiği tarih.
        /// </summary>
        [XmlElement(ElementName = "TrxDate")]
        public string? TrxDate { get; set; }

        /// <summary>
        /// Dönüş mesajı.
        /// İşlemin sonucuna dair dönüş mesajı.
        /// </summary>
        [XmlElement(ElementName = "ReturnMessage")]
        public string? ReturnMessage { get; set; }
    }
}