using System;
using System.ComponentModel.DataAnnotations;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Models
{
    public class HourlyQuote
    {
        [Key]
        public int Id { get; set; }
        public string Symbol { get; set; }
        public long Timestamp { get; set; }
        public DateTimeOffset Datetime { get; set; }
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }
        public int HourNumber { get; set; }
        public decimal? Stochastics14505 { get; set; }
        public decimal? Stochastics14505_K { get; set; }
        public decimal? Stochastics14505_D { get; set; }
        public bool IsStochastics1405KCrossingUp_D { get; set; }
        public bool IsStochastics1405KCrossingDown_D { get; set; }
        public int WeekNumber { get; set; }

    }
}
