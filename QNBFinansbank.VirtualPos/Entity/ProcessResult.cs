namespace QNBFinansbank.VirtualPos.Entity
{
    public class ProcessResult : IDto
    {
        public bool Result { get; set; }
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; } = string.Empty;
    }
}
