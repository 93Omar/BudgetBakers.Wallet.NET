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
                    NextOffset = source.NextOffset
                },
                Budgets = source.Budgets
                                .Select(MapBudget)
                                .OfType<Budget>()
                                .ToList(),
                AgentHints = source.AgentHints
                                .Select(h => MapperHelpers.MapAgentHint(h))
                                .OfType<AgentHint>()
                                .ToList()
            };

            return response;
        }

        private static Budget? MapBudget(BudgetDto? dto)
        {
            if (dto is null)
                return null;

            Budget budget = new Budget
            {
                Amount = dto.Amount,
                CurrencyCode = dto.CurrencyCode,
                CreatedAt = MapperHelpers.ParseDateTime(dto.CreatedAt),
                EndDate = dto.EndDate,
                Name = dto.Name,
                StartDate = dto.StartDate,
                Type = dto.Type,
                UpdatedAt = MapperHelpers.ParseDateTime(dto.UpdatedAt),
                LabelIds = MapGuidList(dto.LabelIds)
            };

            budget.AccountIds = MapGuidList(dto.AccountIds);
            budget.CategoryIds = MapGuidList(dto.CategoryIds);

            Guid? budgetId = MapperHelpers.ParseGuid(dto.Id);
            if (budgetId.HasValue)
                budget.Id = budgetId.Value;

            return budget;
        }

        private static List<Guid> MapGuidList(IList<string> ids)
        {
            if (!ids.Any())
                return [];

            List<Guid> guids = new List<Guid>();

            foreach (string id in ids)
            {
                Guid? parsedId = MapperHelpers.ParseGuid(id);

                if (parsedId.HasValue)
                    guids.Add(parsedId.Value);
            }

            return guids;
        }
    }
}

