using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Record
{
    internal class CreateRecordsResponseDto
    {
        [JsonProperty("results")]
        public IList<CreateRecordResultDto> Results { get; set; } = [];

        [JsonProperty("summary")]
        public BatchOperationSummaryDto? Summary { get; set; }
    }
}
