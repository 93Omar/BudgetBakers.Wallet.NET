namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class ConvertedAmount
    {
        public string? ConversionPair { get; set; }
        public string? CurrencyCode { get; set; }
        public string? Error { get; set; }
        public decimal? Ratio { get; set; }
        public decimal? Value { get; set; }
    }
}
