using Newtonsoft.Json;
using System.Collections.Generic;
using Wallet.Api.Net.Dtos.Category;
using Wallet.Api.Net.Dtos.Label;

namespace Wallet.Api.Net.Dtos.RecordRule
{
    internal class RecordRuleDto
    {
        [JsonProperty("category")]
        public CategoryDto? Category { get; set; }

        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("fromAccountId")]
        public string? FromAccountId { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("keywords")]
        public IList<string> Keywords { get; set; } = System.Array.Empty<string>();

        [JsonProperty("labels")]
        public IList<LabelDto> Labels { get; set; } = System.Array.Empty<LabelDto>();

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("toAccountId")]
        public string? ToAccountId { get; set; }

        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; set; }
    }
}

