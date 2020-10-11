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
        private IFiboSignalService _fiboSignalService;

        public SignalsController(IUdfService udfService, IFiboSignalService fiboSignalService) {
            _udfService = udfService;
            _fiboSignalService = fiboSignalService;
        }
           

        [HttpGet]
        [Route("allsignals")]
        public async Task<IActionResult> GetAllSignals([FromQuery]string symbol, [FromQuery] long from, [FromQuery] long to, [FromQuery]string resolution = "D")
        {
            var configInfo = await _udfService.GetAllSignals();

            return Ok(configInfo);
        }

        [HttpGet]
        [Route("fibosignals")]
        public async Task<IActionResult> GetFiboSignals([FromQuery]string symbol, [FromQuery] long from, [FromQuery] long to, [FromQuery]string resolution = "D")
        {
            var configInfo = await _fiboSignalService.GetFiboSignals(symbol);

            return Ok(configInfo);
        }

        [HttpGet]
        [Route("weeklyfibosignalsbydaterange")]
        public async Task<IActionResult> GetWeeklyFutureFiboSignalsByDateRange([FromQuery]string symbol, [FromQuery] long from, [FromQuery] long to, [FromQuery]string resolution = "D")
        {
            var configInfo = await _fiboSignalService.GetWeeklyFutureFiboSignalsByDateRange(from, to);

            return Ok(configInfo);
        }

        [HttpGet]
        [Route("getabblowhighfibobydaterange")]
        public async Task<IActionResult> GetABBLowHighFibSignalByDateRange([FromQuery]string symbol, [FromQuery] long from, [FromQuery] long to, [FromQuery]string resolution = "D")
        {
            var configInfo = await _fiboSignalService.GetABBLowHighFibSignalByDateRange(from, to);

            return Ok(configInfo);
        }
    }
}