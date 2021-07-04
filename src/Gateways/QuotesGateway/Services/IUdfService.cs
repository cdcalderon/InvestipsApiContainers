using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestipsApiContainers.Gateways.QuotesGateway.DTOs;
using InvestipsApiContainers.Gateways.QuotesGateway.Models;
using YahooFinanceApi;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Services
{
    public interface IUdfService
    {
        Task<HistoryQuoteInfo> GetHistoryQuotes(string symbol, long from, long to, string resolution = "D");
        Task<SymboInfo> GetSymbol(string symbol);
        Task<MarkInfo> GetBullThreeGreenArrowMarks(string symbol, long from, long to, string resolution = "D");
        Task<MarkInfo> GetSuperGapMarks(string symbol, long from, long to, string resolution = "D");
        Task<MarkInfo> GetBullStoch307Marks(string symbol, long from, long to, string resolution = "D");
        Task<MarkInfo> GetBullEightMarks(string symbol, long from, long to, string resolution = "D");
        Task<MarkInfo> GetAllBullMarks(string symbol, long from, long to, string resolution = "D");
        Task<MarkInfo> GetAllBearMarks(string symbol, long from, long to, string resolution = "D");
        Task<MarkInfo> GetAllSignals();
        Task<ConfigInfo> GetConfig();
        Task<IReadOnlyDictionary<string, SecurityQuote>> GetQuotes(string[] symbols);
    }
}
