using Wallet.Api.Net.Dtos.StandingOrder;
using Wallet.Api.Net.Models.StandingOrder;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Mappers
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

