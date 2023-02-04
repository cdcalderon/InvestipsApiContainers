using System;
using System.ComponentModel.DataAnnotations;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Models
{
    public class BottomSupport
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SignalType { get; set; }
        [Required]
        public string ZigZagSignalIdentifier { get; set; }
        [Required]
        public string Symbol { get; set; }
        [Required]
        public decimal AHighUpSlope { get; set; }
        [Required]
        public decimal ALowUpSlope { get; set; }
        [Required]
        public decimal ACloseUpSlope { get; set; }
        [Required]
        public decimal AOpenUpSlope { get; set; }
        [Required]
        public decimal BHighUpSlope { get; set; }
        [Required]
        public decimal BLowUpSlope { get; set; }
        [Required]
        public decimal BCloseUpSlope { get; set; }
        [Required]
        public decimal BOpenUpSlope { get; set; }

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
        public decimal SupportPrice1618 { get; set; }
        [Required]
        public decimal SupportPrice2618 { get; set; }
        [Required]
        public decimal SupportPrice4236 { get; set; }
        [Required]
        public decimal SupportPrice6854 { get; set; }
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
    }
}
