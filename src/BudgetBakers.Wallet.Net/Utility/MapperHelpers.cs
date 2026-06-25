using System;
using System.Collections.Generic;
using System.Linq;
using BudgetBakers.Wallet.Net.Constants;
using BudgetBakers.Wallet.Net.Dtos.Account;
using BudgetBakers.Wallet.Net.Dtos;
using BudgetBakers.Wallet.Net.Dtos.Label;
using BudgetBakers.Wallet.Net.Dtos.Record;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Label;
using BudgetBakers.Wallet.Net.Models.Record;
using BudgetBakers.Wallet.Net.Models.StandingOrder;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal static class MapperHelpers
    {
        private static readonly Dictionary<string, AgentHintSeverity> _agentHintSeverityMap = new()
        {
            ["info"] = AgentHintSeverity.Info,
            ["warning"] = AgentHintSeverity.Warning,
            ["instruction"] = AgentHintSeverity.Instruction
        };

        private static readonly Dictionary<string, AgentHintType> _agentHintTypeMap = new()
        {
            ["pagination.has_more"] = AgentHintType.PaginationHasMore,
            ["result.partial_match"] = AgentHintType.ResultPartialMatch,
            ["result.empty"] = AgentHintType.ResultEmpty,
            ["param.inferred"] = AgentHintType.ParamInferred,
            ["rate_limit.warning"] = AgentHintType.RateLimitWarning,
            ["data.recency"] = AgentHintType.DataRecency
        };

        private static readonly Dictionary<string, PaymentType> _paymentTypeMap = new()
        {
            ["cash"] = PaymentType.Cash,
            ["debit_card"] = PaymentType.DebitCard,
            ["credit_card"] = PaymentType.CreditCard,
            ["transfer"] = PaymentType.Transfer,
            ["voucher"] = PaymentType.Voucher,
            ["mobile_payment"] = PaymentType.MobilePayment,
            ["web_payment"] = PaymentType.WebPayment
        };

        private static readonly Dictionary<string, RecordState> _recordStateMap = new()
        {
            ["reconciled"] = RecordState.Reconciled,
            ["cleared"] = RecordState.Cleared,
            ["uncleared"] = RecordState.Uncleared,
            ["void"] = RecordState.Void,
            ["waitForAssign"] = RecordState.WaitForAssign
        };

        private static readonly Dictionary<string, RecordType> _recordTypeMap = new()
        {
            ["income"] = RecordType.Income,
            ["expense"] = RecordType.Expense
        };

        private static readonly Dictionary<string, StandingOrderType> _standingOrderTypeMap = new()
        {
            ["income"] = StandingOrderType.Income,
            ["expense"] = StandingOrderType.Expense
        };

        public static AgentHint? MapAgentHint(AgentHintDto? dto)
        {
            if (dto is null)
                return null;

            return new AgentHint
            {
                Action = dto.Action is null ? null : new AgentAction { Url = dto.Action.Url },
                Data = dto.Data,
                Severity = ParseAgentHintSeverity(dto.Severity),
                Text = dto.Text,
                Type = ParseAgentHintType(dto.Type)
            };
        }

        public static AgentHintSeverity ParseAgentHintSeverity(string? value)
        {
            if (value is not null && _agentHintSeverityMap.TryGetValue(value, out AgentHintSeverity severity))
                return severity;

            throw new InvalidOperationException($"Unknown {nameof(AgentHintSeverity)} value: '{value}'");
        }

        public static AgentHintType ParseAgentHintType(string? value)
        {
            if (value is not null && _agentHintTypeMap.TryGetValue(value, out AgentHintType type))
                return type;

            throw new InvalidOperationException($"Unknown {nameof(AgentHintType)} value: '{value}'");
        }

        public static PaymentType? ParsePaymentType(string? value)
        {
            if (value is null)
                return null;

            if (_paymentTypeMap.TryGetValue(value, out PaymentType paymentType))
                return paymentType;

            throw new InvalidOperationException($"Unknown {nameof(PaymentType)} value: '{value}'");
        }

        public static RecordState? ParseRecordState(string? value)
        {
            if (value is null)
                return null;

            if (_recordStateMap.TryGetValue(value, out RecordState recordState))
                return recordState;

            throw new InvalidOperationException($"Unknown {nameof(RecordState)} value: '{value}'");
        }

        public static RecordType? ParseRecordType(string? value)
        {
            if (value is null)
                return null;

            if (_recordTypeMap.TryGetValue(value, out RecordType recordType))
                return recordType;

            throw new InvalidOperationException($"Unknown {nameof(RecordType)} value: '{value}'");
        }

        public static StandingOrderType? ParseStandingOrderType(string? value)
        {
            if (value is null)
                return null;

            if (_standingOrderTypeMap.TryGetValue(value, out StandingOrderType standingOrderType))
                return standingOrderType;

            throw new InvalidOperationException($"Unknown {nameof(StandingOrderType)} value: '{value}'");
        }

        public static DateTime? ParseDateTime(string? s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return null;

            if (DateTime.TryParse(s, out var dt))
                return dt;

            return null;
        }

        public static Balance? MapBalance(BalanceDto? dto)
        {
            if (dto is null)
                return null;

            return new Balance
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

        public static string? JoinIds(IEnumerable<string>? ids)
        {
            if (ids is null)
                return null;

            return ids.Any()
                ? string.Join(ApiConstant.Separator.Ids, ids)
                : null;
        }

        public static Label? MapLabel(LabelDto? dto)
        {
            if (dto is null)
                return null;

            var label = new Label
            {
                Archived = dto.Archived,
                Color = dto.Color,
                CreatedAt = ParseDateTime(dto.CreatedAt),
                Name = dto.Name,
                UpdatedAt = ParseDateTime(dto.UpdatedAt)
            };

            if (ParseGuid(dto.Id) is Guid id)
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
