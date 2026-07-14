using System;
using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class RecordPlace
    {
        public string? Address { get; set; }
        public string? Id { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? Name { get; set; }
        public IList<int> PlaceTypes { get; set; } = [];
    }
}
