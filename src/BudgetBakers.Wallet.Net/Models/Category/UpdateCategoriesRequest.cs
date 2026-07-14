using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Models.Category
{
    public class UpdateCategoriesRequest
    {
        public required IList<UpdateCategoryItem> Items { get; set; }
        public bool? ReturnData { get; set; }
    }
}
