using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Models
{
    public class HistoryQuoteInfo
    {
        public List<long> t { get; set; }
        public List<decimal> c { get; set; }
        public List<decimal> o { get; set; }
        public List<decimal> h { get; set; }
        public List<decimal> l { get; set; }
        public List<long> v { get; set; }
        public List<DateTime> t2 { get; set; }
        public string s { get; set; }
    }
}
