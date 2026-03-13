using Newtonsoft.Json;

namespace Wallet.Api.Net.Dtos.Stats
{
    internal class StatsUsageDto
    {
        [JsonProperty("from")]
        public string? From { get; set; }

        [JsonProperty("to")]
        public string? To { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
