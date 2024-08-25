using Microsoft.AspNetCore.Mvc;
using QNBFinansbank.VirtualPos.Business.Abstract;
using QNBFinansbank.VirtualPos.Entity.Request.Check;
using QNBFinansbank.VirtualPos.Entity.Request.EOD;
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
    }
}
