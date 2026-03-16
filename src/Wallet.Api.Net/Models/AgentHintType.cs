namespace Wallet.Api.Net.Models
{
    public enum AgentHintType
    {
        PaginationHasMore = 0,
        ResultPartialMatch = 1,
        ResultEmpty = 2,
        ParamInferred = 3,
        RateLimitWarning = 4,
        DataRecency = 5
    }
}
