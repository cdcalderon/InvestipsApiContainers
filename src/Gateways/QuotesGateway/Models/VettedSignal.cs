using System;
using System.ComponentModel.DataAnnotations;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Models
{
    public class VettedSignal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Symbol { get; set; }
        [Required]
        public string SignalType { get; set; }
        [Required]
        public decimal EntryPrice { get; set; }
        [Required]
        public decimal? ExitPrice { get; set; }
        [Required]
        public DateTime EntryDate { get; set; }
        [Required]
        public DateTime? ExitDate { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
