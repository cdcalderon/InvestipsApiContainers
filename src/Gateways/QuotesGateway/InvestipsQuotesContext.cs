using InvestipsApiContainers.Gateways.QuotesGateway.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestipsApiContainers.Gateways.QuotesGateway
{
    public class InvestipsQuotesContext : DbContext
    {
        public InvestipsQuotesContext(DbContextOptions<InvestipsQuotesContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<Earnings> Earnings { get; set; }
        public virtual DbSet<GapSignal> GapSignals { get; set; }
        public virtual DbSet<ZigZagSignal> ZigZagSignals { get; set; }
        public virtual DbSet<ABBCloseFibTouchingSignal> ABBCloseFibTouchingSignals { get; set; }
        public virtual DbSet<HourlyQuote> HourlyQuotes { get; set; }
        public virtual DbSet<WeeklyZigZag> WeeklyZigZags { get; set; }
        public virtual DbSet<ZigzagCPoint> ZigzagCPoints { get; set; }
        public virtual DbSet<ZigZagSignalPremium> ZigZagSignalPremiums { get; set; }
        public virtual DbSet<BottomSupport> BottomSupports { get; set; }
        public virtual DbSet<BottomDownStochSignal> BottomDownStochSignals { get; set; }
        public virtual DbSet<StockSignalScreenshot> StockSignalScreenshots { get; set; }
        public virtual DbSet<VettedSignal> VettedSignals { get; set; }
        public virtual DbSet<BollingerStochAvg8Signal> BollingerStochAvg8Signals { get; set; }
        public virtual DbSet<ZigzagLowSwingPoint> ZigzagLowSwingPoints { get; set; }

        public virtual DbSet<BollingerSqueezeABCFibSignal> BollingerSqueezeABCFibSignals { get; set; }
    }
}
