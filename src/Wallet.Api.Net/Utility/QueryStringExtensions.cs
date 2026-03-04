using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace Wallet.Api.Net.Utility
{
    internal static class QueryStringExtensions
    {
        internal static string? ToQueryString<T>(this T dto)
        {
            if (dto is null)
                return null;

            var dictionary = new Dictionary<string, string>();

            MapProperties(dto, dictionary);

            return string.Join("&", dictionary.Select(kvp =>
                $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value ?? "")}"));
        }

        private static void MapProperties(object obj, Dictionary<string, string> dictionary)
        {
            foreach (PropertyInfo propInfo in obj.GetType().GetProperties())
            {
                object? value = propInfo.GetValue(obj);

                string name = propInfo.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name
                         ?? propInfo.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName
                         ?? propInfo.Name;

                if (value is null)
                    continue;

                if (value.GetType().IsClass && value.GetType() != typeof(string))
                    MapProperties(value, dictionary);
                else
                    dictionary[name] = value.ToString()!;
            }
        }
    }
}
