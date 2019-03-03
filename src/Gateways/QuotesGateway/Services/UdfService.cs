using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestipsApiContainers.Gateways.QuotesGateway.Infrastructure;
using InvestipsApiContainers.Gateways.QuotesGateway.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Services
{
    public class UdfService: IUdfService
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly IHttpClient _apiClient;
        private readonly ILogger<UdfService> _logger;

        private readonly string _remoteServiceBaseUrl;
        private readonly string _remoteServiceBaseUrlMarks;

        public UdfService(IOptionsSnapshot<AppSettings> settings, IHttpClient httpClient, ILogger<UdfService> logger)
        {
            _settings = settings;
            _apiClient = httpClient;
            _logger = logger;

            _remoteServiceBaseUrl = $"{_settings.Value.UdfQuotesUrl}/api/udf/";
            _remoteServiceBaseUrlMarks = $"{_settings.Value.SignalsUrl}/api/BullThreeArrowSignalsFunction/";
        }
        public async Task<HistoryQuoteInfo> GetHistoryQuotes(string symbol, long from, long to, string resolution = "D")
        {
            var historyQuotesUri = ApiPaths.UdfQuotes.GetHistoryQuotes(_remoteServiceBaseUrl, symbol, from, to, resolution);

            var dataString = await _apiClient.GetStringAsync(historyQuotesUri);

            var response = JsonConvert.DeserializeObject<HistoryQuoteInfo>(dataString);

            return response;
        }

        public async Task<SymboInfo> GetSymbol(string symbol)
        {
            var symbolUri = ApiPaths.UdfQuotes.GetSymbol(_remoteServiceBaseUrl, symbol);

            var dataString = await _apiClient.GetStringAsync(symbolUri);

            var response = JsonConvert.DeserializeObject<SymboInfo>(dataString);

            return response;
        }

        public async Task<MarkInfo> GetMarks(string symbol, long from, long to, string resolution = "D")
        {
            var marksUri = ApiPaths.UdfQuotes.GetMarks(_remoteServiceBaseUrlMarks, symbol, from, to, resolution);

            var dataString = await _apiClient.GetStringAsync(marksUri);

            var response = JsonConvert.DeserializeObject<MarkInfo>(dataString);

            return response;
        }

        public async Task<ConfigInfo> GetConfig()
        {
            var configUri = ApiPaths.UdfQuotes.GetConfig(_remoteServiceBaseUrl);

            var dataString = await _apiClient.GetStringAsync(configUri);

            var response = JsonConvert.DeserializeObject<ConfigInfo>(dataString);

            return response;
        }
    }
}
