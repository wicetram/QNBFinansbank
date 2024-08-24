namespace QNBFinansbank.CashManagement.Entity.Response
{
    /// <summary>
    /// API istek ve yanıtlarını loglamak için kullanılan veri transfer nesnesidir (DTO).
    /// </summary>
    public class ApiLogDto : IDto
    {
        /// <summary>
        /// Log girişinin başlığını temsil eder.
        /// Bu alan genellikle işlemin adı veya türü gibi açıklayıcı bir metin içerir.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// API'ye gönderilen isteğin serileştirilmiş (serialized) halini içerir.
        /// İstek verileri genellikle JSON veya XML formatında olabilir.
        /// </summary>
        public string? Request { get; set; }

        /// <summary>
        /// API'den alınan yanıtın serileştirilmiş (serialized) halini içerir.
        /// Yanıt verileri genellikle JSON veya XML formatında olabilir.
        /// </summary>
        public string? Response { get; set; }
    }
}
