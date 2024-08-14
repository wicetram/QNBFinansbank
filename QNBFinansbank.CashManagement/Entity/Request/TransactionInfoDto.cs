namespace QNBFinansbank.CashManagement.Entity.Request
{
    /// <summary>
    /// İşlem bilgilerini içeren veri transfer nesnesi (DTO).
    /// Bu sınıf, bir işlemle ilgili başlangıç ve bitiş tarihlerini tutar.
    /// Nakit yönetimi işlemlerinde belirli bir tarih aralığını sorgulamak için kullanılır.
    /// </summary>
    public class TransactionInfoDto : IDto
    {
        /// <summary>
        /// İşlem aralığı için başlangıç tarihi. 
        /// Bu alan, işlem sorgulamalarında başlangıç tarihini belirtir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// İşlem aralığı için bitiş tarihi. 
        /// Bu alan, işlem sorgulamalarında bitiş tarihini belirtir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
