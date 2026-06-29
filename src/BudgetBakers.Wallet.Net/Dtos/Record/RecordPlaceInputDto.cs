using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Record
{
    internal class RecordPlaceInputDto
    {
        [JsonProperty("address")]
        public string? Address { get; set; }

        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
