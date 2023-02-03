using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApiContainers.Gateways.QuotesGateway.DTOs
{
    public class BottomSupport
    {
        public int Id { get; set; }

        public string ZigZagSignalIdentifier { get; set; }

        public string Symbol { get; set; }

        public decimal AHighUpSlope { get; set; }

        public decimal ALowUpSlope { get; set; }

        public decimal ACloseUpSlope { get; set; }

        public decimal AOpenUpSlope { get; set; }

        public decimal BHighUpSlope { get; set; }

        public decimal BLowUpSlope { get; set; }

        public decimal BCloseUpSlope { get; set; }

        public decimal BOpenUpSlope { get; set; }

        public decimal AHigh { get; set; }

        public decimal ALow { get; set; }

        public decimal AClose { get; set; }

        public decimal AOpen { get; set; }

        public decimal BHigh { get; set; }

        public decimal BLow { get; set; }

        public decimal BClose { get; set; }

        public decimal BOpen { get; set; }

        public decimal CHigh { get; set; }

        public decimal CLow { get; set; }

        public decimal CClose { get; set; }

        public decimal COpen { get; set; }

        public decimal SupportPrice1618 { get; set; }

        public decimal SupportPrice2618 { get; set; }

        public decimal SupportPrice4236 { get; set; }

        public decimal SupportPrice6854 { get; set; }

        public DateTime TimeStampDateTime { get; set; }

        public DateTime ATimeStampDateTimeUpSlope { get; set; }

        public DateTime BTimeStampDateTimeUpSlope { get; set; }

        public DateTime ATimeStampDateTime { get; set; }

        public DateTime BTimeStampDateTime { get; set; }

        public DateTime CTimeStampDateTime { get; set; }

        public int WeekNumber { get; set; }

        public int Year { get; set; }

        public string ZigzagType { get; set; }

        public decimal ZigZagPercent { get; set; }
    }
}
