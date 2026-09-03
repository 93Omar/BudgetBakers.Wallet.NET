using BudgetBakers.Wallet.Net.Models;

namespace BudgetBakers.Wallet.Net.Models.Category
{
    public class UpdateCategoryItem
    {
        public required string Id { get; set; }
        public string? Name { get; set; }
        public EntityColor? Color { get; set; }
        public CategoryCardinality? Cardinality { get; set; }

        /// <summary>
        /// Fields to restore to the base (system) category default. A field cannot be both set and reset in the
        /// same call.
        /// </summary>
        public IList<CategoryResetField>? Reset { get; set; }
    }
}
