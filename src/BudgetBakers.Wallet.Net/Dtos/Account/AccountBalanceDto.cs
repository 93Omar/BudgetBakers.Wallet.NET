using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Account
{
    internal class AccountBalanceDto
    {
        [JsonProperty("availableCredit")]
        public decimal? AvailableCredit { get; set; }

        [JsonProperty("balanceDisplayOption")]
        public string? BalanceDisplayOption { get; set; }

        [JsonProperty("balanceMode")]
        public string? BalanceMode { get; set; }

        [JsonProperty("balanceModeFormula")]
        public string? BalanceModeFormula { get; set; }

        [JsonProperty("creditBalance")]
        public decimal? CreditBalance { get; set; }

        [JsonProperty("creditLimit")]
        public decimal? CreditLimit { get; set; }

        [JsonProperty("currencyCode")]
        public string? CurrencyCode { get; set; }

        [JsonProperty("currentBalance")]
        public decimal? CurrentBalance { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }

        [JsonProperty("formula")]
        public string? Formula { get; set; }

        [JsonProperty("initial")]
        public decimal? Initial { get; set; }

        [JsonProperty("rawCurrentBalance")]
        public decimal? RawCurrentBalance { get; set; }
    }
}
