namespace QNBFinansbank.VirtualPos.Entity.Response.RewardPoints.Check
{
    /// <summary>
    /// Para puan sorgulama işleminin yanıt verilerini içeren DTO sınıfı.
    /// Bu sınıf, işlemin genel sonucunu ve detaylı para puan bilgilerini içerir.
    /// </summary>
    public class CheckRewardPointsResponseDataDto : IDto
    {
        /// <summary>
        /// İşlemin sonucunu ve başarı durumunu içeren <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, ödeme işleminin mevcut durumunu, başarı durumunu ve varsa hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// Para puan sorgulama işlemi sonucu elde edilen detaylı bilgileri içeren <see cref="CheckRewardPointsResponseDto"/> nesnesi.
        /// Bu nesne, para puan sorgulama işlemi sonucunda dönen tüm verileri içerir.
        /// </summary>
        public CheckRewardPointsResponseDto? Rewards { get; set; }
    }
}
