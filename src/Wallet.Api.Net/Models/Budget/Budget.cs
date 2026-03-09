using System;
using System.Collections.Generic;
using Wallet.Api.Net.Models.Label;

namespace Wallet.Api.Net.Models.Budget
{
    public class Budget
    {
        public IList<Guid> AccountIds { get; set; } = Array.Empty<Guid>();
        public string? Amount { get; set; }
        public IList<Guid> CategoryIds { get; set; } = Array.Empty<Guid>();
        public DateTime? CreatedAt { get; set; }
        public string? CurrencyCode { get; set; }
        public string? EndDate { get; set; }
        public Guid? Id { get; set; }
        public IList<Wallet.Api.Net.Models.Label.Label> Labels { get; set; } = Array.Empty<Wallet.Api.Net.Models.Label.Label>();
        public string? Name { get; set; }
        public string? StartDate { get; set; }
        public string? Type { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
