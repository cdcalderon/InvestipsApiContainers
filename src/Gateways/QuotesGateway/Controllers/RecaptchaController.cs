using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Controllers
{
    [Route("api/V1/recaptcha")]
    public class RecaptchaController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Recaptcha([FromQuery] string symbol, [FromQuery] long from, [FromQuery] long to, [FromQuery] string resolution = "D")
        {
           
            return Ok();
        }
    }
}
