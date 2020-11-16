using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApiContainers.Gateways.QuotesGateway.DTOs
{
    public class ZigZagFiboSignal
    {
        public string Symbol { get; set; }
        public int WeekNumber { get; set; }
        public string ActivationDirection { get; set; }
        public decimal ActivationPrice { get; set; }
        public DateTime ActivationDate { get; set; }
        public decimal ALow { get; set; }
        public decimal AHigh { get; set; }
        public decimal BHigh { get; set; }
        public decimal BLow { get; set; }
        public decimal CLow { get; set; }
        public decimal CHigh { get; set; }
        public decimal Support { get; set; }
        public decimal Resistence { get; set; }
        public decimal CLowestOpenOrClose { get; set; }
        public decimal CHighestOpenOrClose { get; set; }
        public DateTime ADate { get; set; }
        public DateTime BDate { get; set; }
        public DateTime CDate { get; set; }
        public string ZigzagType { get; set; }
    }
}
