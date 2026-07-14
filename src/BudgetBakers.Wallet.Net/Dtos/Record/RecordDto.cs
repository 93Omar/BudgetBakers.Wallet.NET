using System.Collections.Generic;
using BudgetBakers.Wallet.Net.Dtos;
using BudgetBakers.Wallet.Net.Dtos.Category;
using BudgetBakers.Wallet.Net.Dtos.Label;
using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Record
{
    internal class RecordDto
    {
        [JsonProperty("accountId")]
        public string? AccountId { get; set; }

        [JsonProperty("accountIsBankSync")]
        public bool? AccountIsBankSync { get; set; }

        [JsonProperty("accountName")]
        public string? AccountName { get; set; }

        [JsonProperty("amount")]
        public BalanceDto? Amount { get; set; }

        [JsonProperty("category")]
        public CategoryDto? Category { get; set; }

        [JsonProperty("convertedAmount")]
        public ConvertedAmountDto? ConvertedAmount { get; set; }

        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("labels")]
        public IList<LabelDto> Labels { get; set; } = [];

        [JsonProperty("note")]
        public string? Note { get; set; }

        [JsonProperty("counterParty")]
        public string? CounterParty { get; set; }

        [JsonProperty("paymentType")]
        public string? PaymentType { get; set; }

        [JsonProperty("photos")]
        public IList<PhotoDto> Photos { get; set; } = [];

        [JsonProperty("place")]
        public PlaceDto? Place { get; set; }

        [JsonProperty("recordDate")]
        public string? RecordDate { get; set; }

        [JsonProperty("recordState")]
        public string? RecordState { get; set; }

        [JsonProperty("recordType")]
        public string? RecordType { get; set; }

        [JsonProperty("source")]
        public string? Source { get; set; }

        [JsonProperty("transfer")]
        public TransferOutputDto? Transfer { get; set; }

        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; set; }
    }
}
