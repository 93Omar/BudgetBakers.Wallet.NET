using System.Collections.Generic;
using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Budget
{
    internal class BudgetPeriodSpendingDto
    {
        [JsonProperty("convertedCurrencies")]
        public IList<string> ConvertedCurrencies { get; set; } = [];

        [JsonProperty("error")]
        public string? Error { get; set; }

        [JsonProperty("excluded")]
        public ExcludedBreakdownDto? Excluded { get; set; }

        [JsonProperty("effectiveLimit")]
        public double? EffectiveLimit { get; set; }

        [JsonProperty("incomplete")]
        public bool? Incomplete { get; set; }

        [JsonProperty("limit")]
        public double? Limit { get; set; }

        [JsonProperty("overspent")]
        public double? Overspent { get; set; }

        [JsonProperty("period")]
        public string? Period { get; set; }

        [JsonProperty("periodEnd")]
        public string? PeriodEnd { get; set; }

        [JsonProperty("periodStart")]
        public string? PeriodStart { get; set; }

        [JsonProperty("progress")]
        public double? Progress { get; set; }

        [JsonProperty("recordCount")]
        public int? RecordCount { get; set; }

        [JsonProperty("remaining")]
        public double? Remaining { get; set; }

        [JsonProperty("spent")]
        public double? Spent { get; set; }

        [JsonProperty("totalExpenses")]
        public double? TotalExpenses { get; set; }

        [JsonProperty("totalIncomes")]
        public double? TotalIncomes { get; set; }
    }
}
