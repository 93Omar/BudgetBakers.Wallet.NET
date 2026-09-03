using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Label
{
    internal class UpdateLabelResultDto
    {
        [JsonProperty("inputIndex")]
        public int InputIndex { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("label")]
        public LabelDto? Label { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }

        [JsonProperty("errorType")]
        public string? ErrorType { get; set; }

        [JsonProperty("fields")]
        public IList<string>? Fields { get; set; }
    }
}
