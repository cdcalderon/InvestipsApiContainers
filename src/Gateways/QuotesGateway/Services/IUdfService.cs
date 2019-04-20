using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestipsApiContainers.Gateways.QuotesGateway.Models;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Services
{
    public interface IUdfService
    {
        Task<HistoryQuoteInfo> GetHistoryQuotes(string symbol, long from, long to, string resolution = "D");
        Task<SymboInfo> GetSymbol(string symbol);
        Task<MarkInfo> GetBullThreeGreenArrowMarks(string symbol, long from, long to, string resolution = "D");
        Task<MarkInfo> GetSuperGapMarks(string symbol, long from, long to, string resolution = "D");
        Task<MarkInfo> GetBullStoch307Marks(string symbol, long from, long to, string resolution = "D");
        Task<ConfigInfo> GetConfig();
    }
}
