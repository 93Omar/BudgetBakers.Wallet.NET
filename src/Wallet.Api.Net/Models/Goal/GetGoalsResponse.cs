using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Api.Net.Models.Pagination;

namespace Wallet.Api.Net.Models.Goal
{
    public class GetGoalsResponse : PaginatedResponse
    {
        public IList<Goal> Goals { get; set; } = Array.Empty<Goal>();
        public IList<AgentHint> AgentHints { get; set; } = Array.Empty<AgentHint>();
    }
}
