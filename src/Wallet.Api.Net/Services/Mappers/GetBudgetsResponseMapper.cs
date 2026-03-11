using System;
using System.Collections.Generic;
using System.Linq;
using Wallet.Api.Net.Dtos.Budget;
using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Models.Budget;
using Wallet.Api.Net.Models.Label;
using Wallet.Api.Net.Utility;
using Wallet.Api.Net.Models;

namespace Wallet.Api.Net.Services.Mappers
{
    internal class GetBudgetsResponseMapper : IMapper<GetBudgetsResponseDto, GetBudgetsResponse>
    {
        public GetBudgetsResponse? Map(GetBudgetsResponseDto? source)
        {
            if (source is null)
                return null;

            GetBudgetsResponse response = new GetBudgetsResponse()
            {
                Limit = source.Limit,
                Offset = source.Offset,
                NextOffset = source.NextOffset,
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

            var budget = new Budget
            {
                Amount = dto.Amount,
                CurrencyCode = dto.CurrencyCode,
                CreatedAt = MapperHelpers.ParseDateTime(dto.CreatedAt),
                EndDate = dto.EndDate,
                Name = dto.Name,
                StartDate = dto.StartDate,
                Type = dto.Type,
                UpdatedAt = MapperHelpers.ParseDateTime(dto.UpdatedAt),
                Labels = dto.Labels
                            .Select(MapperHelpers.MapLabel)
                            .OfType<Label>()
                            .ToList()
            };

            if (dto.AccountIds != null && dto.AccountIds.Any())
            {
                var guids = new List<Guid>();
                foreach (var s in dto.AccountIds)
                {
                    if (Guid.TryParse(s, out var g))
                        guids.Add(g);
                }

                budget.AccountIds = guids;
            }

            if (dto.CategoryIds != null && dto.CategoryIds.Any())
            {
                var guids = new List<Guid>();
                foreach (var s in dto.CategoryIds)
                {
                    if (Guid.TryParse(s, out var g))
                        guids.Add(g);
                }

                budget.CategoryIds = guids;
            }

            if (!string.IsNullOrWhiteSpace(dto.Id) && Guid.TryParse(dto.Id, out var id))
                budget.Id = id;

            return budget;
        }  
    }
}

