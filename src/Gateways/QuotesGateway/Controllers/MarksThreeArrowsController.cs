using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestipsApiContainers.Gateways.QuotesGateway.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuotesGateway.Controllers
{
    [Route("api/udf")]
    [ApiController]
    public class MarksThreeArrowsController : ControllerBase
    {
        private IUdfService _udfService;
        public MarksThreeArrowsController(IUdfService udfService) =>
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
    }
}