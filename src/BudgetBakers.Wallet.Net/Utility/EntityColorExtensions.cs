using System;
using BudgetBakers.Wallet.Net.Models;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal static class EntityColorExtensions
    {
        internal static string ToApiString(this EntityColor value) => value switch
        {
            EntityColor.Blue => "Blue",
            EntityColor.Charcoal => "Charcoal",
            EntityColor.CoffeeBrown => "CoffeeBrown",
            EntityColor.DarkPurple => "DarkPurple",
            EntityColor.Green => "Green",
            EntityColor.LightBlue => "LightBlue",
            EntityColor.Lime => "Lime",
            EntityColor.Orange => "Orange",
            EntityColor.PineGreen => "PineGreen",
            EntityColor.Pink => "Pink",
            EntityColor.Purple => "Purple",
            EntityColor.Red => "Red",
            EntityColor.Stone => "Stone",
            EntityColor.Turquoise => "Turquoise",
            EntityColor.Wine => "Wine",
            EntityColor.Yellow => "Yellow",
            _ => throw new InvalidOperationException($"Unsupported {nameof(EntityColor)} value: {value}")
        };
    }
}
