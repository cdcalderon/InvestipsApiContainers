using System;
using System.ComponentModel.DataAnnotations;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Models
{
    public class StockSignalScreenshot
    {
        [Key]
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string SignalType { get; set; }
        public string ImagePath { get; set; }
        public DateTime TimeStampDateTime { get; set; }
    }
}
