namespace QNBFinansbank.VirtualPos.Entity.Response.Payment.ThreeD.ModelPayment
{
    /// <summary>
    /// 3D Model Payment işlemi yanıtını temsil eden DTO sınıfı.
    /// Bu sınıf, işlem sonucunu ve 3D Model Payment yanıt verilerini içerir.
    /// </summary>
    public class ThreeDModelPaymentResponseDto : IDto
    {
        /// <summary>
        /// İşlemin durumunu ve başarı bilgisini içeren bir <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, ödeme işleminin mevcut durumunu, başarı durumunu ve varsa hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// 3D Model Payment işlemi sonucunda dönen yanıt verilerini içeren nesne.
        /// Bu nesne, işlemin ayrıntılı yanıt verilerini kapsar.
        /// </summary>
        public ThreeDModelPaymentResponseDataDto? ThreeDModelPayment { get; set; }

        /// <summary>
        /// 3D Model Payment işlemine ait istek ve cevabı içerir
        /// Bu alan, işleme ait request ve response gibi bilgileri içerir
        /// </summary>
        public ApiLogDto? ApiLog { get; set; }
    }
}
