using Newtonsoft.Json;
using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Dtos.StandingOrder
{
    internal class StandingOrderItemDto
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("standingOrderId")]
        public string? StandingOrderId { get; set; }

        [JsonProperty("originalDate")]
        public string? OriginalDate { get; set; }

        [JsonProperty("alignedDate")]
        public string? AlignedDate { get; set; }

        [JsonProperty("dismissed")]
        public bool Dismissed { get; set; }

        [JsonProperty("paidDate")]
        public string? PaidDate { get; set; }

        [JsonProperty("paidFromAppDate")]
        public string? PaidFromAppDate { get; set; }

        [JsonProperty("recordIds")]
        public IList<string> RecordIds { get; set; } = [];
    }
}
