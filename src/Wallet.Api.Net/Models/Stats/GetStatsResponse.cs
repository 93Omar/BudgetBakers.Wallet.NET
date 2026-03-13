namespace Wallet.Api.Net.Models.Stats
{
    public class GetStatsResponse
    {
        public string? Granularity { get; set; }
        public string? Period { get; set; }
        public int Total { get; set; }
        public IList<StatsUsage> Usage { get; set; } = Array.Empty<StatsUsage>();
    }
}
