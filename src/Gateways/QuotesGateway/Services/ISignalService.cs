using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestipsApiContainers.Gateways.QuotesGateway.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Services
{
    public interface ISignalService
    {
        Task<IEnumerable<Signal>> GetGapSignals(string symbol);
        Task<IEnumerable<Signal>> GetBull307StochSignal(string symbol);
        Task<IEnumerable<Signal>> GetBullThreeArrowSignals(string symbol);
    }
}
