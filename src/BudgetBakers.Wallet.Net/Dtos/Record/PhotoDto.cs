using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Record
{
    internal class PhotoDto
    {
        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("temporaryUrl")]
        public string? TemporaryUrl { get; set; }
    }
}

