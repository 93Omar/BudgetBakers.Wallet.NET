using BudgetBakers.Wallet.Net.Dtos;
using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Record
{
    internal class MirrorRecordEmbedDto
    {
        [JsonProperty("accountId")]
        public string? AccountId { get; set; }

        [JsonProperty("amount")]
        public AmountWithCurrencyDto? Amount { get; set; }

        [JsonProperty("counterParty")]
        public string? CounterParty { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("note")]
        public string? Note { get; set; }
    }
}
