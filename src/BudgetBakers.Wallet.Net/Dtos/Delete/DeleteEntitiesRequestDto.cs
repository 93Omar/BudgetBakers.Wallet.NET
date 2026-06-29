using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Delete
{
    internal class DeleteEntitiesRequestDto
    {
        [JsonProperty("ids")]
        public required IList<string> Ids { get; set; }
    }
}
