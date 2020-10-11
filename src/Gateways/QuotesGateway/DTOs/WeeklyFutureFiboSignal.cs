using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApiContainers.Gateways.QuotesGateway.DTOs
{
    public class WeeklyFutureFiboSignal
    {
        public string Symbol { get; set; }
        public int WeekNumber { get; set; }
        public bool IsFutureNextWeekFibActivatedUp { get; set; }
        public bool IsFutureNextWeekFibActivatedDown { get; set; }
        public decimal CurrentWeekFibSupport { get; set; }
        public decimal CurrentWeekFibResistence { get; set; }
        public decimal CurrentWeekFibSupportRelaxed { get; set; }
        public decimal CurrentWeekFibResistenceRelaxed { get; set; }
        public decimal IronCondorUpLeg { get; set; }
        public decimal IronCondorDownLeg { get; set; }
        public decimal Close { get; set; }
        public DateTime TimeStampDateTime { get; set; }
        public DateTime DateOfFirstDayOfWeek { get; set; }
    }
}
