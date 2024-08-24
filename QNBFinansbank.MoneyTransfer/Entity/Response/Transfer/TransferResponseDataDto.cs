using Newtonsoft.Json;

namespace QNBFinansbank.MoneyTransfer.Entity.Response.Transfer
{
    /// <summary>
    /// Para transfer işleminin yanıt verilerini içeren DTO sınıfıdır.
    /// Bu sınıf, transfer işlemi sonucunda dönen makbuz numarası, sonuç kodu, sonuç açıklaması ve sorgu numarası gibi bilgileri içerir.
    /// </summary>
    public class TransferResponseDataDto
    {
        /// <summary>
        /// Transfer işlemi için üretilen makbuz numarası.
        /// </summary>
        [JsonProperty("slipNumber")]
        public string? SlipNumber { get; set; }

        /// <summary>
        /// Transfer işleminin sonuç kodu.
        /// </summary>
        [JsonProperty("resultCode")]
        public string? ResultCode { get; set; }

        /// <summary>
        /// Transfer işleminin sonuç açıklaması.
        /// </summary>
        [JsonProperty("resultDescription")]
        public string? ResultDescription { get; set; }

        /// <summary>
        /// Transfer işlemi için verilen sorgu numarası.
        /// </summary>
        [JsonProperty("inquiryNumber")]
        public string? InquiryNumber { get; set; }
    }
}
