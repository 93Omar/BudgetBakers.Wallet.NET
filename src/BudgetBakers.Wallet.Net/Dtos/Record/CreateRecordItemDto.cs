using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Record
{
    internal class CreateRecordItemDto
    {
        [JsonProperty("accountId")]
        public required string AccountId { get; set; }

        [JsonProperty("amount")]
        public required RecordAmountDto Amount { get; set; }

        [JsonProperty("recordDate")]
        public DateTime RecordDate { get; set; }

        [JsonProperty("paymentType")]
        public required string PaymentType { get; set; }

        [JsonProperty("categoryId")]
        public string? CategoryId { get; set; }

        [JsonProperty("counterParty")]
        public string? CounterParty { get; set; }

        [JsonProperty("note")]
        public string? Note { get; set; }

        [JsonProperty("labelIds")]
        public IList<string>? LabelIds { get; set; }

        [JsonProperty("recordState")]
        public string? RecordState { get; set; }

        [JsonProperty("place")]
        public RecordPlaceInputDto? Place { get; set; }
    }
}
