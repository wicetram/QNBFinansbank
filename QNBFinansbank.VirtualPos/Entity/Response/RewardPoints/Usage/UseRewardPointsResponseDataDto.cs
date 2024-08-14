using System.Xml.Serialization;

namespace QNBFinansbank.VirtualPos.Entity.Response.RewardPoints.Usage
{
    /// <summary>
    /// Para puan kullanım işleminin yanıt verilerini içeren DTO sınıfı.
    /// Bu sınıf, işlemin sonucunu ve işlemle ilgili detaylı bilgileri içerir.
    /// </summary>
    [XmlRoot(ElementName = "PayforResponse")]
    public class UseRewardPointsResponseDataDto : IDto
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
        /// İşlem başarılıysa "00" döner.
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
        /// İşlem başarısız olduğunda verilen hata mesajı.
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
        /// Ekstra taksit bilgisi.
        /// İşlemde ek taksit olup olmadığını belirtir.
        /// </summary>
        [XmlElement(ElementName = "ArtiTaksit")]
        public string? ArtiTaksit { get; set; }

        /// <summary>
        /// Banka içi yanıt mesajı.
        /// İşlem sırasında bankadan alınan iç mesaj.
        /// </summary>
        [XmlElement(ElementName = "BankInternalResponseMessage")]
        public string? BankInternalResponseMessage { get; set; }
    }
}
