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

        public PagedSignalList(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };

            Signals.AddRange(items);
        }
    }
}
