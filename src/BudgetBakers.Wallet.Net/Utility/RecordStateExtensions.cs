using System;
using BudgetBakers.Wallet.Net.Models.Record;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal static class RecordStateExtensions
    {
        internal static string ToApiString(this RecordState value) => value switch
        {
            RecordState.Reconciled => "reconciled",
            RecordState.Cleared => "cleared",
            RecordState.Uncleared => "uncleared",
            RecordState.Void => "void",
            RecordState.WaitForAssign => "waitForAssign",
            _ => throw new InvalidOperationException($"Unsupported {nameof(RecordState)} value: {value}")
        };
    }
}
