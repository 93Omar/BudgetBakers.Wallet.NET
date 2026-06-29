using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Models.Label
{
    public class UpdateLabelsRequest
    {
        public required IList<UpdateLabelItem> Items { get; set; }
        public bool? ReturnData { get; set; }
    }
}
