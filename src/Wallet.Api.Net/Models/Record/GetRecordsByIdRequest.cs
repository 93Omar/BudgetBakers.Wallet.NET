using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Api.Net.Models.Record
{
    public class GetRecordsByIdRequest
    {
        /// <summary>
        /// Enable AI agent hints in response. When true, includes structured hints to help AI agents understand the response and take follow-up actions.
        /// </summary>
        public bool AgentHints { get; set; } = false;

        /// <summary>
        /// List of record IDs (max 30).
        /// </summary>
        public IList<string> Ids { get; set; } = Array.Empty<string>();
    }
}
