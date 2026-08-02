using System;

namespace BudgetBakers.Wallet.Net.Models.Category
{
    public class Category
    {
        public bool Archived { get; set; }

        /// <summary>
        /// The category's spending nature. A category with no cardinality of its own inherits its base
        /// category's value.
        /// </summary>
        public CategoryCardinality? Cardinality { get; set; }

        /// <summary>
        /// Hex color code.
        /// </summary>
        public string? Color { get; set; }

        public DateTime? CreatedAt { get; set; }
        public bool CustomCategory { get; set; }
        public bool CustomName { get; set; }
        public bool Enabled { get; set; }
        public CategoryGroup? Group { get; set; }
        public string? Id { get; set; }

        /// <summary>
        /// Category name
        /// </summary>
        public string? Name { get; set; }

        public string? ParentId { get; set; }
        public string? SystemId { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
