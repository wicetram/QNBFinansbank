namespace QNBFinansbank.VirtualPos.Entity.Response.PreAuth
{
    /// <summary>
    /// Ön otorizasyon (Pre-Auth) işleminin API yanıtını temsil eden veri transfer objesi (DTO) sınıfı.
    /// Bu sınıf, işlem sonucunu ve ön otorizasyon yanıtına ait detayları içerir.
    /// </summary>
    public class PreAuthResponseDto : IDto
    {
        /// <summary>
        /// İşlemin sonucunu temsil eden nesne.
        /// Bu alan, işlem sonucuna dair başarı veya hata bilgilerini içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// Ön otorizasyon yanıtına ait detayları temsil eden DTO.
        /// Bu alan, ön otorizasyon işlemi ile ilgili dönen verileri içerir.
        /// </summary>
        public PreAuthResponseDataDto? PreAuthResponse { get; set; }

        /// <summary>
        /// Ön otorizasyon işlemine ait istek ve cevabı içerir
        /// Bu alan, işleme ait request ve response gibi bilgileri içerir
        /// </summary>
        public ApiLogDto? ApiLog { get; set; }
    }
}
