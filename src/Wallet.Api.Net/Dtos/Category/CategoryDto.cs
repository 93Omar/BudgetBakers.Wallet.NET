using Newtonsoft.Json;
namespace Wallet.Api.Net.Dtos.Category
{
    internal class CategoryDto
    {
        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("cardinality")]
        public string? Cardinality { get; set; }

        [JsonProperty("color")]
        public string? Color { get; set; }

        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("customCategory")]
        public bool CustomCategory { get; set; }

        [JsonProperty("customColor")]
        public bool CustomColor { get; set; }

        [JsonProperty("customName")]
        public bool CustomName { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("envelopeId")]
        public int? EnvelopeId { get; set; }

        [JsonProperty("iconName")]
        public string? IconName { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; set; }
    }
}

