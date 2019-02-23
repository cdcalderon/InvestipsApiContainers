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
    public class StochBull301SignalsController : ControllerBase
    {
        private ISignalService _signalService;
        public StochBull301SignalsController(ISignalService signalService) =>
            _signalService = signalService;


        // GET: api/Signals/5
        [HttpGet]
        [Route("[action]/type/{catalogTypeId}/brand/{catalogBrandId}")]
        public async Task<IActionResult> Get(string symbol)
        {
            var signals = await _signalService.GetGapSignals(symbol);

            return Ok(signals);
        }

        // POST: api/Signals
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Signals/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
