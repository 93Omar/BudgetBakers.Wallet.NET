using System;

namespace Wallet.Api.Net.Models.Label
{
    public class Label
    {
        public bool Archived { get; set; }
        public string? Color { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
