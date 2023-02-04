using System;
using System.ComponentModel.DataAnnotations;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Models
{
    public class GapSignal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SignalType { get; set; }
        public string Symbol { get; set; }
        [Required]
        public decimal High { get; set; }
        [Required]
        public decimal Low { get; set; }
        [Required]
        public decimal Close { get; set; }
        [Required]
        public decimal Open { get; set; }
        public decimal FirstGapBarHigh { get; set; }
        public decimal FirstGapBarLow { get; set; }
        public decimal FirstGapBarClose { get; set; }
        public decimal FirstGapBarOpen { get; set; }
        public decimal SecondGapBarHigh { get; set; }
        public decimal SecondGapBarLow { get; set; }
        public decimal SecondGapBarClose { get; set; }
        public decimal SecondGapBarOpen { get; set; }
        public decimal Fib382TargetUp { get; set; }
        public decimal Fib382TargetDown { get; set; }
        public decimal Fib618TargetUp { get; set; }
        public decimal Fib618TargetDown { get; set; }
        public decimal Fib100TargetUp { get; set; }
        public decimal Fib100TargetDown { get; set; }
        public decimal Fib161TargetUp { get; set; }
        public decimal Fib161TargetDown { get; set; }
        public DateTime Date { get; set; }
        public DateTime FirstGapBarDate { get; set; }
        public DateTime SecondGapBarDate { get; set; }
        public string Direction { get; set; }
    }
}
