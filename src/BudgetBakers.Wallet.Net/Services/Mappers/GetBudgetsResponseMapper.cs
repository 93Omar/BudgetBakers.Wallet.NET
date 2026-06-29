using System;
using System.Collections.Generic;
using System.Linq;
using BudgetBakers.Wallet.Net.Dtos.Budget;
using BudgetBakers.Wallet.Net.Models.Budget;
using BudgetBakers.Wallet.Net.Utility;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Pagination;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetBudgetsResponseMapper : IMapper<GetBudgetsResponseDto, GetBudgetsResponse>
    {
        public GetBudgetsResponse? Map(GetBudgetsResponseDto? source)
        {
            if (source is null)
                return null;

            GetBudgetsResponse response = new GetBudgetsResponse()
            {
                Pagination = new PaginationInfo
                {
                    Limit = source.Limit,
                    Offset = source.Offset,
                    NextOffset = source.NextOffset,
                    Total = source.Total
                },
                Budgets = source.Budgets
                                .Select(MapperHelpers.MapBudget)
                                .OfType<Budget>()
                                .ToList(),
                AgentHints = source.AgentHints
                                .Select(h => MapperHelpers.MapAgentHint(h))
                                .OfType<AgentHint>()
                                .ToList()
            };

            return response;
        }
    }
}
