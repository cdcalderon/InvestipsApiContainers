using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestipsApiContainers.Gateways.QuotesGateway.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuotesGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalsController : ControllerBase
    {
        private IUdfService _udfService;
        public SignalsController(IUdfService udfService) =>
            _udfService = udfService;

        [HttpGet]
        [Route("allsignals")]
        public async Task<IActionResult> GetAllSignals([FromQuery]string symbol, [FromQuery] long from, [FromQuery] long to, [FromQuery]string resolution = "D")
        {
            var configInfo = await _udfService.GetAllSignals();

            return Ok(configInfo);
        }
    }
}