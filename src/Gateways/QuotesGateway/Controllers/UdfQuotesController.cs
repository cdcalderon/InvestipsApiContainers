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
        public async Task<IActionResult> GetHistory([FromQuery]string symbol,  [FromQuery] long from, [FromQuery] long to, [FromQuery]string resolution = "D")
        {
            var signals = await _udfService.GetHistoryQuotes(symbol, from, to, resolution);

            return Ok(signals);
        }

        [HttpGet]
        [Route("symbols")]
        public async Task<IActionResult> GetSymbol([FromQuery]string symbol)
        {
            try
            {
                var symbolInfo = await _udfService.GetSymbol(symbol);

                return Ok(symbolInfo);
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        [HttpGet]
        [Route("quote")]
        public async Task<IActionResult> GetQuotes([FromQuery] string[] symbols)
        {
            var signals = await _udfService.GetQuotes(symbols);

            return Ok(signals);
        }

        [HttpGet]
        [Route("marks")]
        public async Task<IActionResult> Marks(
            [FromQuery] string symbol, [FromQuery] long from, [FromQuery] long to, [FromQuery] string resolution = "D")
        {
            //var configInfo = await _udfService.GetMarks(symbol, from, to, resolution);
            var configInfo = await _udfService.GetSuperGapMarks(symbol, from, to, resolution);

            return Ok(configInfo);
        }

        [HttpGet]
        [Route("config")]
        public async Task<IActionResult> Config()
        {
            var configInfo = await _udfService.GetConfig();

            return Ok(configInfo);
        }
    }
}