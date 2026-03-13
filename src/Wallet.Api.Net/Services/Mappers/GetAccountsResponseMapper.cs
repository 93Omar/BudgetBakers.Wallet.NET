using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Dtos;
using Wallet.Api.Net.Models;
using Wallet.Api.Net.Models.Account;
using Wallet.Api.Net.Models.Pagination;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Mappers
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

