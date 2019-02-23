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
    }
}
