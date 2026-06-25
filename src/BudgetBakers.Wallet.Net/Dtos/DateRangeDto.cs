using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos
{
    internal class DateRangeDto
    {
        [JsonProperty("max")]
        public string? Max { get; set; }

        [JsonProperty("min")]
        public string? Min { get; set; }
    }
}

