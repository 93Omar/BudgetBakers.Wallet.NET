using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Api.Net.Models.Pagination;

namespace Wallet.Api.Net.Models.RecordRule
{
    public class GetRecordRulesResponse : PaginatedResponse
    {
        public IList<RecordRule> RecordRules { get; set; } = Array.Empty<RecordRule>();
        public IList<AgentHint> AgentHints { get; set; } = Array.Empty<AgentHint>();
    }
}
