using Wallet.Api.Net.Models;

namespace Wallet.Api.Net.Models.Stats
{
    public class GetStatsRequest
    {
        public required PeriodFilter Period { get; set; }
    }
}
