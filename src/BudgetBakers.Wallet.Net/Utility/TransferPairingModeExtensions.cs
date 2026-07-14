using System;
using BudgetBakers.Wallet.Net.Models.Record;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal static class TransferPairingModeExtensions
    {
        internal static string ToApiString(this TransferPairingMode value) => value switch
        {
            TransferPairingMode.New => "new",
            TransferPairingMode.Existing => "existing",
            TransferPairingMode.Unpaired => "unpaired",
            _ => throw new InvalidOperationException($"Unsupported {nameof(TransferPairingMode)} value: {value}")
        };
    }
}
