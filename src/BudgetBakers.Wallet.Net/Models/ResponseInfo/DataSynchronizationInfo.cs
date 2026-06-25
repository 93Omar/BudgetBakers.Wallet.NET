using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BudgetBakers.Wallet.Net.Models.ResponseInfo
{
    public class DataSynchronizationInfo
    {
        /// <summary>
        /// Timestamp of the last data modification in UTC.
        /// </summary>
        public DateTime? LastDataChangeAt { get; set; }

        /// <summary>
        /// Revision counter for change detection. Compare values to detect data changes between requests.
        /// </summary>
        public string? LastDataChangeRevision { get; set; }

        /// <summary>
        /// If true, response data is valid but background sync is running — more changes may follow shortly.
        /// </summary>
        public bool? SyncInProgress { get; set; }
    }
}
