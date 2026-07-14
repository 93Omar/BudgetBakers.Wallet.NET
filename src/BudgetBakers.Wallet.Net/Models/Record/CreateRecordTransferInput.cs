namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class CreateRecordTransferInput
    {
        public required TransferPairingMode PairingMode { get; set; }
        public string? AccountId { get; set; }
        public string? RecordId { get; set; }
        public RecordAmount? CounterAmount { get; set; }
    }
}
