using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Category
{
    internal class CategoryGroupDto
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
