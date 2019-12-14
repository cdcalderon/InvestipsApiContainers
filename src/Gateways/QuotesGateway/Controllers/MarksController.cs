using System.Threading.Tasks;
using InvestipsApiContainers.Gateways.QuotesGateway.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Controllers
{
    [Route("api/udf")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private IUdfService _udfService;
        public MarksController(IUdfService udfService) =>
            _udfService = udfService;

        [HttpGet]
        [Route("marksgreenarrows")]
        public async Task<IActionResult> MarksBullGreenThreeArrows([FromQuery]string symbol, [FromQuery] long from, [FromQuery] long to, [FromQuery]string resolution = "D")
        {
            var configInfo = await _udfService.GetBullThreeGreenArrowMarks(symbol, from, to, resolution);

            return Ok(configInfo);
        }

        [HttpGet]
        [Route("marksgaps")]
        public async Task<IActionResult> MarksGaps([FromQuery]string symbol, [FromQuery] long from, [FromQuery] long to, [FromQuery]string resolution = "D")
        {
            var configInfo = await _udfService.GetSuperGapMarks(symbol, from, to, resolution);

            return Ok(configInfo);
        }

        [HttpGet]
        [Route("stoch307bull")]
        public async Task<IActionResult> MarksBullh307([FromQuery]string symbol, [FromQuery] long from, [FromQuery] long to, [FromQuery]string resolution = "D")
        {
            var configInfo = await _udfService.GetBullStoch307Marks(symbol, from, to, resolution);

            return Ok(configInfo);
        }

        [HttpGet]
        [Route("bullbigeight")]
        public async Task<IActionResult> MarksBullEight([FromQuery]string symbol, [FromQuery] long from, [FromQuery] long to, [FromQuery]string resolution = "D")
        {
            var configInfo = await _udfService.GetBullEightMarks(symbol, from, to, resolution);

            return Ok(configInfo);
        }

        [HttpGet]
        [Route("allbullmarks")]
        public async Task<IActionResult> MarksBullAll([FromQuery]string symbol, [FromQuery] long from, [FromQuery] long to, [FromQuery]string resolution = "D")
        {
            var configInfo = await _udfService.GetAllBullMarks(symbol, from, to, resolution);

            return Ok(configInfo);
        }

        [HttpGet]
        [Route("allbearmarks")]
        public async Task<IActionResult> MarksAllBear([FromQuery]string symbol, [FromQuery] long from, [FromQuery] long to, [FromQuery]string resolution = "D")
        {
            var configInfo = await _udfService.GetAllBearMarks(symbol, from, to, resolution);

            return Ok(configInfo);
        }
    }
}