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

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            MapProperties(dto, dictionary);

            return string.Join("&", dictionary.Select(kvp =>
                $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"));
        }

        private static void MapProperties(object obj, Dictionary<string, string> dictionary)
        {
            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
            {
                object? value = propertyInfo.GetValue(obj);
                if (value is null)
                    continue;

                if (IsNestedObject(value))
                {
                    MapProperties(value, dictionary);
                    continue;
                }

                string propertyName = GetPropertyName(propertyInfo);
                string? stringValue = ConvertToStringValue(value);
                if (stringValue is not null)
                    dictionary[propertyName] = stringValue;
            }
        }

        private static string GetPropertyName(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name
                ?? propertyInfo.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName
                ?? propertyInfo.Name;
        }

        private static bool IsNestedObject(object value)
        {
            Type type = value.GetType();
            return type.IsClass && type != typeof(string);
        }

        private static string? ConvertToStringValue(object value)
        {
            if (value is bool boolValue)
                return boolValue.ToString().ToLower();

            return value.ToString();
        }
    }
}
