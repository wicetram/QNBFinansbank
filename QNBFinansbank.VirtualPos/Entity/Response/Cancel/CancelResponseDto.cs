namespace QNBFinansbank.VirtualPos.Entity.Response.Cancel
{
    public class CancelResponseDto : IDto
    {
        /// <summary>
        /// İptal işleminin sonucunu ve durum bilgilerini içeren bir <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, iptal işleminin başarı durumunu, işlem sonucunu ve varsa hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// İptal edilen işlemin detaylarını içeren bir <see cref="CancelResponseDataDto"/> nesnesi.
        /// Bu nesne, iptal işlemi ile ilgili spesifik bilgileri içerir, örneğin iptal edilen işlem ID'si ve diğer ilgili veriler.
        /// </summary>
        public CancelResponseDataDto? Cancel { get; set; }

        /// <summary>
        /// İptal edilen işlemine ait istek ve cevabı içerir
        /// Bu alan, işleme ait request ve response gibi bilgileri içerir
        /// </summary>
        public ApiLogDto? ApiLog { get; set; }
    }
}
