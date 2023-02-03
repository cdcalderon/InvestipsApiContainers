using System.Collections.Generic;
using System.Threading.Tasks;
using InvestipsApiContainers.Gateways.QuotesGateway.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//publishweeklyzigzagfibpremiumsignals
namespace InvestipsApiContainers.Gateways.QuotesGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeeklyZigzagFibPremiumSignalController : ControllerBase
    {
        private IWeeklyZigzagFibPremiumSignalService _weeklyZigzagFibPremiumSignalService;

        public WeeklyZigzagFibPremiumSignalController(IUdfService udfService, IWeeklyZigzagFibPremiumSignalService weeklyZigzagFibPremiumSignalService)
        {
            _weeklyZigzagFibPremiumSignalService = weeklyZigzagFibPremiumSignalService;
        }


        // GET api/<WeeklyZigzagFibPremiumSignalController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var signal = await _weeklyZigzagFibPremiumSignalService.GetWeeklyZigZagFibPremiumSignalById(id);

            return Ok(signal);
        }

        [HttpGet]
        public async Task<IActionResult> GetWeeklyZigzagFibPremiumDisplaySignals()
        {
            var signals = await _weeklyZigzagFibPremiumSignalService.GetWeeklyZigzagFibPremiumDisplaySignals();

            return Ok(signals);
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] IEnumerable<DTOs.PublishSignal> zigZagFiboSignals)
        {
            var signalsUpdated = await _weeklyZigzagFibPremiumSignalService.PublishWeeklyZigZagFibPremiumSignals(zigZagFiboSignals);
            return Ok(signalsUpdated);
        }

    }
}
