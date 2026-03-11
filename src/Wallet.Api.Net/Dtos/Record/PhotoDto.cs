using Newtonsoft.Json;

namespace Wallet.Api.Net.Dtos.Record
{
    internal class PhotoDto
    {
        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("temporaryUrl")]
        public string? TemporaryUrl { get; set; }
    }
}

