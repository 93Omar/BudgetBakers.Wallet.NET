using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Api.Net.Models.Pagination
{
    public class PaginatedResponse
    {
        public required int Limit { get; set; }
        public required int Offset { get; set; }
        public required int NextOffset { get; set; }
    }
}
