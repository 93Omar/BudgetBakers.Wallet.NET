using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Delete
{
    internal class DeleteEntitiesResponseDto
    {
        [JsonProperty("results")]
        public IList<DeleteResultDto> Results { get; set; } = [];

        [JsonProperty("summary")]
        public BatchOperationSummaryDto? Summary { get; set; }
    }
}
