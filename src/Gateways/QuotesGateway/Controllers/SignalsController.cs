using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestipsApiContainers.Gateways.QuotesGateway.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public async Task<IActionResult> GetABBLowHighFibSignalByDateRange([FromQuery]string symbol, [FromQuery] long from, [FromQuery] long to, [FromQuery] int year, [FromQuery] int weekNumber, [FromQuery]string resolution = "D")
        {
            var result = await _fiboSignalService.GetABBLowHighFibSignalByDateRange(from, to, year, weekNumber);

            return Ok(result);
        }

        [HttpGet]
        [Route("getabblowhighfibobydaterangesymbols")]
        public async Task<IActionResult> GetABBLowHighFibSignalByDateRangeSymbols([FromQuery] string symbol, [FromQuery] long from, [FromQuery] long to, [FromQuery] int year, [FromQuery] int weekNumber, [FromQuery] string resolution = "D")
        {
            var result = await _fiboSignalService.GetABBLowHighFibSignalByDateRangeSymbols(from, to, year, weekNumber);

            return Ok(result);
        }

        [HttpGet]
        [Route("zigzagfibosignalsbydaterange")]
        public async Task<IActionResult> GetZigZagFiboSignalsByDateRange([FromQuery] string symbol, [FromQuery] long from, [FromQuery] long to, [FromQuery] string resolution = "D")
        {
            var result = await _fiboSignalService.GetZigZagFiboSignalsByDateRange(from, to);

            //HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(
            //    new { Count = result.MetaData.TotalCount, PageSize = result.MetaData.PageSize, CurrentPage = result.MetaData.CurrentPage, TotalPages = 10 }
            //    ));

           // Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
           // Response.Headers.Add("Access-Control-Expose-Headers", "X-Pagination");

            return Ok(result);
        }

        [HttpGet]
        [Route("bottomsupportsbydaterange")]
        public async Task<IActionResult> GetBottomSupportsByDateRange([FromQuery] string symbol, [FromQuery] long from, [FromQuery] long to, [FromQuery] string resolution = "D")
        {
            var result = await _fiboSignalService.GetBottomSupportsByDateRange(from, to);

            return Ok(result);
        }
    }
}