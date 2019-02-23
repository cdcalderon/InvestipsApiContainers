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
    public class UdfQuotesController : ControllerBase
    {
        private IUdfService _udfService;
        public UdfQuotesController(IUdfService udfService) =>
            _udfService = udfService;

        [HttpGet]
        [Route("history")]
        public async Task<IActionResult> Get([FromQuery]string symbol,  [FromQuery] long from, [FromQuery] long to, [FromQuery]string resolution = "D")
        {
            var signals = await _udfService.GetHistoryQuotes(symbol, from, to, resolution);

            return Ok(signals);
        }
    }
}