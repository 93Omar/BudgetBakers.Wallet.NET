namespace BudgetBakers.Wallet.Net.Models.Record
{
    /// <summary>
    /// The auto-created B-side of a paired transfer, nested under the item that requested it. Absent when the item
    /// is not a paired transfer, or when mirror creation failed (best-effort — a transfer.mirror_failed agent hint
    /// reports that case and the item still counts as succeeded).
    /// </summary>
    public class CreateRecordMirrorResult
    {
        /// <summary>
        /// The mirror record's ID.
        /// </summary>
        public string? Id { get; set; }

        public Record? Record { get; set; }
    }
}
