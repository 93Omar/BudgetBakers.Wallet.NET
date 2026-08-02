using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Record
{
    internal class CreateRecordMirrorResultDto
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("record")]
        public RecordDto? Record { get; set; }
    }
}
