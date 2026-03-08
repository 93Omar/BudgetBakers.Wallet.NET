using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Api.Net.Dtos.Budget;
using Wallet.Api.Net.Models.Budget;

namespace Wallet.Api.Net.Services.Mappers
{
    public class GetBudgetsRequestMapper : IMapper<GetBudgetsRequest, GetBudgetsRequestDto>
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
                Id = source.Ids != null && source.Ids.Count > 0 ? string.Join(",", source.Ids) : null,
                Name = source.Name?.ToString(),
                CurrencyCode = source.CurrencyCode,
                CreatedAt = source.CreatedAt?.ToString(),
                UpdatedAt = source.UpdatedAt?.ToString()
            };

            return requestDto;
        }
    }
}
