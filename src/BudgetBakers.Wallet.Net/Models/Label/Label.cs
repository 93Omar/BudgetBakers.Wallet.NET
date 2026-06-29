using System;

namespace BudgetBakers.Wallet.Net.Models.Label
{
    public class Label
    {
        /// <summary>
        /// Whether the label is archived.
        /// </summary>
        public bool Archived { get; set; }

        /// <summary>
        /// Hex color code.
        /// </summary>
        public string? Color { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
