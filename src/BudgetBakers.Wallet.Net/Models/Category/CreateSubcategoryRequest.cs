using BudgetBakers.Wallet.Net.Models;

namespace BudgetBakers.Wallet.Net.Models.Category
{
    public class CreateSubcategoryRequest
    {
        public required string Name { get; set; }
        public required string ParentId { get; set; }
        public EntityColor? Color { get; set; }
        public CategoryCardinality? Cardinality { get; set; }
    }
}
