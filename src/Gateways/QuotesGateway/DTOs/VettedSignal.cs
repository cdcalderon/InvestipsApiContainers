using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApiContainers.Gateways.QuotesGateway.DTOs
{
    public class VettedSignal
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string SignalType { get; set; }
        public decimal EntryPrice { get; set; }
        public decimal? ExitPrice { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public string Message { get; set; }
    }
}
