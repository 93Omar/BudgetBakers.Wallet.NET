namespace Wallet.Api.Net.Models.ResponseInfo
{
    public class DataSynchronizationInfo
    {
        /// <summary>
        /// Timestamp of the last data modification in UTC.
        /// </summary>
        public DateTime? LastDataChangeAt { get; set; }

        /// <summary>
        /// Revision value used to detect data changes between requests.
        /// </summary>
        public string? LastDataChangeRevision { get; set; }

        /// <summary>
        /// Indicates whether background synchronization is currently in progress.
        /// </summary>
        public bool? SyncInProgress { get; set; }
    }
}
