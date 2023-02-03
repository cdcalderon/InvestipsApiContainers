using InvestipsApiContainers.Gateways.QuotesGateway.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Services
{
    public interface IWeeklyZigzagFibPremiumSignalService
    {
        Task<ZigZagFiboSignal> GetWeeklyZigZagFibPremiumSignalById(int signalId);
        Task<int> PublishWeeklyZigZagFibPremiumSignals(IEnumerable<DTOs.PublishSignal> publishSignals);
        Task<IEnumerable<DisplaySignalSignal>> GetWeeklyZigzagFibPremiumDisplaySignals();
    }
}
