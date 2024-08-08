namespace QNBFinansbank.VirtualPos.Entity.Request
{
    public class CardDto : IDto
    {
        /// <summary>
        /// Kart numarası. 
        /// Bu, kredi veya banka kartının 16 haneli numarasını temsil eder.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? CardNo { get; set; }

        /// <summary>
        /// Kart sahibinin adı ve soyadı.
        /// Bu, kartın üzerinde yazılı olan kart sahibinin adını ve soyadını belirtir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? CardHolderName { get; set; }

        /// <summary>
        /// Kart güvenlik numarası (CVC/CVV).
        /// Bu, kartın arka yüzünde bulunan ve güvenlik amacıyla kullanılan 3 haneli numaradır.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? CVC { get; set; }

        /// <summary>
        /// Kartın son kullanım tarihi.
        /// Bu tarih, kartın geçerliliğinin sona erdiği tarihi belirtir ve genellikle MM/YY formatında olur.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? ExpireDate { get; set; }

        /// <summary>
        /// Kart sahibinin email adresi.
        /// Bu, kart sahibinin iletişim bilgisi olarak kullanılan e-posta adresidir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? Email { get; set; }
    }
}
