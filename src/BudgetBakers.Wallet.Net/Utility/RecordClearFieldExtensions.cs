using System;
using BudgetBakers.Wallet.Net.Models.Record;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal static class RecordClearFieldExtensions
    {
        internal static string ToApiString(this RecordClearField value) => value switch
        {
            RecordClearField.CategoryId => "categoryId",
            RecordClearField.LabelIds => "labelIds",
            RecordClearField.Note => "note",
            RecordClearField.CounterParty => "counterParty",
            RecordClearField.Place => "place",
            _ => throw new InvalidOperationException($"Unsupported {nameof(RecordClearField)} value: {value}")
        };
    }
}
