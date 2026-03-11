using Newtonsoft.Json;

namespace Wallet.Api.Net.Dtos
{
    internal class RecordStatsDto
    {
        [JsonProperty("createdAt")]
        public DateRangeDto? CreatedAt { get; set; }

        [JsonProperty("recordCount")]
        public int RecordCount { get; set; }

        [JsonProperty("recordDate")]
        public DateRangeDto? RecordDate { get; set; }
    }
}

