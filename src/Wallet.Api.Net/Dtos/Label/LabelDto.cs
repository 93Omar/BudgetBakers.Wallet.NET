using Newtonsoft.Json;

namespace Wallet.Api.Net.Dtos.Label
{
    public class LabelDto
    {
        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("color")]
        public string? Color { get; set; }

        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; set; }
    }
}
