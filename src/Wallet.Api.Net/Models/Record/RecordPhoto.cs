using System;

namespace Wallet.Api.Net.Models.Record
{
    public class RecordPhoto
    {
        /// <summary>
        /// Timestamp when the photo was created.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Temporary signed URL of the photo (valid for limited time).
        /// </summary>
        public string? TemporaryUrl { get; set; }
    }
}
