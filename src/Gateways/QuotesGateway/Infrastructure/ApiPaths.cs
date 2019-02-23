﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Infrastructure
{
    public class ApiPaths
    {

        public static class Signals
        {
            public static string GetAllSignals(string baseUri, int page, int take, int? brand, int? type)
            {
                var filterQs = "";

                if (brand.HasValue || type.HasValue)
                {
                    var brandQs = (brand.HasValue) ? brand.Value.ToString() : "null";
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "null";
                    filterQs = $"/type/{typeQs}/brand/{brandQs}";
                }

                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
            }

            public static string GetGapSignals(string baseUri, string symbol)
            {

                return $"{baseUri}/bull/gaps/{symbol}";
            }
            public static string GeBullThreeArrowSignals(string baseUri, string symbol)
            {
                return $"{baseUri}/bull/threearrow/{symbol}";
            }

            public static string GetBull307StochSignals(string baseUri, string symbol)
            {
                return $"{baseUri}/bull/stock307/{symbol}";
            }
        }

        public static class HistoryQuote
        {
            public static string GetHistoryQuotes(string baseUri, string symbol, long from, long to, string resolution)
            {
                
                return $"{baseUri}history?symbol={symbol}&resolution={resolution}&from={from}&to={to}";
            }
        }


    }
}
