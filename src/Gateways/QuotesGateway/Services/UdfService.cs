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
        private readonly string _remoteServiceBaseUrlBullThreeArrowSignalsMarks;
        private readonly string _remoteServiceBaseUrlGapSignalsMarks;
        private readonly string _remoteServiceBaseUrlBullStoch307SignalsMarks;
        private readonly string _remoteServiceBaseUrlBullEightSignalsMarks;
        private readonly string _remoteServiceBaseUrlBullAllSignalsMarks;
        private readonly string _remoteServiceBaseUrlBullAllSignalsMarksBear;
        private readonly string _remoteServiceBaseUrlGetAllSignals;
        //private readonly  Dictionary<string, string> _signalsBaseUrls;

        public UdfService(IOptionsSnapshot<AppSettings> settings, IHttpClient httpClient, ILogger<UdfService> logger)
        {
            _settings = settings;
            _apiClient = httpClient;
            _logger = logger;

            _remoteServiceBaseUrl = $"{_settings.Value.UdfQuotesUrl}/api/udf/";

            //_signalsBaseUrls = new Dictionary<string, string>
            //{
            //    ["bull-green-3-arrows"] = $"{_settings.Value.SignalsUrl}/api/BullThreeArrowSignalsFunction/",
            //    ["super-gap"] = $"{_settings.Value.SignalsUrl}/api/GapSignalsFunction/"
            //};

            _remoteServiceBaseUrlBullThreeArrowSignalsMarks = $"{_settings.Value.SignalsUrl}/api/BullThreeArrowSignalsFunction/";
            _remoteServiceBaseUrlGapSignalsMarks = $"{_settings.Value.SignalsUrl}/api/GapSignalsFunction/";
            _remoteServiceBaseUrlBullStoch307SignalsMarks = $"{_settings.Value.SignalsUrl}/api/StochBull307SignalsFunction/";
            _remoteServiceBaseUrlBullEightSignalsMarks = $"{_settings.Value.SignalsUrl}/api/BullEightSignalsFunction/";
            _remoteServiceBaseUrlBullAllSignalsMarks = $"{_settings.Value.SignalsUrl}/api/BullAllSignalsFunction/";
            _remoteServiceBaseUrlBullAllSignalsMarksBear = $"{_settings.Value.SignalsUrl}/api/BearAllSignalsFunction/";
            _remoteServiceBaseUrlGetAllSignals = $"{_settings.Value.SignalsUrl}/api/GetAllSignalsFunction/";


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

        public async Task<MarkInfo> GetAllSignals()
        {
            var signalsUrl = ApiPaths.UdfQuotes.GetAllSignals(_remoteServiceBaseUrlGetAllSignals);

            var dataString = await _apiClient.GetStringAsync(signalsUrl);

            var response = JsonConvert.DeserializeObject<MarkInfo>(dataString);

            return response;
        }

        public async Task<MarkInfo> GetBullThreeGreenArrowMarks(string symbol, long from, long to, string resolution = "D")
        {
            var marksUri = ApiPaths.UdfQuotes.GetMarks(_remoteServiceBaseUrlBullThreeArrowSignalsMarks, symbol, from, to, resolution);

            var dataString = await _apiClient.GetStringAsync(marksUri);

            var response = JsonConvert.DeserializeObject<MarkInfo>(dataString);

            return response;
        }

        public async Task<MarkInfo> GetSuperGapMarks(string symbol, long from, long to, string resolution = "D")
        {
            var marksUri = ApiPaths.UdfQuotes.GetMarks(_remoteServiceBaseUrlGapSignalsMarks, symbol, from, to, resolution);

            var dataString = await _apiClient.GetStringAsync(marksUri);

            var response = JsonConvert.DeserializeObject<MarkInfo>(dataString);

            return response;
        }

        public async Task<MarkInfo> GetBullStoch307Marks(string symbol, long from, long to, string resolution = "D")
        {
            var marksUri = ApiPaths.UdfQuotes.GetMarks(_remoteServiceBaseUrlBullStoch307SignalsMarks, symbol, from, to, resolution);

            var dataString = await _apiClient.GetStringAsync(marksUri);

            var response = JsonConvert.DeserializeObject<MarkInfo>(dataString);

            return response;
        }

        public async Task<MarkInfo> GetBullEightMarks(string symbol, long from, long to, string resolution = "D")
        {
            var marksUri = ApiPaths.UdfQuotes.GetMarks(_remoteServiceBaseUrlBullEightSignalsMarks, symbol, from, to, resolution);

            var dataString = await _apiClient.GetStringAsync(marksUri);

            var response = JsonConvert.DeserializeObject<MarkInfo>(dataString);

            return response;
        }

        public async Task<MarkInfo> GetAllBullMarks(string symbol, long from, long to, string resolution = "D")
        {
            var marksUri = ApiPaths.UdfQuotes.GetMarks(_remoteServiceBaseUrlBullAllSignalsMarks, symbol, from, to, resolution);

            var dataString = await _apiClient.GetStringAsync(marksUri);

            var response = JsonConvert.DeserializeObject<MarkInfo>(dataString);

            return response;
        }

        public async Task<MarkInfo> GetAllBearMarks(string symbol, long from, long to, string resolution = "D")
        {
            var marksUri = ApiPaths.UdfQuotes.GetMarks(_remoteServiceBaseUrlBullAllSignalsMarksBear, symbol, from, to, resolution);

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
