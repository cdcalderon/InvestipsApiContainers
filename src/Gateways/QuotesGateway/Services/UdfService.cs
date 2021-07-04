using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestipsApiContainers.Gateways.QuotesGateway.DTOs;
using InvestipsApiContainers.Gateways.QuotesGateway.Infrastructure;
using InvestipsApiContainers.Gateways.QuotesGateway.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using YahooFinanceApi;

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
            //var fromDate = TimeSpan.FromMilliseconds(from);
            //var toDate = TimeSpan.FromMilliseconds(to);
            var fromDate = FromUnixTimeStamp(from);
            var toDate = FromUnixTimeStamp(to);

            var history = await Yahoo.GetHistoricalAsync(symbol, fromDate, toDate,
                       Period.Daily);
            var o = history.Select(x => x.Open);
            var h = history.Select(x => x.High);
            var l = history.Select(x => x.Low);
            var c = history.Select(x => x.Close);
            var v = history.Select(x => x.Volume);
            var t = history.Select(x => Convert.ToInt64(ToUnixTimeStamp(x.DateTime)));

            var historyQuoteInfo = new HistoryQuoteInfo() { o = o, h = h, l = l, c = c, v = v, t = t, s = "ok" };

            //var historyQuotesUri = ApiPaths.UdfQuotes.GetHistoryQuotes(_remoteServiceBaseUrl, symbol, from, to, resolution);

            //var dataString = await _apiClient.GetStringAsync(historyQuotesUri);

            //var response = JsonConvert.DeserializeObject<HistoryQuoteInfo>(dataString);

            return historyQuoteInfo;
        }

        public async Task<IReadOnlyDictionary<string, SecurityQuote>> GetQuotes(string[] symbols)
        {
             var quotes = await Yahoo.Symbols(symbols)
                            .Fields(Field.ExchangeDataDelayedBy, Field.Symbol,
                            Field.RegularMarketPrice,
                            Field.RegularMarketOpen,
                            Field.RegularMarketDayHigh,
                            Field.RegularMarketDayLow,
                            Field.RegularMarketVolume)
                            .QueryAsync();

            var securityQuotes = quotes.ToDictionary(q => q.Key, q => new SecurityQuote() 
            { 
                Symbol = q.Value.Symbol,
                Close = Convert.ToDecimal( q.Value.RegularMarketPrice),
                High = Convert.ToDecimal(q.Value.RegularMarketDayHigh),
                Low = Convert.ToDecimal(q.Value.RegularMarketDayLow),
                Open = Convert.ToDecimal(q.Value.RegularMarketOpen),
                TimeStampDateTime = DateTime.Now
            });

            return securityQuotes;

            //Security symbolSecurity = quotesDayly[symbol];
        }

        public async Task<SymboInfo> GetSymbol(string symbol)
        {
            try
            {
                //var symbolUri = ApiPaths.UdfQuotes.GetSymbol(_remoteServiceBaseUrl, symbol);

                //var dataString = await _apiClient.GetStringAsync(symbolUri);

                //var response = JsonConvert.DeserializeObject<SymboInfo>(dataString);

                //return response;

                return new SymboInfo()
                {
                    name = symbol,
                    exchange_traded = "NYSE",
                    exchange_listed = "NYSE",
                    timezone = "America/New_York",
                    minmov = "1",
                    minmov2 = "0",
                    pricescale = "10",
                    pointvalue = "1",
                    session = "0930-1630",
                    supported_resolutions = new List<string> { "D"},
                    has_intraday = "false",
                    has_no_volume = "false",
                    ticker = symbol,
                    description = "N/A",
                    type = "stock"
                };
            }
            catch (Exception)
            {
                return new SymboInfo()
                {
                    name = symbol,
                    exchange_traded = "NYSE",
                    exchange_listed = "NYSE",
                    timezone = "America/New_York",
                    minmov = "1",
                    minmov2 = "0",
                    pricescale = "10",
                    pointvalue = "1",
                    session = "0930-1630",
                    supported_resolutions = new List<string> {"D"},
                    has_intraday = "false",
                    has_no_volume = "false",
                    ticker = symbol,
                    description = "N/A",
                    type = "stock"
                };
            }
            
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
            //var configUri = ApiPaths.UdfQuotes.GetConfig(_remoteServiceBaseUrl);

            //var dataString = await _apiClient.GetStringAsync(configUri);

            var config = new ConfigInfo()
            {
                supports_search = true,
                supports_group_request = false,
                supports_marks = true,
                supports_time = true,
                symbolsTypes = new List<SymbolType> { new SymbolType { name = "Stock", value = "stock" } },
                supportedResolutions = new List<string> { "D" },
                exchanges = new List<Exchange> { new Exchange { value = "", desc = "", name = "ALL Exchanges" },
                new Exchange { value = "", desc = "", name = "ALL Exchanges" },
                new Exchange { value = "XETRA", desc = "XETRA", name = "XETRA" },
                new Exchange { value = "NasdaqNM", desc = "NasdaqNM", name = "NasdaqNM" },
                new Exchange { value = "NYSE", desc = "NYSE", name = "NYSE" },
                new Exchange { value = "NSE", desc = "NSE", name = "NSE" },
                new Exchange { value = "CDNX", desc = "CDNX", name = "CDNX" },
                new Exchange { value = "Stuttgart", desc = "Stuttgart", name = "Stuttgart" }
                }
            };

            //var response = JsonConvert.DeserializeObject<ConfigInfo>(dataString);

            return config;
        }

        public static DateTime FromUnixTimeStamp(double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(unixTimeStamp).ToLocalTime();
        }

        public static double ToUnixTimeStamp(DateTime dtime)
        {
            var dd = (dtime - new DateTime(1970, 1, 1));
            var dd2 = (dtime - new DateTime(1970, 1, 1).ToLocalTime());
            var tt1 = dd.TotalSeconds;
            var tt2 = dd2.TotalSeconds;
            return tt1;
        }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Exchanx
    {
        public string value { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
    }

    public class SymbolsType
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class InvestipsConfig
    {
        public bool supports_search { get; set; }
        public bool supports_group_request { get; set; }
        public bool supports_marks { get; set; }
        public bool supports_timescale_marks { get; set; }
        public bool supports_time { get; set; }
        public List<Exchanx> exchanges { get; set; }
        public List<SymbolsType> symbolsTypes { get; set; }
        public List<string> supportedResolutions { get; set; }
    }


}
