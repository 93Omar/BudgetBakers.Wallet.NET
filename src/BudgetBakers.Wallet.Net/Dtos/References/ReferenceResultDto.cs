using Newtonsoft.Json;
using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Dtos.References
{
    internal class ReferenceResultDto
    {
        [JsonProperty("field")]
        public string? Field { get; set; }

        [JsonProperty("hasMore")]
        public bool HasMore { get; set; }

        [JsonProperty("ids")]
        public IList<string> Ids { get; set; } = [];

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
