using System;
using System.ComponentModel.DataAnnotations;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Models
{
    public class ZigzagCPoint
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SignalType { get; set; }
        [Required]
        public string ZigZagIdentifier { get; set; }
        [Required]
        public string Symbol { get; set; }
        [Required]
        public decimal High { get; set; }
        [Required]
        public decimal Low { get; set; }
        [Required]
        public decimal Close { get; set; }
        [Required]
        public decimal Open { get; set; }
        public DateTime TimeStampDateTime { get; set; }

        [Required]
        public int WeekNumber { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string ZigzagType { get; set; }
        [Required]
        public string Direction { get; set; }
        public decimal BollingerTop202 { get; set; }
        public decimal BollingerMiddle202 { get; set; }
        public decimal BollingerBottom202 { get; set; }
    }
}
