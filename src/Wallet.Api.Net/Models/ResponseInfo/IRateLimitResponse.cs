namespace Wallet.Api.Net.Models.ResponseInfo
{
    internal interface IRateLimitResponse
    {
        RateLimitInfo RateLimit { get; }
    }
}
