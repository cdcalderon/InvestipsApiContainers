using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace EODHistoricalData.NET
{
    internal class StockPriceDataClient : HttpApiClient
    {
        const string HistoricalDataUrl = "https://eodhistoricaldata.com/api/eod/{0}?{2}&api_token={1}&fmt=json";
        const string RealTimeDataUrl = "https://eodhistoricaldata.com/api/real-time/{0}?&api_token={1}&fmt=json";
        const string HistoricalIntradayDataUrl = "https://eodhistoricaldata.com/api/intraday/{0}.US?api_token={1}&interval=1h&from={2}&to={3}&fmt=json";

        internal StockPriceDataClient(string api, bool useProxy) : base(api, useProxy) { }

        internal List<HistoricalPrice> GetHistoricalPrices(string symbol, DateTime? startDate, DateTime? endDate)
        {
            string dateParameters = Utils.GetDateParametersAsString(startDate, endDate);
            return ExecuteQuery(string.Format(HistoricalDataUrl, symbol, _apiToken, dateParameters), GetHistoricalPricesFromResponse);
        }

        internal List<HistoricalPrice> GetHistoricalHourlyPrices(string symbol, DateTime startDate, DateTime endDate)
        {
            string dateParameters = Utils.GetDateParametersAsString(startDate, endDate);
            string urlrequest = string.Format(HistoricalIntradayDataUrl, symbol, _apiToken, ToUnixTimeStamp(startDate), ToUnixTimeStamp(endDate));
            return ExecuteQuery(urlrequest, GetHistoricalPricesFromResponse);
        }

        List<HistoricalPrice> GetHistoricalPricesFromResponse(HttpResponseMessage response)
        {
            return HistoricalPrice.GetListFromJson(response.Content.ReadAsStringAsync().Result) ?? new List<HistoricalPrice>();
        }

        internal List<RealTimePrice> GetRealTimePrices(string[] symbols)
        {
            string first = symbols[0];
            string[] others = symbols.Skip(1).ToArray();
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format(RealTimeDataUrl, first, _apiToken));
            sb.Append($"&s={string.Join(",", others)}");

            return ExecuteQuery(sb.ToString(), GetRealTimePrices);
        }

        internal RealTimePrice GetRealTimePrice(string symbol)
        {
            return ExecuteQuery(string.Format(RealTimeDataUrl, symbol, _apiToken), GetRealTimePrice);
        }

        RealTimePrice GetRealTimePrice(HttpResponseMessage response)
        {
            return RealTimePrice.FromJson(response.Content.ReadAsStringAsync().Result);
        }

        List<RealTimePrice> GetRealTimePrices(HttpResponseMessage response)
        {
            return SerializeRealTimePrice.GetListFromJson(response.Content.ReadAsStringAsync().Result);
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
}
