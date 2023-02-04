using System;
using System.ComponentModel.DataAnnotations;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Models
{
    public class ABBCloseFibTouchingSignal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SignalType { get; set; }
        [Required]
        public string Symbol { get; set; }
        [Required]
        public decimal ActivationPriceUp { get; set; }
        [Required]
        public decimal ActivationPriceDown { get; set; }
        [Required]
        public decimal ActivationSignalPriceUp { get; set; }
        [Required]
        public decimal ActivationSignalPriceDown { get; set; }
        [Required]
        public bool IsActivationPriceUp { get; set; }
        [Required]
        public bool IsActivationPriceDown { get; set; }
        [Required]
        public decimal Support { get; set; }
        [Required]
        public decimal Resistance { get; set; }
        [Required]
        public DateTime ActivationDateUp { get; set; }
        [Required]
        public DateTime ActivationDateDown { get; set; }
        [Required]
        public DateTime TimeStampDateTime { get; set; }
        [Required]
        public int WeekNumber { get; set; }
        [Required]
        public int Year { get; set; }
    }
}
