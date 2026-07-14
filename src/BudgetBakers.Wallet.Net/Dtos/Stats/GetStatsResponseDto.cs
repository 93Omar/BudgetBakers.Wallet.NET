using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Stats
{
    internal class GetStatsResponseDto
    {
        [JsonProperty("granularity")]
        public string? Granularity { get; set; }

        [JsonProperty("period")]
        public string? Period { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("usage")]
        public IList<StatsUsageDto> Usage { get; set; } = [];
    }
}
