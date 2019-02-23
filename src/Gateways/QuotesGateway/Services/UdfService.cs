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

        public UdfService(IOptionsSnapshot<AppSettings> settings, IHttpClient httpClient, ILogger<UdfService> logger)
        {
            _settings = settings;
            _apiClient = httpClient;
            _logger = logger;

            _remoteServiceBaseUrl = $"{_settings.Value.UdfQuotesUrl}/api/udf/";
        }
        public async Task<HistoryQuoteInfo> GetHistoryQuotes(string symbol, long from, long to, string resolution = "D")
        {
            var allcatalogItemsUri = ApiPaths.HistoryQuote.GetHistoryQuotes(_remoteServiceBaseUrl, symbol, from, to, resolution);

            var dataString = await _apiClient.GetStringAsync(allcatalogItemsUri);

            var response = JsonConvert.DeserializeObject<HistoryQuoteInfo>(dataString);

            return response;
        }
    }
}
