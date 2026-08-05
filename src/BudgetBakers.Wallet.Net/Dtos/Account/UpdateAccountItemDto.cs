using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Account
{
    internal class UpdateAccountItemDto
    {
        [JsonProperty("id")]
        public required string Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("color")]
        public string? Color { get; set; }

        [JsonProperty("archived")]
        public bool? Archived { get; set; }

        [JsonProperty("excludeFromStats")]
        public bool? ExcludeFromStats { get; set; }

        [JsonProperty("initialBalance")]
        public decimal? InitialBalance { get; set; }

        [JsonProperty("bankAccountNumber")]
        public string? BankAccountNumber { get; set; }
    }
}
