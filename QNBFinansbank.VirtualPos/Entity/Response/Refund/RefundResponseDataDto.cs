using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Response.Refund
{
    /// <summary>
    /// İade (Refund) işlemine ait yanıt parametrelerini temsil eden DTO.
    /// Bu sınıf, iade işlemi sonucunda dönen tüm parametreleri içerir.
    /// </summary>
    [XmlRoot(ElementName = "PayforResponse")]
    public class RefundResponseDataDto : IDto
    {
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
        /// İşlem ID'si.
        /// İşlem için verilen 50 haneli benzersiz kimlik.
        /// </summary>
        [XmlElement(ElementName = "TransId")]
        public string? TransId { get; set; }

        /// <summary>
        /// Hata mesajı.
        /// İşlem başarısız olduğunda verilen maksimum 2048 karakter uzunluğundaki hata mesajı.
        /// </summary>
        [XmlElement(ElementName = "ErrMsg")]
        public string? ErrMsg { get; set; }

        /// <summary>
        /// Kart sahibinin adı.
        /// İşlemde kullanılan kartın sahibinin adı.
        /// </summary>
        [XmlElement(ElementName = "CardHolderName")]
        public string? CardHolderName { get; set; }

        /// <summary>
        /// Ekstra taksit sayısı.
        /// İşlem sırasında kullanılan ekstra taksit sayısı.
        /// </summary>
        [XmlElement(ElementName = "ArtiTaksit")]
        public string? ArtiTaksit { get; set; }

        /// <summary>
        /// Bankanın iç yanıt mesajı.
        /// Banka tarafından verilen işlemle ilgili ek bilgi içeren mesaj.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseMessage")]
        public string? BankInternalResponseMessage { get; set; }

        /// <summary>
        /// Payfor XML istek verisi.
        /// İşlem sırasında kullanılan orijinal XML istek verisi.
        /// </summary>
        [XmlElement(ElementName = "PAYFORFROMXMLREQUEST")]
        public string? PayForFromXMLRequest { get; set; }

        /// <summary>
        /// Sistem kullanıcı kodu.
        /// İşlemi gerçekleştiren sistem kullanıcısının kodu.
        /// </summary>
        [XmlElement(ElementName = "SESSION_SYSTEM_USER")]
        public string? SessionSystemUser { get; set; }

        /// <summary>
        /// Alt bayi MCC kodu.
        /// İşlemde kullanılan alt bayinin Merchant Category Code (MCC) değeri.
        /// </summary>
        [XmlElement(ElementName = "SubmerchantMCC")]
        public string? SubmerchantMCC { get; set; }

        /// <summary>
        /// Kart kabul eden işyerinin adı.
        /// Kart ekstresinde görüntülenecek işyeri adı.
        /// </summary>
        [XmlElement(ElementName = "CardAcceptorName")]
        public string? CardAcceptorName { get; set; }

        /// <summary>
        /// Kart kabul eden işyerinin şehri.
        /// İşlemi gerçekleştiren işyerinin şehir bilgisi.
        /// </summary>
        [XmlElement(ElementName = "CardAcceptorCity")]
        public string? CardAcceptorCity { get; set; }

        /// <summary>
        /// Kart kabul eden işyerinin bölgesi.
        /// İşlemi gerçekleştiren işyerinin eyalet veya bölge bilgisi.
        /// </summary>
        [XmlElement(ElementName = "CardAcceptorState")]
        public string? CardAcceptorState { get; set; }

        /// <summary>
        /// Kart kabul eden işyerinin posta kodu.
        /// İşlemi gerçekleştiren işyerinin posta kodu bilgisi.
        /// </summary>
        [XmlElement(ElementName = "CardAcceptorPostalCode")]
        public string? CardAcceptorPostalCode { get; set; }
    }
}
