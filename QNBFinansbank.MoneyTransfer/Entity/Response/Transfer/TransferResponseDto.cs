namespace QNBFinansbank.MoneyTransfer.Entity.Response.Transfer
{
    /// <summary>
    /// Para transfer işleminin sonucunu ve yanıt verilerini içeren DTO sınıfıdır.
    /// Bu sınıf, transfer işleminin genel durumunu belirten işlem sonucunu ve detaylı yanıt verilerini içerir.
    /// </summary>
    public class TransferResponseDto : IDto
    {
        /// <summary>
        /// Transfer işleminin genel sonucunu belirten işlem durumu.
        /// Bu özellik, işlemin başarılı olup olmadığını ve ilgili hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// Transfer işlemi sonucunda dönen detaylı yanıt verilerini içerir.
        /// Bu özellik, makbuz numarası, sonuç kodu, sonuç açıklaması gibi bilgileri içerir.
        /// </summary>
        public TransferResponseDataDto? Transfer { get; set; }

        /// <summary>
        /// Para transfer işlemine ait istek ve cevabı içerir
        /// Bu alan, işleme ait request ve response gibi bilgileri içerir
        /// </summary>
        public ApiLogDto? ApiLog { get; set; }
    }
}
