namespace InvestipsApiContainers.Gateways.QuotesGateway.Models
{
    public interface IQuote
    {
        string Symbol { get; set; }
        decimal High { get; set; }
        decimal Low { get; set; }
        decimal Close { get; set; }
        decimal Open { get; set; }
    }
}
