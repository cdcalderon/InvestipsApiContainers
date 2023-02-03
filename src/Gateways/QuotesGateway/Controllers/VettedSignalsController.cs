using System.Threading.Tasks;
using InvestipsApiContainers.Gateways.QuotesGateway.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VettedSignalsController : ControllerBase
    {
        private IUdfService _udfService;
        private IVettedSignalService _vettedSignalService;

        [HttpGet]
        [Route("vettedsignals")]
        public async Task<IActionResult> GetVettedSignalsByDateRange([FromQuery] string symbol, [FromQuery] long from, [FromQuery] long to, [FromQuery] string resolution = "D")
        {
            var configInfo = await _vettedSignalService.GetVettedSignals(from, to);

            return Ok(configInfo);
        }
    }
}
