namespace BudgetBakers.Wallet.Net.Models.Budget
{
    public class LimitOverride
    {
        public required string Period { get; set; }
        public decimal? Limit { get; set; }
        public bool? SetBaseline { get; set; }

        /// <summary>
        /// How many periods this override lasts, counting its own (1 = this period only). Omit for an open-ended
        /// override. Requires <see cref="Limit"/>; not allowed with <see cref="SetBaseline"/>.
        /// </summary>
        public int? PeriodCount { get; set; }
    }
}
