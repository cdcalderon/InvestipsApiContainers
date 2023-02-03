using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApiContainers.Gateways.QuotesGateway.DTOs
{
    public class PagedSignalList<T>
    {
        public MetaData MetaData { get; set; }
        public List<T> Signals { get; set; } = new List<T>();

    }
}
