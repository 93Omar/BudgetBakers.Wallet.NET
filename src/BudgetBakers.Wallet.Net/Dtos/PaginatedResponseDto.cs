using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetBakers.Wallet.Net.Dtos
{
    internal class PaginatedResponseDto
    {
        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("nextOffset")]
        public int NextOffset { get; set; }
    }
}

