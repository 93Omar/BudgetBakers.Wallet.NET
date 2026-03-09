using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Api.Net.Models.Record
{
    public class GetRecordsByIdRequest
    {
        public bool AgentHints { get; set; } = false;
        public IList<string> Ids { get; set; } = Array.Empty<string>();
    }
}
