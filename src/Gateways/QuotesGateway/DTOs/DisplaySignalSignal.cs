using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApiContainers.Gateways.QuotesGateway.DTOs
{
    public class DisplaySignalSignal
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public int WeekNumber { get; set; }
        public string ActivationDirection { get; set; }
        public decimal ActivationPrice { get; set; }
        public DateTime ActivationDate { get; set; }
        public string ZigZagType { get; set; }
        public decimal Support { get; set; }
        public decimal Resistance { get; set; }
    }
}
