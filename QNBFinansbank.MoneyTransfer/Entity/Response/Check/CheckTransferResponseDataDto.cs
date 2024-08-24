using Newtonsoft.Json;

namespace QNBFinansbank.MoneyTransfer.Entity.Response.Check
{
    /// <summary>
    /// Para transfer kontrol işlemi yanıt verilerini içeren DTO sınıfıdır.
    /// Bu sınıf, transfer işlemleriyle ilgili detaylı bilgilerin yer aldığı tablo listesini içerir.
    /// </summary>
    public class CheckTransferResponseDataDto : IDto
    {
        /// <summary>
        /// Transfer kontrol işlemi sonucunda dönen tablo listesini içerir.
        /// Bu liste, her bir transfer işlemi hakkında detaylı bilgileri içerir.
        /// </summary>
        [JsonProperty(nameof(TableList))]
        public List<TableList?>? TableList { get; set; }
    }

    /// <summary>
    /// Transfer kontrol işlemi sonucunda dönen her bir transferin detaylarını içeren sınıftır.
    /// Bu sınıf, transfer edilen tutar, alıcı bilgileri, sonuç kodu gibi bilgileri içerir.
    /// </summary>
    public class TableList
    {
        /// <summary>
        /// Alıcının bölgesel durumu.
        /// </summary>
        [JsonProperty("receiverRegionalStatus")]
        public string? ReceiverRegionalStatus { get; set; }

        /// <summary>
        /// Üst hesaba ait isim.
        /// </summary>
        [JsonProperty("superiorName")]
        public string? SuperiorName { get; set; }

        /// <summary>
        /// Üst hesaba ait doğum tarihi.
        /// </summary>
        [JsonProperty("superiorBirthDate")]
        public string? SuperiorBirthDate { get; set; }

        /// <summary>
        /// Transfer edilen tutar.
        /// </summary>
        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        /// <summary>
        /// Gönderenin veya alıcının adres bilgisi.
        /// </summary>
        [JsonProperty("address")]
        public string? Address { get; set; }

        /// <summary>
        /// Transfer işlemi için üretilen makbuz numarası.
        /// </summary>
        [JsonProperty("slipNumber")]
        public string? SlipNumber { get; set; }

        /// <summary>
        /// Alıcının adı.
        /// </summary>
        [JsonProperty("receiverName")]
        public string? ReceiverName { get; set; }

        /// <summary>
        /// Transfer işleminin sonuç kodu.
        /// </summary>
        [JsonProperty("resultCode")]
        public string? ResultCode { get; set; }

        /// <summary>
        /// Transfer işleminin açıklaması.
        /// </summary>
        [JsonProperty("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Gönderenin hesap numarası.
        /// </summary>
        [JsonProperty("accountNumber")]
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Transfer işlemi için verilen sorgu numarası.
        /// </summary>
        [JsonProperty("inquiryNumber")]
        public string? InquiryNumber { get; set; }

        /// <summary>
        /// Transferin paket kimliği.
        /// </summary>
        [JsonProperty("packedId")]
        public string? PackedId { get; set; }

        /// <summary>
        /// Firmanın referans numarası.
        /// </summary>
        [JsonProperty("firmReferansNumber")]
        public string? FirmReferansNumber { get; set; }

        /// <summary>
        /// Transferin yüklendiği tarih.
        /// </summary>
        [JsonProperty("uploadDate")]
        public string? UploadDate { get; set; }

        /// <summary>
        /// Gönderenin kimlik numarası.
        /// </summary>
        [JsonProperty("pidNo")]
        public string? PidNo { get; set; }

        /// <summary>
        /// Hedef bankanın kodu.
        /// </summary>
        [JsonProperty("targetBankCode")]
        public string? TargetBankCode { get; set; }

        /// <summary>
        /// Transfer edilecek para birimi.
        /// </summary>
        [JsonProperty("currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// Transferin yapılacağı hedef hesap numarası.
        /// </summary>
        [JsonProperty("targetAccount")]
        public string? TargetAccount { get; set; }

        /// <summary>
        /// Transfer işleminin sonuç açıklaması.
        /// </summary>
        [JsonProperty("resultDescription")]
        public string? ResultDescription { get; set; }

        /// <summary>
        /// Ödeme kategorisinin detayı.
        /// </summary>
        [JsonProperty("paymentCategoryDetail")]
        public string? PaymentCategoryDetail { get; set; }

        /// <summary>
        /// Hedef şubenin kodu.
        /// </summary>
        [JsonProperty("targetBranchCode")]
        public string? TargetBranchCode { get; set; }

        /// <summary>
        /// Transfer işleminin gerçekleştiği tarih.
        /// </summary>
        [JsonProperty("transactionDate")]
        public string? TransactionDate { get; set; }
    }
}
