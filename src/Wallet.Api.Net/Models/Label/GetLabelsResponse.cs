using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Api.Net.Models.Pagination;

namespace Wallet.Api.Net.Models.Label
{
    public class GetLabelsResponse : PaginatedResponse
    {
        public IList<Label> Labels { get; set; } = Array.Empty<Label>();
        public IList<Models.Account.AgentHint> AgentHints { get; set; } = Array.Empty<Models.Account.AgentHint>();
    }
}
