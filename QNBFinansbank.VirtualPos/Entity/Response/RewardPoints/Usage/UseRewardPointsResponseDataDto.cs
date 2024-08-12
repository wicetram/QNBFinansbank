namespace QNBFinansbank.VirtualPos.Entity.Response.RewardPoints.Usage
{
    /// <summary>
    /// Para puan kullanım işleminin yanıt verilerini içeren DTO sınıfı.
    /// Bu sınıf, işlemin genel sonucunu ve detaylı para puan kullanım yanıtını içerir.
    /// </summary>
    public class UseRewardPointsResponseDataDto : IDto
    {
        /// <summary>
        /// İşlemin sonucunu ve başarı durumunu içeren <see cref="ProcessResult"/> nesnesi.
        /// Bu nesne, para puan kullanım işleminin mevcut durumunu, başarı durumunu ve varsa hata mesajlarını içerir.
        /// </summary>
        public ProcessResult? Result { get; set; }

        /// <summary>
        /// Para puan kullanım işlemi sonucu elde edilen detaylı bilgileri içeren <see cref="UseRewardPointsResponseDto"/> nesnesi.
        /// Bu nesne, para puan kullanım işlemi sonucunda dönen tüm verileri içerir.
        /// </summary>
        public UseRewardPointsResponseDto? RewardPointsResponse { get; set; }
    }
}
