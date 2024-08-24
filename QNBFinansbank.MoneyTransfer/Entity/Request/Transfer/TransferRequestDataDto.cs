using Newtonsoft.Json;

namespace QNBFinansbank.MoneyTransfer.Entity.Request.Transfer
{
    /// <summary>
    /// Para transfer işlemi için gerekli olan tüm detaylı bilgileri temsil eden DTO sınıfıdır.
    /// Bu sınıf, alıcı ve gönderen bilgileri, transfer tutarı, banka ve şube kodları gibi transfer işlemi için gereken çeşitli parametreleri içerir.
    /// </summary>
    public class TransferRequestDataDto : IDto
    {
        /// <summary>
        /// Transferin yapılacağı hedef hesap numarası.
        /// </summary>
        [JsonProperty("targetAccount")]
        public string? TargetAccount { get; set; }

        /// <summary>
        /// Transferin yapılacağı kredi kartı numarası.
        /// </summary>
        [JsonProperty("creditCardNumber")]
        public string? CreditCardNumber { get; set; }

        /// <summary>
        /// Hedef bankanın kodu.
        /// </summary>
        [JsonProperty("targetBankCode")]
        public string? TargetBankCode { get; set; }

        /// <summary>
        /// Hedef şubenin kodu.
        /// </summary>
        [JsonProperty("targetBranchCode")]
        public string? TargetBranchCode { get; set; }

        /// <summary>
        /// Gönderenin telefon numarası.
        /// </summary>
        [JsonProperty("phoneNumber")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Firmanın kodu.
        /// </summary>
        [JsonProperty("firmCode")]
        public string? FirmCode { get; set; }

        /// <summary>
        /// Alıcının adı.
        /// </summary>
        [JsonProperty("receiverName")]
        public string? ReceiverName { get; set; }

        /// <summary>
        /// API sürüm numarası.
        /// </summary>
        [JsonProperty("versionNumber")]
        public string? VersionNumber { get; set; }

        /// <summary>
        /// Firmanın referans numarası.
        /// </summary>
        [JsonProperty("firmReferansNumber")]
        public string? FirmReferansNumber { get; set; }

        /// <summary>
        /// Gönderenin vergi numarası.
        /// </summary>
        [JsonProperty("taxNumber")]
        public string? TaxNumber { get; set; }

        /// <summary>
        /// Gönderenin kimlik numarası.
        /// </summary>
        [JsonProperty("pidNo")]
        public string? PidNo { get; set; }

        /// <summary>
        /// Gönderenin adresi.
        /// </summary>
        [JsonProperty("address")]
        public string? Address { get; set; }

        /// <summary>
        /// Transfer edilecek tutar.
        /// </summary>
        [JsonProperty("amount")]
        public decimal? Amount { get; set; }

        /// <summary>
        /// Transfer edilecek para birimi.
        /// </summary>
        [JsonProperty("currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// Transferin paket kimliği.
        /// </summary>
        [JsonProperty("packedId")]
        public string? PackedId { get; set; }

        /// <summary>
        /// Transfer açıklaması.
        /// </summary>
        [JsonProperty("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Üst hesaba ait isim.
        /// </summary>
        [JsonProperty("superiorName")]
        public string? SuperiorName { get; set; }

        /// <summary>
        /// Üst hesaba ait hesap numarası.
        /// </summary>
        [JsonProperty("superiorAccNumber")]
        public string? SuperiorAccNumber { get; set; }

        /// <summary>
        /// Üst hesaba ait adres.
        /// </summary>
        [JsonProperty("superiorAddress")]
        public string? SuperiorAddress { get; set; }

        /// <summary>
        /// Gönderenin hesap numarası.
        /// </summary>
        [JsonProperty("accountNumber")]
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Üst hesaba ait doğum tarihi.
        /// </summary>
        [JsonProperty("superiorBirthDate")]
        public string? SuperiorBirthDate { get; set; }

        /// <summary>
        /// Üst hesaba ait doğum yeri.
        /// </summary>
        [JsonProperty("superiorBirthPlace")]
        public string? SuperiorBirthPlace { get; set; }

        /// <summary>
        /// Üst hesaba ait ülke ve şehir.
        /// </summary>
        [JsonProperty("superiorCountryCity")]
        public string? SuperiorCountryCity { get; set; }

        /// <summary>
        /// Üst hesaba ait müşteri numarası.
        /// </summary>
        [JsonProperty("superiorCustomerNo")]
        public string? SuperiorCustomerNo { get; set; }

        /// <summary>
        /// Üst hesaba ait kimlik numarası.
        /// </summary>
        [JsonProperty("superiorPidNo")]
        public string? SuperiorPidNo { get; set; }

        /// <summary>
        /// Kiralama türü.
        /// </summary>
        [JsonProperty("rentType")]
        public string? RentType { get; set; }

        /// <summary>
        /// Alıcının bölgesel durumu.
        /// </summary>
        [JsonProperty("receiverRegionalStatus")]
        public string? ReceiverRegionalStatus { get; set; }

        /// <summary>
        /// Ödeme kategorisinin detayı.
        /// </summary>
        [JsonProperty("paymentCategoryDetail")]
        public string? PaymentCategoryDetail { get; set; }
    }
}
