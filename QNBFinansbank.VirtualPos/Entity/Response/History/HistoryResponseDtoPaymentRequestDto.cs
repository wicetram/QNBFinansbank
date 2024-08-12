namespace QNBFinansbank.VirtualPos.Entity.Response.History
{
    /// <summary>
    /// İşlem geçmişine ait ödeme isteği detaylarını temsil eder.
    /// Bu sınıf, ödeme işlemi sırasında toplanan ve saklanan çeşitli bilgileri içerir.
    /// </summary>
    public class HistoryResponseDtoPaymentRequestDto : IDto
    {
        /// <summary>
        /// İşlem için benzersiz GUID.
        /// </summary>
        public string? RequestGuid { get; set; }

        /// <summary>
        /// İsteğin oluşturulma tarihi ve saati.
        /// </summary>
        public string? InsertDatetime { get; set; }

        /// <summary>
        /// Kurum kodu. (Banka tarafından verilir)
        /// </summary>
        public string? MbrId { get; set; }

        /// <summary>
        /// Üye işyeri numarası. (Bankadan temin edilir)
        /// </summary>
        public string? MerchantID { get; set; }

        /// <summary>
        /// İşleme ait sipariş numarası.
        /// </summary>
        public string? OrderId { get; set; }

        /// <summary>
        /// İsteğin gönderildiği IP adresi.
        /// </summary>
        public string? RequestIp { get; set; }

        /// <summary>
        /// İsteğin durumu.
        /// </summary>
        public string? RequestStat { get; set; }

        /// <summary>
        /// İşlemin güvenlik türü. (Örneğin, 3D Secure)
        /// </summary>
        public string? SecureType { get; set; }

        /// <summary>
        /// İşlemin para biriminin üssel değeri.
        /// </summary>
        public string? Exponent { get; set; }

        /// <summary>
        /// İşlemin yapıldığı para birimi.
        /// </summary>
        public string? Currency { get; set; }

        /// <summary>
        /// İşlemi gerçekleştiren terminal numarası.
        /// </summary>
        public string? TerminalID { get; set; }

        /// <summary>
        /// İşlem tipi (örneğin, satış, iade).
        /// </summary>
        public string? TxnType { get; set; }

        /// <summary>
        /// Orijinal sipariş numarası (iade veya iptal durumunda).
        /// </summary>
        public string? OrgOrderId { get; set; }

        /// <summary>
        /// Kart tipi (örneğin, kredi kartı, banka kartı).
        /// </summary>
        public string? CardType { get; set; }

        /// <summary>
        /// Kullanıcının dili. (Türkçe: TR, İngilizce: EN)
        /// </summary>
        public string? Lang { get; set; }

        /// <summary>
        /// İşlem sırasında kullanılan bonus miktarı.
        /// </summary>
        public string? BonusAmount { get; set; }

        /// <summary>
        /// Taksit sayısı.
        /// </summary>
        public string? InstallmentCount { get; set; }

        /// <summary>
        /// Alfanumerik kod.
        /// </summary>
        public string? AlphaCode { get; set; }

        /// <summary>
        /// E-ticaret işlemi olup olmadığını belirten bilgi.
        /// </summary>
        public string? Ecommerce { get; set; }

        /// <summary>
        /// Üye işyerinin bulunduğu ülke kodu.
        /// </summary>
        public string? MrcCountryCode { get; set; }

        /// <summary>
        /// Üye işyerinin adı.
        /// </summary>
        public string? MrcName { get; set; }

        /// <summary>
        /// Üye işyerinin web sitesi URL'si.
        /// </summary>
        public string? MerchantHomeUrl { get; set; }

        /// <summary>
        /// İşleme ait hata detayı.
        /// </summary>
        public string? IrcDet { get; set; }

        /// <summary>
        /// İşleme ait hata kodu.
        /// </summary>
        public string? IrcCode { get; set; }

        /// <summary>
        /// İşlemin durumu.
        /// </summary>
        public string? TxnStatus { get; set; }

        /// <summary>
        /// İşleme ait hata mesajı.
        /// </summary>
        public string? ErrMsg { get; set; }

        /// <summary>
        /// İşlem sonucu.
        /// </summary>
        public string? TxnResult { get; set; }

        /// <summary>
        /// İşlemin cevap kodu: Başarılıysa "00" döner.
        /// </summary>
        public string? ProcReturnCode { get; set; }

        /// <summary>
        /// İşlem grubunun numarası.
        /// </summary>
        public string? BatchNo { get; set; }

        /// <summary>
        /// İsteğin ID'si.
        /// </summary>
        public string? ReqId { get; set; }

        /// <summary>
        /// Kullanılan puan miktarı.
        /// </summary>
        public string? UsedPoint { get; set; }

        /// <summary>
        /// Kaynak tipi.
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
        /// İsteğin tarihi.
        /// </summary>
        public string? ReqDate { get; set; }

        /// <summary>
        /// Sistemin yanıt verdiği tarih.
        /// </summary>
        public string? SysDate { get; set; }

        /// <summary>
        /// Ek alan 11.
        /// </summary>
        public string? F11 { get; set; }

        /// <summary>
        /// POS sisteminde geçen süre.
        /// </summary>
        public string? VposElapsedTime { get; set; }

        /// <summary>
        /// Banka işlem süresi.
        /// </summary>
        public string? BankingElapsedTime { get; set; }

        /// <summary>
        /// Socket işlem süresi.
        /// </summary>
        public string? SocketElapsedTime { get; set; }

        /// <summary>
        /// HSM işlem süresi.
        /// </summary>
        public string? HsmElapsedTime { get; set; }

        /// <summary>
        /// MPI işlem süresi.
        /// </summary>
        public string? MpiElapsedTime { get; set; }

        /// <summary>
        /// Sipariş ID'si olup olmadığını belirten bilgi.
        /// </summary>
        public string? hasOrderId { get; set; }

        /// <summary>
        /// Şablon tipi.
        /// </summary>
        public string? TemplateType { get; set; }

        /// <summary>
        /// Adres sayısı bilgisi.
        /// </summary>
        public string? HasAddressCount { get; set; }

        /// <summary>
        /// Ödeme kolaylaştırıcısı olup olmadığını belirten bilgi.
        /// </summary>
        public string? IsPaymentFacilitator { get; set; }

        /// <summary>
        /// Orijinal F11 alanı.
        /// </summary>
        public string? F11_ORG { get; set; }

        /// <summary>
        /// Orijinal F12 alanı.
        /// </summary>
        public string? F12_ORG { get; set; }

        /// <summary>
        /// Orijinal F22 alanı.
        /// </summary>
        public string? F22_ORG { get; set; }

        /// <summary>
        /// Orijinal F25 alanı.
        /// </summary>
        public string? F25_ORG { get; set; }

        /// <summary>
        /// Orijinal MTI alanı.
        /// </summary>
        public string? MTI_ORG { get; set; }

        /// <summary>
        /// Aralık tipi.
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
        /// İsteğin yapıldığı istemci IP adresi.
        /// </summary>
        public string? RequestClientIp { get; set; }

        /// <summary>
        /// İşlemin iptal edildiği zaman.
        /// </summary>
        public string? VoidTime { get; set; }

        /// <summary>
        /// Ödeme linki ID'si.
        /// </summary>
        public string? PaymentLinkId { get; set; }

        /// <summary>
        /// Ek taksit bilgisi.
        /// </summary>
        public string? ArtiTaksit { get; set; }
    }
}
