using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Dtos;
using Wallet.Api.Net.Models;
using Wallet.Api.Net.Models.Account;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Mappers
{
    public class GetAccountsResponseMapper : IMapper<GetAccountsResponseDto, GetAccountsResponse>
    {
        public GetAccountsResponse? Map(GetAccountsResponseDto? source)
        {
            if (source is null)
                return null;

            GetAccountsResponse response = new GetAccountsResponse()
            {
                Limit = source.Limit,
                Offset = source.Offset,
                NextOffset = source.NextOffset,
                Accounts = source.Accounts?.Select(MapAccount).ToList() ?? new List<Account>(),
                AgentHints = source.AgentHints?.Select(MapperHelpers.MapAgentHint).ToList() ?? new List<AgentHint>()
            };

            return response;
        }

        private static Account MapAccount(AccountDto? dto)
        {
            if (dto is null)
                return new Account();

            var account = new Account
            {
                AccountType = dto.AccountType is null ? null : Enum.Parse<AccountType>(dto.AccountType),
                Archived = dto.Archived,
                BankAccountNumber = dto.BankAccountNumber,
                Color = dto.Color,
                CreatedAt = MapperHelpers.ParseDateTime(dto.CreatedAt),
                ExcludeFromStats = dto.ExcludeFromStats,
                Name = dto.Name,
                InitialBalance = MapBalance(dto.InitialBalance),
                InitialBaseBalance = MapBalance(dto.InitialBaseBalance),
                RecordStats = MapRecordStats(dto.RecordStats),
                UpdatedAt = MapperHelpers.ParseDateTime(dto.UpdatedAt)
            };

            if (!string.IsNullOrWhiteSpace(dto.Id) && Guid.TryParse(dto.Id, out var guid))
                account.Id = guid;

            return account;
        }

        private static Balance? MapBalance(BalanceDto? dto)
        {
            if (dto is null)
                return null;

            return new Balance
            {
                CurrencyCode = dto.CurrencyCode,
                Value = dto.Value
            };
        }

        private static RecordStats? MapRecordStats(RecordStatsDto? dto)
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

        private static DateRange? MapDateRange(DateRangeDto? dto)
        {
            if (dto is null)
                return null;

            return new DateRange
            {
                Max = MapperHelpers.ParseDateTime(dto.Max),
                Min = MapperHelpers.ParseDateTime(dto.Min)
            };
        }

        
    }
}
