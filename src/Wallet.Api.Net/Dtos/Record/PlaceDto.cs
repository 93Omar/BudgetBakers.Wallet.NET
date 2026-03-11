using Newtonsoft.Json;
using System.Collections.Generic;

namespace Wallet.Api.Net.Dtos.Record
{
    internal class PlaceDto
    {
        [JsonProperty("address")]
        public string? Address { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("placeTypes")]
        public IList<int> PlaceTypes { get; set; } = System.Array.Empty<int>();
    }
}

