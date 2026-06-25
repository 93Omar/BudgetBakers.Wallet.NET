using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos
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

