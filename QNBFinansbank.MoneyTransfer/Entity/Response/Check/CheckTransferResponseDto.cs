namespace QNBFinansbank.MoneyTransfer.Entity.Response.Check
{
    /// <summary>
    /// Para transfer kontrol işlemi sonucunu ve yanıt verilerini içeren DTO sınıfıdır.
    /// Bu sınıf, kontrol işleminin genel durumunu belirten işlem sonucunu ve detaylı yanıt verilerini içerir.
    /// </summary>
    public class CheckTransferResponseDto : IDto
    {
        /// <summary>
        /// Kontrol işleminin genel sonucunu belirten işlem durumu.
        /// Bu özellik, işlemin başarılı olup olmadığını ve ilgili hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// Para transfer kontrol işlemi sonucunda dönen detaylı yanıt verilerini içerir.
        /// Bu özellik, transfer edilen işlemlerin detaylarını içeren bilgileri içerir.
        /// </summary>
        public CheckTransferResponseDataDto? CheckTransferResponse { get; set; }

        /// <summary>
        /// Para transfer kontrol işlemine ait istek ve cevabı içerir
        /// Bu alan, işleme ait request ve response gibi bilgileri içerir
        /// </summary>
        public ApiLogDto? ApiLog { get; set; }
    }
}
