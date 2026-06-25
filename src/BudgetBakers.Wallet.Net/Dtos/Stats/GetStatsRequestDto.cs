using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Stats
{
    internal class GetStatsRequestDto
    {
        [JsonProperty("period")]
        public required string Period { get; set; }
    }
}
