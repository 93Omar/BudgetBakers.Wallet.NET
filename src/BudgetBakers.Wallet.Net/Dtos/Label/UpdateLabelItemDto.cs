using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Label
{
    internal class UpdateLabelItemDto
    {
        [JsonProperty("id")]
        public required string Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("color")]
        public string? Color { get; set; }

        [JsonProperty("archived")]
        public bool? Archived { get; set; }
    }
}
