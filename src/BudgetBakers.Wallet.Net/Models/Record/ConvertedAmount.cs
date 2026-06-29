namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class ConvertedAmount
    {
        public string? ConversionPair { get; set; }
        public string? CurrencyCode { get; set; }
        public string? Error { get; set; }
        public double? Ratio { get; set; }
        public double? Value { get; set; }
    }
}
