using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Budget
{
    internal class UpdateBudgetItemDto
    {
        [JsonProperty("id")]
        public required string Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("closed")]
        public bool? Closed { get; set; }

        [JsonProperty("startDate")]
        public string? StartDate { get; set; }

        [JsonProperty("endDate")]
        public string? EndDate { get; set; }

        [JsonProperty("accountIds")]
        public IdsOperationDto? AccountIds { get; set; }

        [JsonProperty("categoryIds")]
        public IdsOperationDto? CategoryIds { get; set; }

        [JsonProperty("labelIds")]
        public IdsOperationDto? LabelIds { get; set; }

        [JsonProperty("resetLimit")]
        public double? ResetLimit { get; set; }

        [JsonProperty("limitOverrides")]
        public IList<LimitOverrideDto>? LimitOverrides { get; set; }
    }
}
