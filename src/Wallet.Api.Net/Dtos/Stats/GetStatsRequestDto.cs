using Newtonsoft.Json;

namespace Wallet.Api.Net.Dtos.Stats
{
    internal class GetStatsRequestDto
    {
        [JsonProperty("period")]
        public required string Period { get; set; }
    }
}
