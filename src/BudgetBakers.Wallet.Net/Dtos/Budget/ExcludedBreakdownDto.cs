using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Budget
{
    internal class ExcludedBreakdownDto
    {
        [JsonProperty("archivedAccounts")]
        public int? ArchivedAccounts { get; set; }

        [JsonProperty("debts")]
        public int? Debts { get; set; }

        [JsonProperty("incomeCategories")]
        public int? IncomeCategories { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("totalAmountSum")]
        public decimal? TotalAmountSum { get; set; }

        [JsonProperty("transfers")]
        public int? Transfers { get; set; }

        [JsonProperty("unknownCategories")]
        public int? UnknownCategories { get; set; }
    }
}
