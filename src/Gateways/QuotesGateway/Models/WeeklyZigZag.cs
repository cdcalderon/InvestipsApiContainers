﻿using System;
using System.ComponentModel.DataAnnotations;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Models
{
    public class WeeklyZigZag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ZigZagIdentifier { get; set; }
        [Required]
        public string SignalType { get; set; }
        [Required]
        public string Symbol { get; set; }
        [Required]
        public decimal AHigh { get; set; }
        [Required]
        public decimal ALow { get; set; }
        [Required]
        public decimal AClose { get; set; }
        [Required]
        public decimal AOpen { get; set; }
        [Required]
        public decimal BHigh { get; set; }
        [Required]
        public decimal BLow { get; set; }
        [Required]
        public decimal BClose { get; set; }
        [Required]
        public decimal BOpen { get; set; }
        [Required]
        public decimal CHigh { get; set; }
        [Required]
        public decimal CLow { get; set; }
        [Required]
        public decimal CClose { get; set; }
        [Required]
        public decimal COpen { get; set; }
        [Required]
        public DateTime TimeStampDateTime { get; set; }
        [Required]
        public DateTime ATimeStampDateTime { get; set; }
        [Required]
        public DateTime BTimeStampDateTime { get; set; }
        [Required]
        public DateTime CTimeStampDateTime { get; set; }
        [Required]
        public int WeekNumber { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string ZigzagType { get; set; }
        [Required]
        public string Direction { get; set; }
    }
}
