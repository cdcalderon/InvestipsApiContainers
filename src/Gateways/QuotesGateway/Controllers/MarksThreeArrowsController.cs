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
        public async Task<IActionResult> Marks([FromQuery]string symbol, [FromQuery] long from, [FromQuery] long to, [FromQuery]string resolution = "D")
        {
            var configInfo = await _udfService.GetMarks(symbol, from, to, resolution);

            return Ok(configInfo);
        }
    }
}