namespace QNBFinansbank.CashManagement.Entity.Response.GetTransaction
{
    public class GetTransactionResponseDataDto : IDto
    {
        public string? ErrorCode { get; set; }
        public string? ErrorDescription { get; set; }
        public List<GetTransactionsData>? Datas { get; set; }
    }
}
