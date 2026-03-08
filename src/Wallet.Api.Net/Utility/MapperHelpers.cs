using System;
using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Models.Account;

namespace Wallet.Api.Net.Utility
{
    internal static class MapperHelpers
    {
        public static AgentHint MapAgentHint(AgentHintDto? dto)
        {
            if (dto is null)
                return new AgentHint();

            return new AgentHint
            {
                Action = dto.Action is null ? null : new AgentAction { Url = dto.Action.Url },
                Data = dto.Data,
                Severity = dto.Severity,
                Text = dto.Text,
                Type = dto.Type
            };
        }

        public static DateTime? ParseDateTime(string? s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return null;

            if (DateTime.TryParse(s, out var dt))
                return dt;

            return null;
        }
    }
}
