﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using EODHistoricalData.NET;
//
//    var incomingSplits = IncomingSplits.FromJson(jsonString);

namespace EODHistoricalData.NET
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class IncomingSplits
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("from")]
        public DateTimeOffset From { get; set; }

        [JsonProperty("to")]
        public DateTimeOffset To { get; set; }

        [JsonProperty("splits")]
        public List<Split> Splits { get; set; }
    }

    public partial class Split
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("split_date")]
        public DateTimeOffset SplitDate { get; set; }

        [JsonProperty("optionable")]
        public Optionable Optionable { get; set; }

        [JsonProperty("old_shares")]
        public long OldShares { get; set; }

        [JsonProperty("new_shares")]
        public long NewShares { get; set; }
    }

    public enum Optionable { N };

    public partial class IncomingSplits
    {
        public static IncomingSplits FromJson(string json) => JsonConvert.DeserializeObject<IncomingSplits>(json, EODHistoricalData.NET.ConverterIncomingSplits.Settings);
    }

    public static class SerializeIncomingSplits
    {
        public static string ToJson(this IncomingSplits self) => JsonConvert.SerializeObject(self, EODHistoricalData.NET.ConverterIncomingSplits.Settings);
    }

    internal static class ConverterIncomingSplits
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                OptionableConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class OptionableConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Optionable) || t == typeof(Optionable?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "N")
            {
                return Optionable.N;
            }
            throw new Exception("Cannot unmarshal type Optionable");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Optionable)untypedValue;
            if (value == Optionable.N)
            {
                serializer.Serialize(writer, "N");
                return;
            }
            throw new Exception("Cannot marshal type Optionable");
        }

        public static readonly OptionableConverter Singleton = new OptionableConverter();
    }
}