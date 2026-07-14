using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class CreateRecordsRequest
    {
        public required IList<CreateRecordItem> Items { get; set; }
        public bool? ReturnData { get; set; }
    }
}
