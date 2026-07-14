using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Category
{
    internal class CreateSubcategoryRequestDto
    {
        [JsonProperty("name")]
        public required string Name { get; set; }

        [JsonProperty("parentId")]
        public required string ParentId { get; set; }

        [JsonProperty("color")]
        public string? Color { get; set; }

        [JsonProperty("cardinality")]
        public string? Cardinality { get; set; }
    }
}
