using Newtonsoft.Json;
using System.Collections.Generic;

namespace Wallet.Api.Net.Dtos.StandingOrder
{
    internal class StandingOrderDto
    {
        [JsonProperty("accountId")]
        public string? AccountId { get; set; }

        [JsonProperty("amount")]
        public string? Amount { get; set; }

        [JsonProperty("categoryId")]
        public string? CategoryId { get; set; }

        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("currencyCode")]
        public string? CurrencyCode { get; set; }

        [JsonProperty("generateFromDate")]
        public string? GenerateFromDate { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("labels")]
        public IList<Wallet.Api.Net.Dtos.Label.LabelDto> Labels { get; set; } = System.Array.Empty<Wallet.Api.Net.Dtos.Label.LabelDto>();

        [JsonProperty("manualPayment")]
        public bool ManualPayment { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("note")]
        public string? Note { get; set; }

        [JsonProperty("payee")]
        public string? Payee { get; set; }

        [JsonProperty("payer")]
        public string? Payer { get; set; }

        [JsonProperty("paymentType")]
        public string? PaymentType { get; set; }

        [JsonProperty("recurrenceRule")]
        public string? RecurrenceRule { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; set; }
    }
}

