﻿using System.Collections.Generic;
using System.Threading.Tasks;
using InvestipsApiContainers.Gateways.QuotesGateway.DTOs;
using InvestipsApiContainers.Gateways.QuotesGateway.Models;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Services
{
    public interface IFiboSignalService
    {
        Task<IEnumerable<WeeklyFutureFiboSignal>> GetFiboSignals(string symbol);
        Task<IEnumerable<WeeklyFutureFiboSignal>> GetWeeklyFutureFiboSignalsByDateRange(long from, long to);
        Task<IEnumerable<WeeklyFutureFiboSignal>> GetABBLowHighFibSignalByDateRange(long from, long to, int year, int weekNumber);
        Task<IEnumerable<string>> GetABBLowHighFibSignalByDateRangeSymbols(long from, long to, int year, int weekNumber);
        Task<PagedSignalList<ZigZagFiboSignal>> GetZigZagFiboSignalsByDateRange(long from, long to);
        Task<IEnumerable<DTOs.BottomSupport>> GetBottomSupportsByDateRange(long from, long to);
    }
}
