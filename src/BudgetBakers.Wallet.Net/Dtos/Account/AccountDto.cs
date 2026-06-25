using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Account
{
    internal class AccountDto
    {
        [JsonProperty("accountType")]
        public string? AccountType { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("bankAccountNumber")]
        public string? BankAccountNumber { get; set; }

        [JsonProperty("color")]
        public string? Color { get; set; }

        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("excludeFromStats")]
        public bool ExcludeFromStats { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("initialBalance")]
        public BalanceDto? InitialBalance { get; set; }

        [JsonProperty("initialBaseBalance")]
        public BalanceDto? InitialBaseBalance { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("recordStats")]
        public RecordStatsDto? RecordStats { get; set; }

        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; set; }
    }
}
