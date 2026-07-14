using System.Collections.Generic;

namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class UpdateRecordsRequest
    {
        public required IList<UpdateRecordItem> Items { get; set; }
        public bool? ReturnData { get; set; }
        public bool? ValidationStrict { get; set; }
    }
}
