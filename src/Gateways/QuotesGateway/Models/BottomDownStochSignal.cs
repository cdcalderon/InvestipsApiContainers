using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Models
{
    public class BottomDownStochSignal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SignalType { get; set; }
        [Required]
        public string Symbol { get; set; }
        [Required]
        public DateTime TimeStampDateTime { get; set; }
        [Required]
        public DateTime ATimeStampDateTimeUpSlope { get; set; }
        [Required]
        public DateTime BTimeStampDateTimeUpSlope { get; set; }
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
        public decimal ZigZagPercent { get; set; }
        [Required]
        public string ZigZagSignalIdentifier { get; set; }
    }
}
