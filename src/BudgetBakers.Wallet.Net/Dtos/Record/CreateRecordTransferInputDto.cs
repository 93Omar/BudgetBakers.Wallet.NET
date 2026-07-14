using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Record
{
    internal class CreateRecordTransferInputDto
    {
        [JsonProperty("pairingMode")]
        public required string PairingMode { get; set; }

        [JsonProperty("accountId")]
        public string? AccountId { get; set; }

        [JsonProperty("recordId")]
        public string? RecordId { get; set; }

        [JsonProperty("counterAmount")]
        public RecordAmountDto? CounterAmount { get; set; }
    }
}
