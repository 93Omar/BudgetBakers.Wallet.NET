using System;

namespace BudgetBakers.Wallet.Net.Models.Category
{
    public class Category
    {
        public bool Archived { get; set; }
        public string? Cardinality { get; set; }

        /// <summary>
        /// Hex color code.
        /// </summary>
        public string? Color { get; set; }

        public DateTime? CreatedAt { get; set; }
        public bool CustomCategory { get; set; }
        public bool CustomColor { get; set; }
        public bool CustomName { get; set; }
        public bool Enabled { get; set; }
        public int? EnvelopeId { get; set; }
        public string? IconName { get; set; }
        public Guid? Id { get; set; }

        /// <summary>
        /// Category name
        /// </summary>
        public string? Name { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
