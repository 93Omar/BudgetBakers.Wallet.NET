using System;
using System.Collections.Generic;
using System.Linq;
using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Dtos;
using Wallet.Api.Net.Dtos.Label;
using Wallet.Api.Net.Dtos.Record;
using Wallet.Api.Net.Models;
using Wallet.Api.Net.Models.Label;
using Wallet.Api.Net.Models.Record;

namespace Wallet.Api.Net.Utility
{
    internal static class MapperHelpers
    {
        public static AgentHint? MapAgentHint(AgentHintDto? dto)
        {
            if (dto is null)
                return null;

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

        public static Wallet.Api.Net.Models.Balance? MapBalance(BalanceDto? dto)
        {
            if (dto is null)
                return null;

            return new Wallet.Api.Net.Models.Balance
            {
                CurrencyCode = dto.CurrencyCode,
                Value = dto.Value
            };
        }

        public static Guid? ParseGuid(string? s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return null;

            if (Guid.TryParse(s, out var g))
                return g;

            return null;
        }

        public static Wallet.Api.Net.Models.Label.Label? MapLabel(Wallet.Api.Net.Dtos.Label.LabelDto? dto)
        {
            if (dto is null)
                return null;

            var label = new Wallet.Api.Net.Models.Label.Label
            {
                Archived = dto.Archived,
                Color = dto.Color,
                CreatedAt = ParseDateTime(dto.CreatedAt),
                Name = dto.Name,
                UpdatedAt = ParseDateTime(dto.UpdatedAt)
            };

            if (!string.IsNullOrWhiteSpace(dto.Id) && Guid.TryParse(dto.Id, out var id))
                label.Id = id;

            return label;
        }

        public static RecordPhoto? MapRecordPhoto(PhotoDto? dto)
        {
            if (dto is null)
                return null;

            return new RecordPhoto
            {
                CreatedAt = ParseDateTime(dto.CreatedAt),
                TemporaryUrl = dto.TemporaryUrl
            };
        }

        public static RecordPlace? MapPlace(PlaceDto? dto)
        {
            if (dto is null)
                return null;

            return new RecordPlace
            {
                Address = dto.Address,
                Id = dto.Id,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                Name = dto.Name,
                PlaceTypes = dto.PlaceTypes?.ToList() ?? []
            };
        }

        public static DateRange? MapDateRange(DateRangeDto? dto)
        {
            if (dto is null)
                return null;

            return new DateRange
            {
                Max = ParseDateTime(dto.Max),
                Min = ParseDateTime(dto.Min)
            };
        }

        public static RecordStats? MapRecordStats(RecordStatsDto? dto)
        {
            if (dto is null)
                return null;

            return new RecordStats
            {
                CreatedAt = MapDateRange(dto.CreatedAt),
                RecordCount = dto.RecordCount,
                RecordDate = MapDateRange(dto.RecordDate)
            };
        }
    }
}
