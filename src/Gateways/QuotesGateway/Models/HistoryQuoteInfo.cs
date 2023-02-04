using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Models
{
    public class HistoryQuoteInfo
    {
        public IEnumerable<long> t { get; set; }
        public IEnumerable<double> c { get; set; }
        public IEnumerable<double> o { get; set; }
        public IEnumerable<double> h { get; set; }
        public IEnumerable<double> l { get; set; }
        public IEnumerable<long> v { get; set; }
        public IEnumerable<DateTime> t2 { get; set; }
        public string s { get; set; }
    }
}
