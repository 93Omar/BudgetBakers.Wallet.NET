using System;
using BudgetBakers.Wallet.Net.Models.Record;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal static class PaymentTypeExtensions
    {
        internal static string ToApiString(this PaymentType value) => value switch
        {
            PaymentType.Cash => "cash",
            PaymentType.DebitCard => "debit_card",
            PaymentType.CreditCard => "credit_card",
            PaymentType.Transfer => "transfer",
            PaymentType.Voucher => "voucher",
            PaymentType.MobilePayment => "mobile_payment",
            PaymentType.WebPayment => "web_payment",
            _ => throw new InvalidOperationException($"Unsupported {nameof(PaymentType)} value: {value}")
        };
    }
}
