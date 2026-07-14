namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class TransferOutput
    {
        public TransferType? Type { get; set; }
        public MirrorRecordEmbed? MirrorRecord { get; set; }
    }
}
