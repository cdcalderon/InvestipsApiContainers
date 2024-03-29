﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using EODHistoricalData.NET;
//
//    var historicalData = HistoricalData.FromJson(jsonString);

namespace EODHistoricalData.NET
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class HistoricalPrice
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("datetime")]
        public DateTimeOffset Datetime { get; set; }

        [JsonProperty("open")]
        public double Open { get; set; }

        [JsonProperty("high")]
        public double High { get; set; }

        [JsonProperty("low")]
        public double Low { get; set; }

        [JsonProperty("close")]
        public double Close { get; set; }

        [JsonProperty("adjusted_close")]
        public double AdjustedClose { get; set; }

        [JsonProperty("volume")]
        public long Volume { get; set; }
    }

    public partial class HistoricalPrice
    {
        public static HistoricalPrice FromJson(string json) => JsonConvert.DeserializeObject<HistoricalPrice>(json, EODHistoricalData.NET.ConverterHistoricalPrice.Settings);

        public static List<HistoricalPrice> GetListFromJson(string json) => JsonConvert.DeserializeObject<List<HistoricalPrice>>(json, EODHistoricalData.NET.ConverterHistoricalPrice.Settings);

    }

    public static class SerializeHistoricalPrice
    {
        public static string ToJson(this HistoricalPrice self) => JsonConvert.SerializeObject(self, EODHistoricalData.NET.ConverterHistoricalPrice.Settings);
    }

    internal static class ConverterHistoricalPrice
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal },
                new NullConverter()
            },
        };
    }
}
