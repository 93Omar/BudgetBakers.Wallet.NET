using BudgetBakers.Wallet.Net.Dtos.StandingOrder;
using BudgetBakers.Wallet.Net.Models.StandingOrder;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetStandingOrdersRequestMapper : IMapper<GetStandingOrdersRequest, GetStandingOrdersRequestDto>
    {
        public GetStandingOrdersRequestDto? Map(GetStandingOrdersRequest? source)
        {
            if (source is null)
                return null;

            GetStandingOrdersRequestDto requestDto = new GetStandingOrdersRequestDto()
            {
                Limit = source.Limit,
                Offset = source.Offset,
                AgentHints = source.AgentHints,
                Id = MapperHelpers.JoinIds(source.Ids),
                Name = source.Name,
                CurrencyCode = source.CurrencyCode,
                CreatedAt = source.CreatedAt?.ToString(),
                UpdatedAt = source.UpdatedAt?.ToString()
            };

            return requestDto;
        }
    }
}

