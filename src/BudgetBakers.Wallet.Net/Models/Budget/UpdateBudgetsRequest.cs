using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Models.Budget
{
    public class UpdateBudgetsRequest
    {
        public required IList<UpdateBudgetItem> Items { get; set; }
        public bool? ReturnData { get; set; }
    }
}
