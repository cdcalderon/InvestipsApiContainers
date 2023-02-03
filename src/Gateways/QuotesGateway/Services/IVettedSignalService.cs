using InvestipsApiContainers.Gateways.QuotesGateway.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Services
{
    public interface IVettedSignalService
    {
        Task<IEnumerable<VettedSignal>> GetVettedSignals(long from, long to);
    }
}
