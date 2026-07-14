using System.Collections.Generic;
using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Budget
{
    internal class BudgetSpendingDto
    {
        [JsonProperty("computedAt")]
        public string? ComputedAt { get; set; }

        [JsonProperty("current")]
        public BudgetPeriodSpendingDto? Current { get; set; }

        [JsonProperty("past")]
        public IList<BudgetPeriodSpendingDto> Past { get; set; } = [];
    }
}
