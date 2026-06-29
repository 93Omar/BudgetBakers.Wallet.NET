using BudgetBakers.Wallet.Net.Models;

namespace BudgetBakers.Wallet.Net.Models.Label
{
    public class CreateLabelRequest
    {
        public required string Name { get; set; }
        public EntityColor? Color { get; set; }
    }
}
