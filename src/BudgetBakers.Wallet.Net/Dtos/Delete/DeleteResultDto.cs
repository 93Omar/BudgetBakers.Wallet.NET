using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Delete
{
    internal class DeleteResultDto
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }

        [JsonProperty("errorType")]
        public string? ErrorType { get; set; }
    }
}
