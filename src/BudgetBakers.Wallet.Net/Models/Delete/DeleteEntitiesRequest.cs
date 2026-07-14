namespace BudgetBakers.Wallet.Net.Models.Delete
{
    public class DeleteEntitiesRequest
    {
        public required DeletableEntityType EntityType { get; set; }
        public required IList<string> Ids { get; set; }
    }
}
