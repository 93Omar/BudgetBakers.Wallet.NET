using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BudgetBakers.Wallet.Net.Dtos.Account;
using BudgetBakers.Wallet.Net.Dtos;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Account;
using BudgetBakers.Wallet.Net.Models.Pagination;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetAccountsResponseMapper : IMapper<GetAccountsResponseDto, GetAccountsResponse>
    {
        public GetAccountsResponse? Map(GetAccountsResponseDto? source)
        {
            if (source is null)
                return null;

            GetAccountsResponse response = new GetAccountsResponse()
            {
                Pagination = new PaginationInfo
                {
                    Limit = source.Limit,
                    Offset = source.Offset,
                    NextOffset = source.NextOffset
                },
                Accounts = source.Accounts
                            .Select(MapAccount)
                            .OfType<Account>()
                            .ToList(),
                AgentHints = source.AgentHints
                            .Select(MapperHelpers.MapAgentHint)
                            .OfType<AgentHint>()
                            .ToList()
            };

            return response;
        }

        private static Account? MapAccount(AccountDto? dto)
        {
            if (dto is null)
                return null;

            var account = new Account
            {
                AccountType = dto.AccountType is null ? null : Enum.Parse<AccountType>(dto.AccountType),
                Archived = dto.Archived,
                BankAccountNumber = dto.BankAccountNumber,
                Color = dto.Color,
                CreatedAt = MapperHelpers.ParseDateTime(dto.CreatedAt),
                ExcludeFromStats = dto.ExcludeFromStats,
                Name = dto.Name,
                InitialBalance = MapperHelpers.MapBalance(dto.InitialBalance),
                InitialBaseBalance = MapperHelpers.MapBalance(dto.InitialBaseBalance),
                RecordStats = MapperHelpers.MapRecordStats(dto.RecordStats),
                UpdatedAt = MapperHelpers.ParseDateTime(dto.UpdatedAt)
            };

            if (MapperHelpers.ParseGuid(dto.Id) is Guid guid)
                account.Id = guid;

            return account;
        }      
    }
}

