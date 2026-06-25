using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetBakers.Wallet.Net.Models.Pagination
{
    public class PaginatedRequest
    {
        /// <summary>
        /// Maximum number of items to return (1-200, default: 30).
        /// </summary>
        public required int Limit { get; set; }

        /// <summary>
        /// Number of items to skip (default: 0). Used for pagination.
        /// </summary>
        public required int Offset { get; set; }
    }
}
