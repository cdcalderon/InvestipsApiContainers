using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Models
{
    public class HistoryQuoteInfo
    {
        public IEnumerable<long> t { get; set; }
        public IEnumerable<decimal> c { get; set; }
        public IEnumerable<decimal> o { get; set; }
        public IEnumerable<decimal> h { get; set; }
        public IEnumerable<decimal> l { get; set; }
        public IEnumerable<long> v { get; set; }
        public IEnumerable<DateTime> t2 { get; set; }
        public string s { get; set; }
    }
}
