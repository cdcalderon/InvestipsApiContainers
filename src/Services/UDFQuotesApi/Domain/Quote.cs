using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UDFQuotesApi.Domain
{
    public class Quote
    {
        public int Id { get; set; }
        
        public string Symbol { get; set; }
      
        public decimal High { get; set; }
        
        public decimal Low { get; set; }
        
        public decimal Close { get; set; }
        
        public decimal Open { get; set; }

        public DateTime TimeStampDateTime { get; set; }

        public decimal MovingAvg7 { get; set; }
        public decimal MovingAvg10 { get; set; }
        public decimal MovingAvg30 { get; set; }
        public decimal Macd8179 { get; set; }
        public decimal Stochastics14505 { get; set; }
        public decimal Stochastics101 { get; set; }
        public bool IsPriceCrossMovAvg30Up { get; set; }
        public bool IsPriceCrossMovAvg7Up { get; set; }
        public bool IsStoch145Cossing25Up { get; set; }
        public bool IsStoch101Cossing20Up { get; set; }
        public bool IsMacdCrossingHorizontalUp { get; set; }
        public bool IsMovingAvg30PointingUp { get; set; }
        public bool IsNewLow { get; set; }
        public bool IsBullEight45Degreed { get; set; }
        public int FourtyFiveDegreeLevel { get; set; }

        public bool IsBullThreeArrow { get; set; }
    }
}
