using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Category
{
    internal class UpdateCategoryItemDto
    {
        [JsonProperty("id")]
        public required string Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("color")]
        public string? Color { get; set; }

        [JsonProperty("cardinality")]
        public string? Cardinality { get; set; }

        [JsonProperty("reset")]
        public IList<string>? Reset { get; set; }
    }
}
