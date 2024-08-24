namespace QNBFinansbank.VirtualPos.Entity.Response.EOD
{
    /// <summary>
    /// QNB Finansbank Sanal Pos üzerinden alınan EOD (End of Day) raporu verilerini temsil eder.
    /// Bu sınıf, bir rapor kaydı ile ilgili çeşitli bilgileri içerir.
    /// </summary>
    public class EODResponseDataDto : IDto
    {
        /// <summary>
        /// Rapor kaydının veritabanına eklenme tarih ve saatini temsil eder.
        /// Bu değer, "dd.MM.yyyy HH:mm:ss" formatında bir tarih ve saat stringidir.
        /// </summary>
        public string? InsertDatetime { get; set; }

        /// <summary>
        /// Rapor kaydına özgü global olarak benzersiz tanımlayıcıyı (GUID) temsil eder.
        /// </summary>
        public string? Guid { get; set; }

        /// <summary>
        /// Rapor kaydının durumunu temsil eder.
        /// Bu alan, genellikle bir işlem durumu kodu içerir.
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Rapor kaydının son güncellenme zamanını temsil eder.
        /// </summary>
        public string? LastUpdated { get; set; }

        /// <summary>
        /// Raporun oluşturulma tarih ve saatini temsil eder.
        /// Bu değer, "dd.MM.yyyy HH:mm" formatında bir tarih ve saat stringidir.
        /// </summary>
        public string? ReqDate { get; set; }

        /// <summary>
        /// Üye işyeri numarasını (MbrId) temsil eder.
        /// Bu değer, rapor kaydının hangi üye işyerine ait olduğunu belirtir.
        /// </summary>
        public string? MbrId { get; set; }

        /// <summary>
        /// Üye işyeri kodunu (MrcCode) temsil eder.
        /// Bu değer, rapor kaydının hangi işyeri koduna ait olduğunu belirtir.
        /// </summary>
        public string? MrcCode { get; set; }

        /// <summary>
        /// Terminal kodunu (TrmCode) temsil eder.
        /// Bu değer, işlemin yapıldığı terminalin kodunu belirtir.
        /// </summary>
        public string? TrmCode { get; set; }

        /// <summary>
        /// Batch numarasını (BatchNo) temsil eder.
        /// Bu değer, rapor kaydının ait olduğu batch numarasını belirtir.
        /// </summary>
        public string? BatchNo { get; set; }

        /// <summary>
        /// Döviz kodunu (CurrCode) temsil eder.
        /// Bu değer, işlemin yapıldığı döviz cinsini belirtir.
        /// </summary>
        public string? CurrCode { get; set; }

        /// <summary>
        /// Pozitif işlem sayısını temsil eder.
        /// Bu alan, başarılı işlemlerin sayısını belirtir.
        /// </summary>
        public string? PositiveCount { get; set; }

        /// <summary>
        /// Pozitif işlemlerin toplam tutarını temsil eder.
        /// Bu alan, başarılı işlemlerin toplam tutarını belirtir.
        /// </summary>
        public string? PositiveAmount { get; set; }

        /// <summary>
        /// Negatif işlem sayısını temsil eder.
        /// Bu alan, başarısız işlemlerin sayısını belirtir.
        /// </summary>
        public string? NegativeCount { get; set; }

        /// <summary>
        /// Negatif işlemlerin toplam tutarını temsil eder.
        /// Bu alan, başarısız işlemlerin toplam tutarını belirtir.
        /// </summary>
        public string? NegativeAmount { get; set; }

        /// <summary>
        /// Toplam işlemlerin tutarını temsil eder.
        /// Bu alan, tüm işlemlerin toplam tutarını belirtir.
        /// </summary>
        public string? TotalAmount { get; set; }

        /// <summary>
        /// Toplam işlem sayısını temsil eder.
        /// Bu alan, tüm işlemlerin sayısını belirtir.
        /// </summary>
        public string? TotalCount { get; set; }

        /// <summary>
        /// İşlem geri dönüş kodunu (ProcReturnCode) temsil eder.
        /// Bu değer, işlemin sonucunu belirten kodu belirtir.
        /// </summary>
        public string? ProcReturnCode { get; set; }

        /// <summary>
        /// Batch işleminin durumunu temsil eder.
        /// Bu alan, batch işleminin durumunu belirtir.
        /// </summary>
        public string? BatchStatus { get; set; }

        /// <summary>
        /// İşlem deneme sayısını temsil eder.
        /// Bu alan, işlem için yapılan deneme sayısını belirtir.
        /// </summary>
        public string? TryCount { get; set; }

        /// <summary>
        /// İşlem kaynağını temsil eder.
        /// Bu alan, işlemin EOD (End of Day) veya VPO (Virtual Point of Sale) olup olmadığını belirtir.
        /// </summary>
        public string? SrcType { get; set; }

        /// <summary>
        /// Mevcut verilerin ekleme sırasında kullanılıp kullanılmadığını belirten bayrağı temsil eder.
        /// Bu alan, işlemin mevcut veriler kullanılarak mı yoksa yeni verilerle mi yapıldığını belirtir.
        /// </summary>
        public string? UseExistingDataWhenInserting { get; set; }
    }
}