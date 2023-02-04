﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using EODHistoricalData.NET;
//
//    var earnings = Earnings.FromJson(jsonString);

namespace EODHistoricalData.NET
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Earnings
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("from")]
        public DateTimeOffset? From { get; set; }

        [JsonProperty("to")]
        public DateTimeOffset? To { get; set; }

        [JsonProperty("earnings")]
        public List<Earning> EarningsData { get; set; }
    }

    public partial class Earning
    { 
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("report_date")]
        public DateTimeOffset? ReportDate { get; set; }

        [JsonProperty("date")]
        public string DateString { get; set; }

        [JsonProperty("actual")]
        public double? Actual { get; set; }

        [JsonProperty("estimate")]
        public double? Estimate { get; set; }

        [JsonProperty("difference")]
        public double Difference { get; set; }

        [JsonProperty("percent")]
        public double? Percent { get; set; }

        public DateTime? Date { get; set; }
    }

    public partial class Earnings
    {
        public static Earnings FromJson(string json)
        {
            Earnings result = JsonConvert.DeserializeObject<Earnings>(json, EODHistoricalData.NET.ConverterEarnings.Settings);
            foreach (Earning earning in result.EarningsData)
            {
                if (!earning.DateString.StartsWith("0000"))
                    earning.Date = DateTime.Parse(earning.DateString, CultureInfo.InvariantCulture);
            }
            return result;
        }
    }

    public static class SerializeEarnings
    {
        public static string ToJson(this Earnings self) => JsonConvert.SerializeObject(self, EODHistoricalData.NET.ConverterEarnings.Settings);
    }

    internal static class ConverterEarnings
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