namespace BudgetBakers.Wallet.Net.Models
{
    public class Balance
    {
        /// <summary>
        /// Currency code (ISO 4217).
        /// </summary>
        public string? CurrencyCode { get; set; }

        /// <summary>
        /// Amount value in decimal format.
        /// </summary>
        public decimal Value { get; set; }
    }
}
