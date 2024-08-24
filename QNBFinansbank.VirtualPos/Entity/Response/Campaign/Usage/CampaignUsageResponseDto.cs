namespace QNBFinansbank.VirtualPos.Entity.Response.Campaign.Usage
{
    public class CampaignUsageResponseDto : IDto
    {
        public ProcessResult? Result { get; set; }
        public ApiLogDto? ApiLog { get; set; }
    }
}
