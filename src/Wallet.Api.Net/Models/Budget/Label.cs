using System;

namespace Wallet.Api.Net.Models.Budget
{
    public class Label
    {
        public bool Archived { get; set; }
        public string? Color { get; set; }
        public Guid? Id { get; set; }
        public string? Name { get; set; }
    }
}
