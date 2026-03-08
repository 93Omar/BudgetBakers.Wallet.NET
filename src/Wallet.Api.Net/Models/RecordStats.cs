namespace Wallet.Api.Net.Models
{
    public class RecordStats
    {
        public DateRange? CreatedAt { get; set; }

        public int RecordCount { get; set; }

        public DateRange? RecordDate { get; set; }
    }
}
