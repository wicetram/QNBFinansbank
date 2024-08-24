using Newtonsoft.Json;

namespace QNBFinansbank.CashManagement.Entity.Response.GetTransaction
{
    public class GetTransactionsData : IDto
    {
        [JsonProperty("@xsi:type")]
        public string? XsiType { get; set; }

        [JsonProperty("balanceAfterTransaction")]
        public string? BalanceAfterTransaction { get; set; }

        [JsonProperty("creditOrDebit")]
        public string? CreditOrDebit { get; set; }

        [JsonProperty("currencyCode")]
        public CurrencyCode? CurrencyCode { get; set; }

        [JsonProperty("processCode")]
        public string? ProcessCode { get; set; }

        [JsonProperty("productOperationRefNo")]
        public string? ProductOperationRefNo { get; set; }

        [JsonProperty("receiverIBAN")]
        public string? ReceiverIBAN { get; set; }

        [JsonProperty("receiverPIDNoTaxNo")]
        public string? ReceiverPIDNoTaxNo { get; set; }

        [JsonProperty("statementTransactionOrder")]
        public string? StatementTransactionOrder { get; set; }

        [JsonProperty("transactionAmount")]
        public string? TransactionAmount { get; set; }

        [JsonProperty("transactionDate")]
        public string? TransactionDate { get; set; }

        [JsonProperty("transactionDescription")]
        public string? TransactionDescription { get; set; }

        [JsonProperty("transactionId")]
        public string? TransactionId { get; set; }
    }

    public class CurrencyCode
    {
        [JsonProperty("@xsi:nil")]
        public string? XsiNil { get; set; }
    }
}
