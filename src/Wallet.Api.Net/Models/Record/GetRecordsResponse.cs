using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Api.Net.Models.Pagination;

namespace Wallet.Api.Net.Models.Record
{
    public class GetRecordsResponse : PaginatedResponse
    {
        public IList<string> RecordDateRange { get; set; } = Array.Empty<string>();
        public IList<Record> Records { get; set; } = Array.Empty<Record>();
        public IList<AgentHint> AgentHints { get; set; } = Array.Empty<AgentHint>();
    }
}
