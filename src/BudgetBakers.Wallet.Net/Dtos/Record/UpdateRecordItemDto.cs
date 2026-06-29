using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Record
{
    internal class UpdateRecordItemDto
    {
        [JsonProperty("id")]
        public required string Id { get; set; }

        [JsonProperty("accountId")]
        public string? AccountId { get; set; }

        [JsonProperty("amount")]
        public RecordAmountDto? Amount { get; set; }

        [JsonProperty("recordDate")]
        public DateTime? RecordDate { get; set; }

        [JsonProperty("paymentType")]
        public string? PaymentType { get; set; }

        [JsonProperty("recordState")]
        public string? RecordState { get; set; }

        [JsonProperty("categoryId")]
        public string? CategoryId { get; set; }

        [JsonProperty("counterParty")]
        public string? CounterParty { get; set; }

        [JsonProperty("note")]
        public string? Note { get; set; }

        [JsonProperty("labelIds")]
        public IdsOperationDto? LabelIds { get; set; }

        [JsonProperty("$clear")]
        public IList<string>? Clear { get; set; }

        [JsonProperty("place")]
        public RecordPlaceInputDto? Place { get; set; }
    }
}
