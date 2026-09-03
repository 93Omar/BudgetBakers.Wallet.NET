namespace BudgetBakers.Wallet.Net.Models.Record
{
    public class CreateRecordResult
    {
        public int InputIndex { get; set; }
        public string? Id { get; set; }
        public bool Success { get; set; }
        public Record? Record { get; set; }
        public string? Error { get; set; }
        public string? ErrorType { get; set; }

        /// <summary>
        /// Input field names the error is attributable to; empty when the error belongs to the item as a whole.
        /// </summary>
        public IList<string> Fields { get; set; } = [];

        /// <summary>
        /// ID of the auto-created B-side of a paired transfer — present only when this call wrote that document
        /// (pairingMode "new"). Null when the item is not a paired transfer, or when mirror creation failed
        /// (best-effort — a transfer.mirror_failed agent hint reports that case and the item still counts as
        /// succeeded). Survives returnData=false; the mirror's body is not returned — read
        /// transfer.mirrorRecord on the source, or fetch by this id.
        /// </summary>
        public string? CreatedMirrorRecordId { get; set; }
    }
}
