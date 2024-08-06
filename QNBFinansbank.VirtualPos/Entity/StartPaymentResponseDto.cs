namespace QNBFinansbank.VirtualPos.Entity
{
    public class StartPaymentResponseDto : IDto
    {
        public ProcessResult? Result { get; set; }
        public PaymentData? Payment { get; set; }
    }
}
