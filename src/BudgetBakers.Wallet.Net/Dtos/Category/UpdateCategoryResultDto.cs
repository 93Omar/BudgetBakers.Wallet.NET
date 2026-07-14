using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Category
{
    internal class UpdateCategoryResultDto
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("category")]
        public CategoryDto? Category { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }

        [JsonProperty("errorType")]
        public string? ErrorType { get; set; }
    }
}
