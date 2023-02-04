﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using EODHistoricalData.NET;
//
//    var realTimePrice = RealTimePrice.FromJson(jsonString);

namespace EODHistoricalData.NET
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RealTimePrice
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("gmtoffset")]
        public long Gmtoffset { get; set; }

        [JsonProperty("open")]
        public double Open { get; set; }

        [JsonProperty("high")]
        public double High { get; set; }

        [JsonProperty("low")]
        public double Low { get; set; }

        [JsonProperty("close")]
        public double Close { get; set; }

        [JsonProperty("volume")]
        public long Volume { get; set; }

        [JsonProperty("previousClose")]
        public double PreviousClose { get; set; }

        [JsonProperty("change")]
        public double Change { get; set; }

        [JsonProperty("change_p")]
        public double ChangeP { get; set; }

        [JsonIgnore]
        public DateTime TimestampAsDateTime { get; set; }
    }

    public partial class RealTimePrice
    {
        public static RealTimePrice FromJson(string json)
        {
            RealTimePrice result = JsonConvert.DeserializeObject<RealTimePrice>(json, EODHistoricalData.NET.ConverterRealTimePrice.Settings);
            result.TimestampAsDateTime = DateTimeOffset.FromUnixTimeSeconds(result.Timestamp).DateTime;
            return result;
        }
    }

    public static class SerializeRealTimePrice
    {
        public static string ToJson(this RealTimePrice self) => JsonConvert.SerializeObject(self, EODHistoricalData.NET.ConverterRealTimePrice.Settings);

        public static List<RealTimePrice> GetListFromJson(string json)
        {
            List<RealTimePrice> prices = JsonConvert.DeserializeObject<List<RealTimePrice>>(json, EODHistoricalData.NET.ConverterRealTimePrice.Settings);
            prices.ForEach(x => x.TimestampAsDateTime = DateTimeOffset.FromUnixTimeSeconds(x.Timestamp).DateTime);
            return prices;
        }
    }

    internal static class ConverterRealTimePrice
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
