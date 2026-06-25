namespace BudgetBakers.Wallet.Net.Services
{
    public interface IAccessTokenProvider
    {
        Task<string> GetAccessTokenAsync(CancellationToken ct = default);
    }
}
