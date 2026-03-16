namespace Wallet.Api.Net.Models.Record
{
    public enum RecordState
    {
        Reconciled = 0,
        Cleared = 1,
        Uncleared = 2,
        Void = 3,
        WaitForAssign = 4
    }
}
