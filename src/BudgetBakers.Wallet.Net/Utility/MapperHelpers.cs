using System;
using System.Collections.Generic;
using System.Linq;
using BudgetBakers.Wallet.Net.Constants;
using BudgetBakers.Wallet.Net.Dtos;
using BudgetBakers.Wallet.Net.Dtos.Account;
using BudgetBakers.Wallet.Net.Dtos.Budget;
using BudgetBakers.Wallet.Net.Dtos.Category;
using BudgetBakers.Wallet.Net.Dtos.Label;
using BudgetBakers.Wallet.Net.Dtos.Record;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Account;
using BudgetBakers.Wallet.Net.Models.Budget;
using BudgetBakers.Wallet.Net.Models.Category;
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

        private static readonly Dictionary<string, TransferType> _transferTypeMap = new()
        {
            ["paired"] = TransferType.Paired,
            ["unpaired"] = TransferType.Unpaired
        };

        private static readonly Dictionary<string, CategoryCardinality> _categoryCardinalityMap = new()
        {
            ["none"] = CategoryCardinality.None,
            ["must"] = CategoryCardinality.Must,
            ["need"] = CategoryCardinality.Need,
            ["want"] = CategoryCardinality.Want
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

        public static TransferType? ParseTransferType(string? value)
        {
            if (value is null)
                return null;

            if (_transferTypeMap.TryGetValue(value, out TransferType transferType))
                return transferType;

            throw new InvalidOperationException($"Unknown {nameof(TransferType)} value: '{value}'");
        }

        public static CategoryCardinality? ParseCategoryCardinality(string? value)
        {
            if (value is null)
                return null;

            if (_categoryCardinalityMap.TryGetValue(value, out CategoryCardinality cardinality))
                return cardinality;

            throw new InvalidOperationException($"Unknown {nameof(CategoryCardinality)} value: '{value}'");
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

        public static string? JoinIds(IEnumerable<string>? ids)
        {
            if (ids is null)
                return null;

            return ids.Any()
                ? string.Join(ApiConstant.Separator.Ids, ids)
                : null;
        }

        /// <summary>
        /// Joins range/text filter values (e.g. <see cref="DateFilter"/>, <see cref="NumberFilter"/>,
        /// <see cref="DateOnlyFilter"/>) into the comma-separated wire format accepted by the API, which
        /// supports up to 2 conditions combined with AND logic (e.g. a lower and an upper bound).
        /// </summary>
        public static string? JoinFilters<T>(IEnumerable<T>? filters) where T : notnull
        {
            if (filters is null)
                return null;

            string[] values = filters.Select(filter => filter.ToString()!).ToArray();

            return values.Length > 0
                ? string.Join(ApiConstant.Separator.Filters, values)
                : null;
        }

        public static Label? MapLabel(LabelDto? dto)
        {
            if (dto is null)
                return null;

            return new Label
            {
                Archived = dto.Archived,
                Color = dto.Color,
                CreatedAt = ParseDateTime(dto.CreatedAt),
                Id = dto.Id,
                Name = dto.Name,
                UpdatedAt = ParseDateTime(dto.UpdatedAt)
            };
        }

        public static Account? MapAccount(AccountDto? dto)
        {
            if (dto is null)
                return null;

            return new Account
            {
                AccountType = dto.AccountType is null ? null : Enum.Parse<AccountType>(dto.AccountType),
                Archived = dto.Archived,
                Balance = MapAccountBalance(dto.Balance),
                BankAccountNumber = dto.BankAccountNumber,
                Color = dto.Color,
                CreatedAt = ParseDateTime(dto.CreatedAt),
                CurrencyCode = dto.CurrencyCode,
                ExcludeFromStats = dto.ExcludeFromStats,
                Id = dto.Id,
                IsBankSync = dto.IsBankSync,
                IsInvestmentAccount = dto.IsInvestmentAccount,
                Name = dto.Name,
                RecordStats = MapRecordStats(dto.RecordStats),
                UpdatedAt = ParseDateTime(dto.UpdatedAt)
            };
        }

        public static AccountBalance? MapAccountBalance(AccountBalanceDto? dto)
        {
            if (dto is null)
                return null;

            return new AccountBalance
            {
                AvailableCredit = dto.AvailableCredit,
                BalanceDisplayOption = dto.BalanceDisplayOption,
                BalanceMode = dto.BalanceMode,
                BalanceModeFormula = dto.BalanceModeFormula,
                CreditBalance = dto.CreditBalance,
                CreditLimit = dto.CreditLimit,
                CurrencyCode = dto.CurrencyCode,
                CurrentBalance = dto.CurrentBalance,
                Error = dto.Error,
                Formula = dto.Formula,
                Initial = dto.Initial,
                RawCurrentBalance = dto.RawCurrentBalance
            };
        }

        public static Category? MapCategory(CategoryDto? dto)
        {
            if (dto is null)
                return null;

            return new Category
            {
                Archived = dto.Archived,
                Cardinality = ParseCategoryCardinality(dto.Cardinality),
                Color = dto.Color,
                CreatedAt = ParseDateTime(dto.CreatedAt),
                CustomCategory = dto.CustomCategory,
                CustomName = dto.CustomName,
                Enabled = dto.Enabled,
                Group = dto.Group is null ? null : new CategoryGroup { Id = dto.Group.Id, Name = dto.Group.Name },
                Id = dto.Id,
                Name = dto.Name,
                ParentId = dto.ParentId,
                SystemId = dto.SystemId,
                UpdatedAt = ParseDateTime(dto.UpdatedAt)
            };
        }

        public static Budget? MapBudget(BudgetDto? dto)
        {
            if (dto is null)
                return null;

            return new Budget
            {
                Limit = dto.Limit,
                Closed = dto.Closed,
                ClosedDate = dto.ClosedDate,
                CurrencyCode = dto.CurrencyCode,
                CreatedAt = ParseDateTime(dto.CreatedAt),
                EndDate = dto.EndDate,
                Id = dto.Id,
                Name = dto.Name,
                StartDate = dto.StartDate,
                Type = dto.Type,
                UpdatedAt = ParseDateTime(dto.UpdatedAt),
                AccountIds = dto.AccountIds?.ToList() ?? [],
                CategoryIds = dto.CategoryIds?.ToList() ?? [],
                LabelIds = dto.LabelIds?.ToList() ?? [],
                LimitOverrides = dto.LimitOverrides.Select(MapBudgetChangeEntry).OfType<BudgetChangeEntry>().ToList(),
                PastLimitOverrides = dto.PastLimitOverrides.Select(MapBudgetChangeEntry).OfType<BudgetChangeEntry>().ToList(),
                Spending = MapBudgetSpending(dto.Spending)
            };
        }

        public static Record? MapRecord(RecordDto? dto)
        {
            if (dto is null)
                return null;

            Record record = new()
            {
                AccountId = dto.AccountId,
                AccountIsBankSync = dto.AccountIsBankSync,
                AccountName = dto.AccountName,
                Amount = MapBalance(dto.Amount),
                Category = dto.Category is null ? null : new Category
                {
                    Id = dto.Category.Id,
                    Name = dto.Category.Name,
                    Color = dto.Category.Color
                },
                ConvertedAmount = dto.ConvertedAmount is null ? null : new ConvertedAmount
                {
                    ConversionPair = dto.ConvertedAmount.ConversionPair,
                    CurrencyCode = dto.ConvertedAmount.CurrencyCode,
                    Error = dto.ConvertedAmount.Error,
                    Ratio = dto.ConvertedAmount.Ratio,
                    Value = dto.ConvertedAmount.Value
                },
                CreatedAt = ParseDateTime(dto.CreatedAt),
                Id = dto.Id,
                Note = dto.Note,
                CounterParty = dto.CounterParty,
                Photos = dto.Photos.Select(MapRecordPhoto).OfType<RecordPhoto>().ToList(),
                Place = MapPlace(dto.Place),
                RecordDate = ParseDateTime(dto.RecordDate),
                RecordState = ParseRecordState(dto.RecordState),
                RecordType = ParseRecordType(dto.RecordType),
                Source = dto.Source,
                Transfer = MapTransferOutput(dto.Transfer),
                UpdatedAt = ParseDateTime(dto.UpdatedAt)
            };

            if (dto.Labels != null && dto.Labels.Any())
                record.Labels = dto.Labels.Select(MapLabel).OfType<Label>().ToList();

            return record;
        }

        public static TransferOutput? MapTransferOutput(TransferOutputDto? dto)
        {
            if (dto is null)
                return null;

            return new TransferOutput
            {
                Type = ParseTransferType(dto.Type),
                MirrorRecord = MapMirrorRecordEmbed(dto.MirrorRecord),
                TransferId = dto.TransferId
            };
        }

        public static MirrorRecordEmbed? MapMirrorRecordEmbed(MirrorRecordEmbedDto? dto)
        {
            if (dto is null)
                return null;

            return new MirrorRecordEmbed
            {
                AccountId = dto.AccountId,
                Amount = dto.Amount is null ? null : new AmountWithCurrency
                {
                    CurrencyCode = dto.Amount.CurrencyCode,
                    Value = dto.Amount.Value
                },
                CounterParty = dto.CounterParty,
                Id = dto.Id,
                Note = dto.Note
            };
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

        public static BatchOperationSummary MapBatchOperationSummary(BatchOperationSummaryDto? dto)
        {
            if (dto is null)
                return new BatchOperationSummary();

            return new BatchOperationSummary
            {
                Total = dto.Total,
                Succeeded = dto.Succeeded,
                ClientErrors = dto.ClientErrors,
                ServerErrors = dto.ServerErrors
            };
        }

        public static BudgetChangeEntry? MapBudgetChangeEntry(BudgetChangeEntryDto? dto)
        {
            if (dto is null)
                return null;

            return new BudgetChangeEntry
            {
                CreatedAt = ParseDateTime(dto.CreatedAt),
                Limit = dto.Limit,
                Period = dto.Period,
                PeriodStart = dto.PeriodStart
            };
        }

        public static ExcludedBreakdown? MapExcludedBreakdown(ExcludedBreakdownDto? dto)
        {
            if (dto is null)
                return null;

            return new ExcludedBreakdown
            {
                ArchivedAccounts = dto.ArchivedAccounts,
                Debts = dto.Debts,
                IncomeCategories = dto.IncomeCategories,
                Total = dto.Total,
                TotalAmountSum = dto.TotalAmountSum,
                Transfers = dto.Transfers,
                UnknownCategories = dto.UnknownCategories
            };
        }

        public static BudgetPeriodSpending? MapBudgetPeriodSpending(BudgetPeriodSpendingDto? dto)
        {
            if (dto is null)
                return null;

            return new BudgetPeriodSpending
            {
                ConvertedCurrencies = dto.ConvertedCurrencies?.ToList() ?? [],
                Error = dto.Error,
                Excluded = MapExcludedBreakdown(dto.Excluded),
                EffectiveLimit = dto.EffectiveLimit,
                Incomplete = dto.Incomplete,
                Limit = dto.Limit,
                Overspent = dto.Overspent,
                Period = dto.Period,
                PeriodEnd = dto.PeriodEnd,
                PeriodStart = dto.PeriodStart,
                Progress = dto.Progress,
                RecordCount = dto.RecordCount,
                Remaining = dto.Remaining,
                Spent = dto.Spent,
                TotalExpenses = dto.TotalExpenses,
                TotalIncomes = dto.TotalIncomes
            };
        }

        public static BudgetSpending? MapBudgetSpending(BudgetSpendingDto? dto)
        {
            if (dto is null)
                return null;

            return new BudgetSpending
            {
                ComputedAt = ParseDateTime(dto.ComputedAt),
                Current = MapBudgetPeriodSpending(dto.Current),
                Past = dto.Past.Select(MapBudgetPeriodSpending).OfType<BudgetPeriodSpending>().ToList()
            };
        }

        public static CreateRecordMirrorResult? MapCreateRecordMirrorResult(CreateRecordMirrorResultDto? dto)
        {
            if (dto is null)
                return null;

            return new CreateRecordMirrorResult
            {
                Id = dto.Id,
                Record = MapRecord(dto.Record)
            };
        }
    }
}
