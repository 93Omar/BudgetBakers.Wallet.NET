using Newtonsoft.Json;

namespace Wallet.Api.Net.Dtos.Goal
{
    public class GoalDto
    {
        [JsonProperty("color")]
        public string? Color { get; set; }

        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("desiredDate")]
        public string? DesiredDate { get; set; }

        [JsonProperty("iconName")]
        public string? IconName { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("initialAmount")]
        public string? InitialAmount { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("note")]
        public string? Note { get; set; }

        [JsonProperty("state")]
        public string? State { get; set; }

        [JsonProperty("stateUpdatedAt")]
        public string? StateUpdatedAt { get; set; }

        [JsonProperty("targetAmount")]
        public string? TargetAmount { get; set; }

        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; set; }
    }
}
