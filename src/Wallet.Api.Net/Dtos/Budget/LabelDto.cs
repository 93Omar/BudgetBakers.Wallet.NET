using Newtonsoft.Json;

namespace Wallet.Api.Net.Dtos.Budget
{
    public class LabelDto
    {
        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("color")]
        public string? Color { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
