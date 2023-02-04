using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace InvestipsApiContainers.Gateways.QuotesGateway.Models
{
    public class BollingerSqueezeABCFibSignal
    {
        [Key]
        public int Id { get; set; }
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
        [Required]
        public DateTime TimeStampDateTime { get; set; }
        [Required]
        public DateTime AFibUpTimeStampDateTime { get; set; }
        [Required]
        public DateTime BFibUpTimeStampDateTime { get; set; }
        [Required]
        public DateTime CFibUpTimeStampDateTime { get; set; }
        [Required]
        public DateTime AFibDownTimeStampDateTime { get; set; }
        [Required]
        public DateTime BFibDownTimeStampDateTime { get; set; }
        [Required]
        public DateTime CFibDownTimeStampDateTime { get; set; }
        [Required]
        public decimal AHighUp { get; set; }
        [Required]
        public decimal ALowUp { get; set; }
        [Required]
        public decimal ACloseUp { get; set; }
        [Required]
        public decimal AOpenUp { get; set; }
        [Required]
        public decimal BHighUp { get; set; }
        [Required]
        public decimal BLowUp { get; set; }
        [Required]
        public decimal BCloseUp { get; set; }
        [Required]
        public decimal BOpenUp { get; set; }
        [Required]
        public decimal CHighUp { get; set; }
        [Required]
        public decimal CLowUp { get; set; }
        [Required]
        public decimal CCloseUp { get; set; }
        [Required]
        public decimal COpenUp { get; set; }


        public decimal AHighDown { get; set; }
        [Required]
        public decimal ALowDown { get; set; }
        [Required]
        public decimal ACloseDown { get; set; }
        [Required]
        public decimal AOpenDown { get; set; }
        [Required]
        public decimal BHighDown { get; set; }
        [Required]
        public decimal BLowDown { get; set; }
        [Required]
        public decimal BCloseDown { get; set; }
        [Required]
        public decimal BOpenDown { get; set; }
        [Required]
        public decimal CHighDown { get; set; }
        [Required]
        public decimal CLowDown { get; set; }
        [Required]
        public decimal CCloseDown { get; set; }
        [Required]
        public decimal COpenDown { get; set; }

        public decimal? MovingAvg8 { get; set; }
        public decimal? MovingAvg10 { get; set; }
        public decimal? MovingAvg30 { get; set; }
        public decimal? Stochastics14505 { get; set; }
        public decimal? Stochastics14505_K { get; set; }
        public decimal? Stochastics14505_D { get; set; }
        public decimal BollingerTop202 { get; set; }
        public decimal BollingerBottom202 { get; set; }
        public string QuoteIndexId { get; set; }
        public int QuoteIndex { get; set; }
    }
}
