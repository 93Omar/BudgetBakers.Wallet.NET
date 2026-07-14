using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Account
{
    internal class CreateAccountRequestDto
    {
        [JsonProperty("name")]
        public required string Name { get; set; }

        [JsonProperty("accountType")]
        public required string AccountType { get; set; }

        [JsonProperty("currencyCode")]
        public required string CurrencyCode { get; set; }

        [JsonProperty("initialBalance")]
        public double InitialBalance { get; set; }

        [JsonProperty("color")]
        public string? Color { get; set; }

        [JsonProperty("bankAccountNumber")]
        public string? BankAccountNumber { get; set; }

        [JsonProperty("excludeFromStats")]
        public bool ExcludeFromStats { get; set; }
    }
}
