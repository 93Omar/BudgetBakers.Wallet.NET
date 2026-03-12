using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Api.Net.Dtos.Budget;
using Wallet.Api.Net.Models.Budget;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Mappers
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

