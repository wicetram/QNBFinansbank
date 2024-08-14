namespace QNBFinansbank.CashManagement.Entity.Request.GetTransaction
{
    public class GetTransactionRequestDto : IDto
    {
        public AccountDto? Account { get; set; }
        public TransactionInfoDto? TransactionInfo { get; set; }
    }
}
