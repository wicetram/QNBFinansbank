namespace QNBFinansbank.VirtualPos.Entity.Response.History
{
    /// <summary>
    /// İşlem geçmişi sorgulama sonucunu temsil eden veri transfer nesnesi.
    /// Bu sınıf, işlem geçmişi sorgulamasının sonucunu ve bu sonuca ait işlem geçmişi detaylarını içerir.
    /// </summary>
    public class HistoryResponseDto : IDto
    {
        /// <summary>
        /// İşlemin durumunu ve başarı bilgisini içeren bir <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, sorgulamanın başarılı olup olmadığını, hata mesajlarını ve ilgili bilgileri içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// İşlem geçmişine ait detayları içeren <see cref="HistoryResponseDataDto"/> nesnesi.
        /// Bu nesne, sorgulanan işlem geçmişi ile ilgili tüm detayları barındırır.
        /// </summary>
        public HistoryResponseDataDto? History { get; set; }
    }
}
