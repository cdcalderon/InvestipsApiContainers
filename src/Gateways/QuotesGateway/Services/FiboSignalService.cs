using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestipsApiContainers.Gateways.QuotesGateway.DTOs;
using InvestipsApiContainers.Gateways.QuotesGateway.Infrastructure;
using InvestipsApiContainers.Gateways.QuotesGateway.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        private readonly string _getABBLowHighFibSignalByDateRangeSymbolsUrl;
        private readonly string _getZigZagFiboSignalByDateRangeUrl;
        private readonly string _getBottomSupportSignalByDateRangeUrl;
        private readonly InvestipsQuotesContext quotesContext;
        public FiboSignalService(IOptionsSnapshot<AppSettings> settings, IHttpClient httpClient, ILogger<SignalService> logger, InvestipsQuotesContext quotesContext)
        {
            _settings = settings;
            _apiClient = httpClient;
            _logger = logger;

            _remoteServiceBaseUrl = $"{_settings.Value.SignalsUrl}";
            _getFiboSignalsUrl = $"{_settings.Value.SignalsUrl}/api/weeklyfuturefibosignal/";
            _getWeeklyFutureFiboSignalByDateRangeUrl = $"{_settings.Value.SignalsUrl}/api/getweeklyfuturefibosignalbydaterange/";
            _getABBLowHighFibSignalByDateRangeUrl = $"{_settings.Value.SignalsUrl}/api/getabblowhighfibobydaterange/";
            _getABBLowHighFibSignalByDateRangeSymbolsUrl = $"{_settings.Value.SignalsUrl}/api/getabblowhighfibobydaterangesymbols/";
            _getZigZagFiboSignalByDateRangeUrl = $"{_settings.Value.SignalsUrl}/api/GetZigZagSignalsByDateRange/";
            _getBottomSupportSignalByDateRangeUrl = $"{_settings.Value.SignalsUrl}/api/GetBottomSupportsSignalByDateRange/";
            this.quotesContext = quotesContext;
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

        public async Task<IEnumerable<WeeklyFutureFiboSignal>> GetABBLowHighFibSignalByDateRange(long from, long to, int year, int weekNumber)
        {
            var aBBLowHighFibSignalByDateRangeUri = ApiPaths.Signals.GetABBLowHighFibSignalByDateRange(_getABBLowHighFibSignalByDateRangeUrl, from, to, year, weekNumber);

            var dataString = await _apiClient.GetStringAsync(aBBLowHighFibSignalByDateRangeUri);

            var response = JsonConvert.DeserializeObject<IEnumerable<WeeklyFutureFiboSignal>>(dataString);

            return response;
        }

        public async Task<IEnumerable<string>> GetABBLowHighFibSignalByDateRangeSymbols(long from, long to, int year, int weekNumber)
        {
            var aBBLowHighFibSignalByDateRangeSymbolsUri = ApiPaths.Signals.GetABBLowHighFibSignalByDateRangeSymbols(_getABBLowHighFibSignalByDateRangeSymbolsUrl, from, to, year, weekNumber);

            var dataString = await _apiClient.GetStringAsync(aBBLowHighFibSignalByDateRangeSymbolsUri);

            var response = JsonConvert.DeserializeObject<IEnumerable<string>>(dataString);

            return response;
        }

        public async Task<PagedSignalList<DTOs.ZigZagFiboSignal>> GetZigZagFiboSignalsByDateRange(long from, long to)

        {
            string pageNumberString = "1";
            string pageSizeString = "50";
            var count = await quotesContext.ZigZagSignalPremiums
                .Where(x => (x.IsActivatedUp || x.IsActivatedDown) && x.TimeStampDateTime > new DateTime(2020, 11, 1)).CountAsync();

            var fibSignalPrices = await quotesContext.ZigZagSignalPremiums
                .Where(x => (x.IsActivatedUp || x.IsActivatedDown) &&
               x.TimeStampDateTime > new DateTime(2020, 11, 1))
                //.Skip((pageNumber - 1) * pageSize)  // this was moved to PagedSignals
                //.Take(pageSize)
                .Select(x => new DTOs.ZigZagFiboSignal
                {
                    Id = x.Id,
                    Symbol = x.Symbol,
                    WeekNumber = x.WeekNumber,
                    ActivationDirection = x.IsActivatedUp ? "UP" : x.IsActivatedDown ? "DOWN" : "NOTACTIVATED",
                    ActivationPrice = x.ActivationPrice,
                    ActivationDate = x.TimeStampDateTime,
                    ALow = x.ALow,
                    AHigh = x.AHigh,
                    BHigh = x.BHigh,
                    BLow = x.BLow,
                    CLow = x.CLow,
                    CHigh = x.CHigh,
                    CLowestOpenOrClose = Math.Min(x.COpen, x.CClose),
                    CHighestOpenOrClose = Math.Max(x.COpen, x.CClose),
                    ADate = x.ATimeStampDateTime,
                    BDate = x.BTimeStampDateTime,
                    CDate = x.CTimeStampDateTime,
                    ZigzagType = x.ZigzagType,
                    //ZigZagSignalIdentifier = x.ZigZagSignalIdentifier,
                    Support = x.SupportPrice,
                    Resistence = x.ResistencePrice,
                    SignalType = x.SignalType,
                    IsPublished = x.IsPublished
                })
                .ToListAsync();
            var pagedResult = new PagedSignalList<ZigZagFiboSignal>(fibSignalPrices, count, 1, 100);

           // response.MetaData{ }

            //var zigzagFiboSignalsByDateRangeUri = ApiPaths.Signals.GetZigZagFiboSignalsByDateRange(_getZigZagFiboSignalByDateRangeUrl, from, to);

            //var dataString = await _apiClient.GetStringAsync(zigzagFiboSignalsByDateRangeUri);
            //var response = new PagedList<ZigZagFiboSignal>(fibSignalPrices, fibSignalPrices.Count(), 1, 100);
            //var response = JsonConvert.DeserializeObject<PagedSignalList<ZigZagFiboSignal>>(JsonConvert.SerializeObject(fibSignalPrices));

            return pagedResult;
        }

        public async Task<IEnumerable<DTOs.BottomSupport>> GetBottomSupportsByDateRange(long from, long to)
        {
            var bottomSupportSignalsByDateRangeUri = ApiPaths.Signals.GetBottomSupportsByDateRange(_getBottomSupportSignalByDateRangeUrl, from, to);

            var dataString = await _apiClient.GetStringAsync(bottomSupportSignalsByDateRangeUri);

            var response = JsonConvert.DeserializeObject<IEnumerable<DTOs.BottomSupport>>(dataString);

            return response;
        }
    }
}
