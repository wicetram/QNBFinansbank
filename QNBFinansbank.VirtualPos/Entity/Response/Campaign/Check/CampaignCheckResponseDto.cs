namespace QNBFinansbank.VirtualPos.Entity.Response.Campaign.Check
{
    public class CampaignCheckResponseDto : IDto
    {
        public ProcessResult? Result { get; set; }
        public ApiLogDto? ApiLog { get; set; }
    }
}
