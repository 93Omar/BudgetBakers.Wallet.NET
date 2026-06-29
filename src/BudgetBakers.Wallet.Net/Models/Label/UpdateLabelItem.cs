using BudgetBakers.Wallet.Net.Models;

namespace BudgetBakers.Wallet.Net.Models.Label
{
    public class UpdateLabelItem
    {
        public required string Id { get; set; }
        public string? Name { get; set; }
        public EntityColor? Color { get; set; }
        public bool? Archived { get; set; }
    }
}
