using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Api.Net.Models.Pagination
{
    public class PaginatedRequest
    {
        public required int Limit { get; set; }
        public required int Offset { get; set; }
    }
}
