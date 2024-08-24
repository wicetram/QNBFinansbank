using Newtonsoft.Json;

namespace QNBFinansbank.MoneyTransfer.Entity.Request.Check
{
    /// <summary>
    /// Para transfer kontrol işlemi için gerekli olan verileri içeren DTO sınıfıdır.
    /// Bu sınıf, transferlerin kontrol edilmesi için gereken hesap numarası, firma referans numarası, tarih aralığı gibi bilgileri içerir.
    /// </summary>
    public class CheckTransferRequestDataDto : IDto
    {
        /// <summary>
        /// Kontrol edilecek transferin hesap numarası.
        /// </summary>
        [JsonProperty("accountNumber")]
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Kontrol edilecek transferin firma referans numarası.
        /// </summary>
        [JsonProperty("firmReferansNumber")]
        public string? FirmReferansNumber { get; set; }

        /// <summary>
        /// Transferin paket kimliği.
        /// </summary>
        [JsonProperty("packedId")]
        public string? PackedId { get; set; }

        /// <summary>
        /// API sürüm numarası.
        /// </summary>
        [JsonProperty("versionNumber")]
        public string? VersionNumber { get; set; }

        /// <summary>
        /// Kontrol edilecek transferlerin başlangıç tarihi (yyyyMMdd formatında).
        /// </summary>
        [JsonProperty("startDate")]
        public string? StartDate { get; set; }

        /// <summary>
        /// Kontrol edilecek transferlerin bitiş tarihi (yyyyMMdd formatında).
        /// </summary>
        [JsonProperty("endDate")]
        public string? EndDate { get; set; }

        /// <summary>
        /// Firmanın kodu.
        /// </summary>
        [JsonProperty("firmCode")]
        public string? FirmCode { get; set; }
    }
}
