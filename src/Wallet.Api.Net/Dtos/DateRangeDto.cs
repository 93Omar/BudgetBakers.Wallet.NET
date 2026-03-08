using Newtonsoft.Json;

namespace Wallet.Api.Net.Dtos
{
    public class DateRangeDto
    {
        [JsonProperty("max")]
        public string? Max { get; set; }

        [JsonProperty("min")]
        public string? Min { get; set; }
    }
}
