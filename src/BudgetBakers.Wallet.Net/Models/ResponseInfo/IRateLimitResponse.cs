namespace BudgetBakers.Wallet.Net.Models.ResponseInfo
{
    internal interface IRateLimitResponse
    {
        RateLimitInfo RateLimit { get; }
    }
}
