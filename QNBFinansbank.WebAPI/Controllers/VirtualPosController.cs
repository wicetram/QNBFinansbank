using Microsoft.AspNetCore.Mvc;
using QNBFinansbank.VirtualPos.Business.Abstract;
using QNBFinansbank.VirtualPos.Entity.Request.Campaign.Check;
using QNBFinansbank.VirtualPos.Entity.Request.Campaign.Usage;
using QNBFinansbank.VirtualPos.Entity.Request.Check;
using QNBFinansbank.VirtualPos.Entity.Request.EOD;
using QNBFinansbank.VirtualPos.Entity.Request.Report;
using QNBFinansbank.VirtualPos.Entity.Request.RewardPoints.Check;
using QNBFinansbank.VirtualPos.Entity.Request.RewardPoints.Usage;

namespace QNBFinansbank.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VirtualPosController(IVirtualPosService virtualPos) : ControllerBase
    {
        private readonly IVirtualPosService _virtualPos = virtualPos;

        [HttpPost]
        [Route("CheckRewardPoints")]
        public object CheckRewardPoints(CheckRewardPointsRequestDto checkRewardPointsRequestDto)
        {
            return _virtualPos.CheckRewardPoints(checkRewardPointsRequestDto);
        }

        [HttpPost]
        [Route("UseRewardPoints")]
        public object UseRewardPoints(UseRewardPointsRequestDto useRewardPointsRequestDto)
        {
            return _virtualPos.UseRewardPoints(useRewardPointsRequestDto);
        }

        [HttpPost]
        [Route("check")]
        public object Check(CheckRequestDto checkPaymentRequestDto)
        {
            return _virtualPos.Check(checkPaymentRequestDto);
        }

        [HttpPost]
        [Route("eod")]
        public object Eod(EODRequestDto eODRequest)
        {
            return _virtualPos.EOD(eODRequest);
        }

        [HttpPost]
        [Route("report")]
        public object Report(ReportRequestDto reportRequestDto)
        {
            return _virtualPos.Report(reportRequestDto);
        }

        [HttpPost]
        [Route("campaigncheck")]
        public object CampaignCheck(CampaignCheckRequestDto campaignCheckRequestDto)
        {
            return _virtualPos.CampaignCheck(campaignCheckRequestDto);
        }

        [HttpPost]
        [Route("campaignusage")]
        public object CampaignUsage(CampaignUsageRequestDto campaignUsageRequest)
        {
            return _virtualPos.CampaignUsage(campaignUsageRequest);
        }
    }
}
