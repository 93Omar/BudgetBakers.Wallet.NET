using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Record
{
    internal class TransferOutputDto
    {
        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("mirrorRecord")]
        public MirrorRecordEmbedDto? MirrorRecord { get; set; }
    }
}
