using Newtonsoft.Json;
using System.Collections.Generic;
using Wallet.Api.Net.Dtos;
using Wallet.Api.Net.Dtos.Category;
using Wallet.Api.Net.Dtos.Label;

namespace Wallet.Api.Net.Dtos.Record
{
    internal class RecordDto
    {
        [JsonProperty("accountId")]
        public string? AccountId { get; set; }

        [JsonProperty("amount")]
        public BalanceDto? Amount { get; set; }

        [JsonProperty("baseAmount")]
        public BalanceDto? BaseAmount { get; set; }

        [JsonProperty("category")]
        public CategoryDto? Category { get; set; }

        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("labels")]
        public IList<LabelDto> Labels { get; set; } = Array.Empty<LabelDto>();

        [JsonProperty("note")]
        public string? Note { get; set; }

        [JsonProperty("payee")]
        public string? Payee { get; set; }

        [JsonProperty("payer")]
        public string? Payer { get; set; }

        [JsonProperty("paymentType")]
        public string? PaymentType { get; set; }

        [JsonProperty("photos")]
        public IList<PhotoDto> Photos { get; set; } = Array.Empty<PhotoDto>();

        [JsonProperty("place")]
        public PlaceDto? Place { get; set; }

        [JsonProperty("recordDate")]
        public string? RecordDate { get; set; }

        [JsonProperty("recordState")]
        public string? RecordState { get; set; }

        [JsonProperty("recordType")]
        public string? RecordType { get; set; }

        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; set; }
    }
}

