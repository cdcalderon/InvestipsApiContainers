﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestipsApiContainers.Gateways.QuotesGateway.DTOs;
using InvestipsApiContainers.Gateways.QuotesGateway.Infrastructure;
using InvestipsApiContainers.Gateways.QuotesGateway.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Services
{
    public class FiboSignalService : IFiboSignalService
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly IHttpClient _apiClient;
        private readonly ILogger<SignalService> _logger;
        private readonly string _remoteServiceBaseUrl;
        private readonly string _getFiboSignalsUrl;
        private readonly string _getWeeklyFutureFiboSignalByDateRangeUrl;
        private readonly string _getABBLowHighFibSignalByDateRangeUrl;
        public FiboSignalService(IOptionsSnapshot<AppSettings> settings, IHttpClient httpClient, ILogger<SignalService> logger)
        {
            _settings = settings;
            _apiClient = httpClient;
            _logger = logger;

            _remoteServiceBaseUrl = $"{_settings.Value.SignalsUrl}";
            _getFiboSignalsUrl = $"{_settings.Value.SignalsUrl}/api/weeklyfuturefibosignal/";
            _getWeeklyFutureFiboSignalByDateRangeUrl = $"{_settings.Value.SignalsUrl}/api/getweeklyfuturefibosignalbydaterange/";
            _getABBLowHighFibSignalByDateRangeUrl = $"{_settings.Value.SignalsUrl}/api/getabblowhighfibobydaterange/";
        }

        public async Task<IEnumerable<WeeklyFutureFiboSignal>> GetFiboSignals(string symbol)
        {
            var fiboSignalsBySymbolUri = ApiPaths.Signals.GetFiboSignals(_getFiboSignalsUrl, symbol);

            var dataString = await _apiClient.GetStringAsync(fiboSignalsBySymbolUri);

            var response = JsonConvert.DeserializeObject<IEnumerable<WeeklyFutureFiboSignal>>(dataString);

            return response;
        }

        public async Task<IEnumerable<WeeklyFutureFiboSignal>> GetWeeklyFutureFiboSignalsByDateRange(long from, long to)
        {
            var weeklyFiboSignalsByDateRangeUri = ApiPaths.Signals.GetWeeklyFutureFiboSignalsByDateRange(_getWeeklyFutureFiboSignalByDateRangeUrl, from, to);

            var dataString = await _apiClient.GetStringAsync(weeklyFiboSignalsByDateRangeUri);

            var response = JsonConvert.DeserializeObject<IEnumerable<WeeklyFutureFiboSignal>>(dataString);

            return response;
        }

        public async Task<IEnumerable<WeeklyFutureFiboSignal>> GetABBLowHighFibSignalByDateRange(long from, long to)
        {
            var aBBLowHighFibSignalByDateRangeUri = ApiPaths.Signals.GetABBLowHighFibSignalByDateRange(_getABBLowHighFibSignalByDateRangeUrl, from, to);

            var dataString = await _apiClient.GetStringAsync(aBBLowHighFibSignalByDateRangeUri);

            var response = JsonConvert.DeserializeObject<IEnumerable<WeeklyFutureFiboSignal>>(dataString);

            return response;
        }
    }
}
