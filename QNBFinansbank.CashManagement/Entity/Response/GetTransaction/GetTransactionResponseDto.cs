namespace QNBFinansbank.CashManagement.Entity.Response.GetTransaction
{
    public class GetTransactionResponseDto : IDto
    {
        public ProcessResult? Result { get; set; }
        public GetTransactionResponseDataDto? Transaction { get; set; }
    }
}
