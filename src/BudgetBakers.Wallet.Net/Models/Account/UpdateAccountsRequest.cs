namespace BudgetBakers.Wallet.Net.Models.Account
{
    public class UpdateAccountsRequest
    {
        public required IList<UpdateAccountItem> Items { get; set; }
    }
}
