using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Label
{
    internal class CreateLabelRequestDto
    {
        [JsonProperty("name")]
        public required string Name { get; set; }

        [JsonProperty("color")]
        public string? Color { get; set; }
    }
}
