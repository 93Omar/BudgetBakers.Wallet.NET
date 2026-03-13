using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Api.Net.Models.Pagination;

namespace Wallet.Api.Net.Models.Record
{
    public class GetRecordsRequest : PaginatedRequest
    {
        public string? AccountId { get; set; }
        public DateFilter? RecordDate { get; set; }
        public bool AgentHints { get; set; } = false;
        public string? CategoryId { get; set; }
        public string? LabelId { get; set; }
        public TextFilter? Note { get; set; }
        public TextFilter? Payee { get; set; }
        public string? Amount { get; set; }
        public DateFilter? CreatedAt { get; set; }
        public DateFilter? UpdatedAt { get; set; }
        public string? SortBy { get; set; }
    }
}
