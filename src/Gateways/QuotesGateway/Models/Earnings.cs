using System;
using System.ComponentModel.DataAnnotations;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Models
{
    public class Earnings
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Symbol { get; set; }

        public DateTime EarningsReleaseDate { get; set; }

        public string EarningArrow { get; set; }

    }
}
