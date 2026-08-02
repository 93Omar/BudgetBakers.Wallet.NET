using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Record
{
    internal class CreateRecordResultDto
    {
        [JsonProperty("inputIndex")]
        public int InputIndex { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("record")]
        public RecordDto? Record { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }

        [JsonProperty("errorType")]
        public string? ErrorType { get; set; }

        [JsonProperty("mirror")]
        public CreateRecordMirrorResultDto? Mirror { get; set; }
    }
}
