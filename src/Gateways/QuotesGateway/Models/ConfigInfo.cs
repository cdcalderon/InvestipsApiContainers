using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Models
{
    public class ConfigInfo
    {
        public bool supports_search { get; set; }
        public bool supports_group_request { get; set; }
        public bool supports_marks { get; set; }
        public bool supports_time { get; set; }
        public List<Exchange> exchanges { get; set; }
        public List<SymbolType> symbolsTypes { get; set; }
        public List<string> supportedResolutions { get; set; }
    }
}
