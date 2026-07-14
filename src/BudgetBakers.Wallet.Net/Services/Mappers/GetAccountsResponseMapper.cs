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
                    NextOffset = source.NextOffset,
                    Total = source.Total
                },
                Accounts = source.Accounts
                            .Select(MapperHelpers.MapAccount)
                            .OfType<Account>()
                            .ToList(),
                AgentHints = source.AgentHints
                            .Select(MapperHelpers.MapAgentHint)
                            .OfType<AgentHint>()
                            .ToList()
            };

            return response;
        }
    }
}
