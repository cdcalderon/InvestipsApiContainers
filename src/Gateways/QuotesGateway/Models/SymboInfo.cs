using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Models
{
    public class SymboInfo
    {
        public string name { get; set; }
        [JsonProperty(PropertyName = "exchange-traded")]
        public string exchange_traded { get; set; }
        [JsonProperty(PropertyName = "exchange-listed")]
        public string exchange_listed { get; set; }
        public string timezone { get; set; }
        public string minmov { get; set; }
        public string minmov2 { get; set; }
        public string pricescale { get; set; }
        public string pointvalue { get; set; }
        public string session { get; set; }
        public string has_intraday { get; set; }
        public string has_no_volume { get; set; }
        public string ticker { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public List<string> supported_resolutions { get; set; }
    }
}
