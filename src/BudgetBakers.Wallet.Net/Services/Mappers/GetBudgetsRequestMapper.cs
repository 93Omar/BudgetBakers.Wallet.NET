using System;
using System.Collections.Generic;
using System.Text;
using BudgetBakers.Wallet.Net.Dtos.Budget;
using BudgetBakers.Wallet.Net.Models.Budget;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetBudgetsRequestMapper : IMapper<GetBudgetsRequest, GetBudgetsRequestDto>
    {
        public GetBudgetsRequestDto? Map(GetBudgetsRequest? source)
        {
            if (source is null)
                return null;

            GetBudgetsRequestDto requestDto = new GetBudgetsRequestDto()
            {
                Limit = source.Limit,
                Offset = source.Offset,
                AgentHints = source.AgentHints,
                Id = MapperHelpers.JoinIds(source.Ids),
                Name = source.Name?.ToString(),
                CurrencyCode = source.CurrencyCode,
                CreatedAt = source.CreatedAt?.ToString(),
                UpdatedAt = source.UpdatedAt?.ToString()
            };

            return requestDto;
        }
    }
}

