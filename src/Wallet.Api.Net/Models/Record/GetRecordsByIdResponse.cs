using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Api.Net.Models.Record
{
    public class GetRecordsByIdResponse
    {
        public int Count { get; set; }
        public IList<Record> Records { get; set; } = Array.Empty<Record>();
        public IList<AgentHint> AgentHints { get; set; } = Array.Empty<AgentHint>();
    }
}
