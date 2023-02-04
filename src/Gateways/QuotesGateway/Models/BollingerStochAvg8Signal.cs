using System;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Models
{
    public class BollingerStochAvg8Signal
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Open { get; set; }
        public bool IsZBar { get; set; }
        public bool IsSBar { get; set; }
        public decimal Volume { get; set; }
        public DateTime TimeStampDateTime { get; set; }
        public decimal? MovingAvg7 { get; set; }
        public decimal? MovingAvg8 { get; set; }
        public decimal? MovingAvg10 { get; set; }
        public decimal? MovingAvg30 { get; set; }

        public decimal? MovingAvg13 { get; set; }

        public decimal? MovingAvg50 { get; set; }
        public decimal? MovingAvg150 { get; set; }

        public decimal? MovingAvg200 { get; set; }
        public decimal? Macd8179 { get; set; }
        public decimal? Stochastics14505 { get; set; }
        public decimal? Stochastics14505_K { get; set; }
        public decimal? Stochastics14505_D { get; set; }
        public bool IsStochastics1405KCrossingDown_D { get; set; }
        public bool IsStochastics1405KCrossingUp_D { get; set; }
        public bool IsPriceCrossMovAvg13Up { get; set; }
        public bool IsPriceCrossMovAvg13Down { get; set; }
        public bool IsPriceCrossMovAvg8Up { get; set; }
        public bool IsPriceCrossMovAvg8Down { get; set; }
        public bool IsStoch145Cossing25Up { get; set; }
        public bool IsStoch145Cossing75Down { get; set; }
        public bool IsMacdCrossingHorizontalUp { get; set; }
        public bool IsMacdCrossingHorizontalDown { get; set; }
        public bool IsMovingAvg30PointingUp { get; set; }
        public bool IsMovingAvg30PointingDown { get; set; }
        public bool IsStoch14505PointingUp { get; set; }
        public bool IsStoch14505PointingDown { get; set; }
        public bool IsNewLow { get; set; }
        public decimal BollingerTop202 { get; set; }
        public decimal BollingerMiddle202 { get; set; }
        public decimal BollingerBottom202 { get; set; }
        public bool IsBollingerBandCrossingDownActivated { get; set; }
        public decimal StochKDDistance { get; set; }
        public decimal StochKDDistancePercentage { get; set; }
        public bool IsZigZagDailyWithStoch145KDFarApartUp { get; set; }
        public bool IsZigZagDailyWithStoch145KDFarApartDown { get; set; }
        public decimal ZigZagDailyWithStoch145KDFarApartUpSupport { get; set; }
        public decimal ZigZagDailyWithStoch145KDFarApartDownResistance { get; set; }
        public bool IsStoch145KDFarApartDayAfterCrossingUp { get; set; }
        public bool IsStoch145KDFarApartDayAfterCrossingDown { get; set; }
        public bool IsStoch145KDFClosingDown { get; set; }
        public bool IsStoch145KDExpandingUP { get; set; }
        public bool IsSpecializedStoch145CrossingDown { get; set; }
        public bool IsSpecializedStoch145CrossingUp { get; set; }
        public bool IsHigh { get; set; }
        public bool IsLow { get; set; }

    }
}
