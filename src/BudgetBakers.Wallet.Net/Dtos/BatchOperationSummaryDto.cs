using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos
{
    internal class BatchOperationSummaryDto
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("succeeded")]
        public int Succeeded { get; set; }

        [JsonProperty("clientErrors")]
        public int ClientErrors { get; set; }

        [JsonProperty("serverErrors")]
        public int ServerErrors { get; set; }
    }
}
