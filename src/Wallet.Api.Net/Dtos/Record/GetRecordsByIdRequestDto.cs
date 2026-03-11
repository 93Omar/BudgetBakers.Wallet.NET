using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Api.Net.Dtos.Record
{
    internal class GetRecordsByIdRequestDto
    {
        [JsonProperty("agentHints")]
        public bool AgentHints { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }
    }
}

