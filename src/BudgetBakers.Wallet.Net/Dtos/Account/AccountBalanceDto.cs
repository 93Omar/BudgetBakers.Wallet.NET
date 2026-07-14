using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Account
{
    internal class AccountBalanceDto
    {
        [JsonProperty("availableCredit")]
        public double? AvailableCredit { get; set; }

        [JsonProperty("balanceDisplayOption")]
        public string? BalanceDisplayOption { get; set; }

        [JsonProperty("balanceMode")]
        public string? BalanceMode { get; set; }

        [JsonProperty("balanceModeFormula")]
        public string? BalanceModeFormula { get; set; }

        [JsonProperty("creditBalance")]
        public double? CreditBalance { get; set; }

        [JsonProperty("creditLimit")]
        public double? CreditLimit { get; set; }

        [JsonProperty("currencyCode")]
        public string? CurrencyCode { get; set; }

        [JsonProperty("currentBalance")]
        public double? CurrentBalance { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }

        [JsonProperty("formula")]
        public string? Formula { get; set; }

        [JsonProperty("initial")]
        public double? Initial { get; set; }

        [JsonProperty("rawCurrentBalance")]
        public double? RawCurrentBalance { get; set; }
    }
}
