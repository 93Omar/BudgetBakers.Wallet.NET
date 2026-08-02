using BudgetBakers.Wallet.Net.Models;

namespace BudgetBakers.Wallet.Net.Models.Category
{
    public class UpdateCategoryItem
    {
        public required string Id { get; set; }
        public string? Name { get; set; }
        public EntityColor? Color { get; set; }
        public CategoryCardinality? Cardinality { get; set; }
        public bool? ResetName { get; set; }
    }
}
