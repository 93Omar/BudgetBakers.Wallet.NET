using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.References
{
    internal class GetReferencesRequestDto
    {
        [JsonProperty("id")]
        public string? Id { get; set; }
    }
}
