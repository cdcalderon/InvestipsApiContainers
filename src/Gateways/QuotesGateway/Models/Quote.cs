using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Models
{
    [Table("Quote", Schema = "Stock")]
    public class Quote : IQuote
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
        public bool IsZBar { get; set; }
        public bool IsSBar { get; set; }
        public decimal Volume { get; set; }
        public DateTime TimeStampDateTime { get; set; }
        public DateTime DateOfFirstDayOfWeek { get; set; }
        public decimal? MovingAvg7 { get; set; }
        public decimal? MovingAvg8 { get; set; }
        public decimal? MovingAvg10 { get; set; }
        public decimal? MovingAvg30 { get; set; }

        public decimal? MovingAvg13 { get; set; }

        public decimal? MovingAvg50 { get; set; }
        public decimal? MovingAvg150 { get; set; }

        public decimal? MovingAvg200 { get; set; }

        public decimal? VolumeMovingAvg50 { get; set; }
        public decimal? VolumeMovingAvg100 { get; set; }
        public decimal? Macd8179 { get; set; }
        public decimal? Stochastics14505 { get; set; }
        public decimal? Stochastics14505_K { get; set; }
        public decimal? Stochastics14505_D { get; set; }
        public decimal? Stochastics101 { get; set; }
        public decimal? Stochastics101_K { get; set; }
        public decimal? Stochastics101_D { get; set; }
        public bool IsStochastics1405KCrossingDown_D { get; set; }
        public bool IsStochastics1405KCrossingUp_D { get; set; }
        public bool IsPriceCrossMovAvg30Up { get; set; }
        public bool IsPriceCrossMovAvg30Down { get; set; }
        public bool IsPriceCrossMovAvg7Up { get; set; }
        public bool IsPriceCrossMovAvg7Down { get; set; }

        public bool IsPriceCrossMovAvg13Up { get; set; }
        public bool IsPriceCrossMovAvg13Down { get; set; }
        public bool IsPriceCrossMovAvg8Up { get; set; }
        public bool IsPriceCrossMovAvg8Down { get; set; }
        public bool IsPriceCrossMovAvg50Up { get; set; }
        public bool IsPriceCrossMovAvg50Down { get; set; }
        public bool IsPriceCrossMovAvg200Up { get; set; }
        public bool IsPriceCrossMovAvg200Down { get; set; }

        public bool IsStoch145Cossing25Up { get; set; }

        public bool IsStoch145Cossing75Down { get; set; }
        public bool IsStoch101Cossing20Up { get; set; }
        public bool IsStoch101Cossing80Down { get; set; }
        public bool IsMacdCrossingHorizontalUp { get; set; }
        public bool IsMacdCrossingHorizontalDown { get; set; }
        public bool IsMovingAvg30PointingUp { get; set; }
        public bool IsMovingAvg30PointingDown { get; set; }
        public bool IsMovingAvg150PointingUp { get; set; }
        public bool IsMovingAvg150PointingDown { get; set; }
        public bool IsStoch14505PointingUp { get; set; }
        public bool IsStoch14505PointingDown { get; set; }
        public bool IsNewLow { get; set; }
        public bool IsBullEight45Degreed { get; set; }
        public bool IsBearEight45Degreed { get; set; }
        public int FourtyFiveDegreeLevel { get; set; }

        public bool IsBullThreeArrow { get; set; }
        public bool IsBearThreeArrow { get; set; }
        public bool IsBullStoch307 { get; set; }
        public bool IsBearStoch307 { get; set; }
        public bool IsSuperGap { get; set; }
        public bool IsSuperGapBear { get; set; }
        public bool IsSwingHigh5Percent { get; set; }
        public bool IsSwingLow5Percent { get; set; }
        public bool IsABCUpDaily { get; set; }
        public bool IsABCDownDaily { get; set; }
        public decimal BLowToTwoPreviousWeeksLow618Support { get; set; }
        public decimal BHighToTwoPreviousWeeksHigh618Resistence { get; set; }
        public decimal ABCActivatedMondayDailyIronCondorDownLeg { get; set; }
        public decimal ABCActivatedMondayDailyIronCondorUpLeg { get; set; }    
        public bool IsABCUpSuperChargedDaily { get; set; }
        public bool IsABCDownSuperChargedDaily { get; set; }
        public decimal WeeklyFib382TargetUp { get; set; }
        public decimal WeeklyFib382TargetDown { get; set; }
        public decimal WeeklyFib618TargetUp { get; set; }
        public decimal WeeklyFib618TargetDown { get; set; }
        public int WeekNumber { get; set; }
        public int DayOfTheWeek { get; set; }
        public string DayName { get; set; }
        public string WeekDayDateRange { get; set; }
        public bool? WasFibSignalSuccessful { get; set; }
        public bool? WasFibSignalSuccessfulThursday { get; set; }
        public string IsFridayPriceCalculation { get; set; }
        public string IsThursdayPriceCalculation { get; set; }
        public decimal Fib100TargetUp { get; set; }
        public decimal Fib100TargetDown { get; set; }
        public decimal Fib161TargetUp { get; set; }
        public decimal Fib161TargetDown { get; set; }
        public bool IsThursdayCloseAboveMondayLow { get; set; }
        public bool IsThursdayCloseBelowMondayHigh { get; set; }
        public decimal AWeekHigh { get; set; }
        public decimal AWeekLow { get; set; }
        public decimal BWeekHigh { get; set; }
        public decimal BWeekLow { get; set; }
        public decimal CWeekOpen { get; set; }
        public bool IsFutureNextWeekFibActivatedUpRelax { get; set; }
        public bool IsFutureNextWeekFibActivatedDownRelax { get; set; }
        public bool IsFutureNextWeekFibActivatedUp { get; set; }
        public bool IsFutureNextWeekFibActivatedDown { get; set; }
        public bool IsFutureNextWeekFibActivatedUpSecondLevel { get; set; }
        public bool IsFutureNextWeekFibActivatedDownSecondLevel { get; set; }
        public bool IsFutureNextWeekFibActivatedUpWithCLow { get; set; }
        public bool IsFutureNextWeekFibActivatedDownWithCLow { get; set; }
        public decimal CurrentWeekFibResistance { get; set; }
        public decimal CurrentWeekFibSupport { get; set; }
        public decimal CurrentWeekFibResistanceExtrict { get; set; }
        public decimal CurrentWeekFibSupportExtrict { get; set; }
        public decimal CurrentWeekFibResistanceExtrictWithCLow { get; set; }
        public decimal CurrentWeekFibSupportExtrictWithCLow { get; set; }
        public decimal PreviousWeekLowToHighMonday618Support { get; set; }
        public decimal PreviousWeekHighToMonday618Resistance { get; set; }
        public decimal AbcBeforeOpenSupport { get; internal set; }
        public decimal AbcBeforeOpenResistence { get; internal set; }
        public decimal AbcBeforeOpenSupportExtrict { get; internal set; }
        public decimal AbcBeforeOpenResistenceExtrict { get; internal set; }
        public decimal BCCClose618Support { get; internal set; }
        public decimal BCCClose618Resistence { get; internal set; }
        public decimal BCCLow618Support { get; internal set; }
        public decimal BCCLow618Resistence { get; internal set; }
        public decimal BCCClose618FutureNextWeekSupport { get; internal set; }
        public decimal BCCClose618FutureNextWeekResistence { get; internal set; }
        public decimal BCCLow618FutureNextWeekSupport { get; internal set; }
        public decimal BCCLow618FutureNextWeekResistence { get; internal set; }
        public bool IsPreviousABCToCurrentFibSignalActiveUp { get; set; }
        public bool IsPreviousABCToCurrentFibSignalActiveDown { get; set; }
        public bool IsPreviousABCToCurrentFibMondayOpenInsideRangeSignalActiveUp { get; set; }
        public bool IsPreviousABCToCurrentFibMondayOpenInsideRangeSignalActiveDown { get; set; }
        public bool IsPreviousABCToCurrentFibMondayOpenInsideRangeSignalActiveUpActivationRelaxed { get; set; }
        public bool IsPreviousABCToCurrentFibMondayOpenInsideRangeSignalActiveDownActivationRelaxed { get; set; }
        public decimal ABCToCurrentFibSignalActiveUpActivationPrice { get; set; }
        public decimal ABCToCurrentFibSignalActiveDownActivationPrice { get; set; }
        public decimal ABCToCurrentFibMondayOpenInsideRangeSignalActiveUpActivationPrice { get; set; }
        public decimal ABCToCurrentFibMondayOpenInsideRangeSignalActiveDownActivationPrice { get; set; }
        public decimal ABCToCurrentMondayOpenInsideRangeSupport { get; set; }
        public decimal ABCToCurrentMondayOpenInsideRangeResistence { get; set; }
        public bool IsABBLowHighFibSignalActivatedUp { get; set; }
        public bool IsABBLowHighFibSignalActivatedDown { get; set; }
        public decimal ABBLowHighFibSignalSupport { get; set; }
        public decimal ABBLowHighFibMidpointSupport { get; set; }
        public decimal ABBLowHighFibMidpointResistence { get; set; }
        public decimal ABBLowIronCondorUpLeg { get; set; }
        public decimal ABBLowIronCondorMidpointDownLeg { get; set; }
        public decimal ABBLowIronCondorMidpointUpLeg { get; set; }
        public decimal ABBLowIronCondorDownLeg { get; set; }
        public decimal ABBLowHighFibSignalResistence { get; set; }
        public bool IsABBLowHighFibIronCondorSignalActivated { get; set; }
        public decimal ABBLowHighFibSignalIronCondorSupport { get; set; }
        public decimal ABBLowHighFibSignalIronCondorResistence { get; set; }

        public decimal ABBCloseFibSignalSupport { get; set; }
        public decimal ABBCloseFibSignalResistence { get; set; }
        public decimal ABBCloseFibSignalIronCondorLegUp { get; set; }
        public decimal ABBCloseFibSignalIronCondorLegDown { get; set; }
        public bool IsABBCloseFibSignalActivatedUp { get; set; }
        public decimal AvgWeeklyRange { get; set; }
        public bool IsABBCloseFibSignalActivatedDown { get; set; }
        public bool IsABBLowerBetweenCloseAndOpenIsCurrentPriceInRangeUp_100_1618 { get; set; }
        public bool IsABBLowerBetweenCloseAndOpenIsCurrentPriceInRangeDown_100_1618 { get; set; }
        public decimal AInRangeValue_100_1618 { get; set; }
        public decimal BInRangeValue_100_1618 { get; set; }
        public decimal CInRangeValue_100_1618 { get; set; }
        public DateTime AInRangeDate_100_1618 { get; set; }
        public DateTime BInRangeDate_100_1618 { get; set; }
        public DateTime CInRangeDate_100_1618 { get; set; }

        public bool IsABBLowerBetweenCloseAndOpenIsCurrentPriceInRangeUp_618_100 { get; set; }
        public bool IsABBLowerBetweenCloseAndOpenIsCurrentPriceInRangeDown_618_100 { get; set; }
        public decimal AInRangeValue_618_100 { get; set; }
        public decimal BInRangeValue_618_100 { get; set; }
        public decimal CInRangeValue_618_100 { get; set; }
        public DateTime AInRangeDate_618_100 { get; set; }
        public DateTime BInRangeDate_618_100 { get; set; }
        public DateTime CInRangeDate_618_100 { get; set; }

        public decimal ABBLowerBetweenCloseAndOpenActivationPriceClose { get; set; }
        public decimal ABBLowerBetweenCloseAndOpenActivationPriceHigh { get; set; }
        public bool IsMovAvg813CrossingUpWithZigzag { get; set; }
        public bool IsMovAvg813CrossingDownWithZigzag { get; set; }
        public decimal Avg813CrossingWithZigzagActivationPrice { get; set; }
        public DateTime ATimeStampDateTime { get; set; }
        public DateTime BTimeStampDateTime { get; set; }
        public DateTime CTimeStampDateTime { get; set; }
        public string ZigZagSignalIdentifier { get; set; }
        public decimal PriceSignal_618_100_Up_Support_Limit { get; set; }
        public decimal PriceSignal_618_100_Down_Resistance_Limit { get; set; }
        public bool IsExtendedFromMovingAvg30Up { get; set; }
        public bool IsExtendedFromMovingAvg30UpPullBackReady { get; set; }
        public decimal? DistanceFromHighToMovingAvg30 { get; set; }
        public decimal? PercentageFromHighToMovingAvg30 { get; set; }
        public bool IsDoji { get; set; }
        public decimal BollingerTop202 { get; set; }
        public decimal BollingerMiddle202 { get; set; }
        public decimal BollingerBottom202 { get; set; }
        public bool IsBollingerBandCrossingDownActivated { get; set; }

        public decimal A_ABBLowHighFibSignal { get; set; }
        public decimal B_ABBLowHighFibSignal { get; set; }
        public decimal C_ABBLowHighFibSignal { get; set; }
        public DateTime A_ABBLowHighFibSignal_Date { get; set; }
        public DateTime B_ABBLowHighFibSignal_Date { get; set; }
        public DateTime C_ABBLowHighFibSignal_Date { get; set; }
        public decimal ABBLowHighFibSignalActivationPrice { get; set; }
        public bool IsLowerCloseThanPrevious { get; set; }
        public bool IsHigherCloseThanPrevious { get; set; }
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

        public bool IsABBLowHighFibSignalActivatedWithComfirmationUp { get; set; }
        public bool IsABBLowHighFibSignalActivatedWithComfirmationDown { get; set; }
        public DateTime ABBLowHighFibSignalActivatedWithComfirmationDateTimeUp { get; set; }
        public DateTime ABBLowHighFibSignalActivatedWithComfirmationDateTimeDown { get; set; }
    }
}