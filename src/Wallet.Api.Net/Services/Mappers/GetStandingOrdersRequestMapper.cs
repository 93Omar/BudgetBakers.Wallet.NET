using Wallet.Api.Net.Dtos.StandingOrder;
using Wallet.Api.Net.Models.StandingOrder;

namespace Wallet.Api.Net.Services.Mappers
{
    public class GetStandingOrdersRequestMapper : IMapper<GetStandingOrdersRequest, GetStandingOrdersRequestDto>
    {
        public GetStandingOrdersRequestDto? Map(GetStandingOrdersRequest? source)
        {
            if (source is null)
                return null;

            GetStandingOrdersRequestDto dto = new GetStandingOrdersRequestDto
            {
                Limit = source.Limit,
                Offset = source.Offset,
                AgentHints = source.AgentHints,
                Id = source.Ids.Any() ? string.Join(",", source.Ids) : null,
                Name = source.Name,
                CurrencyCode = source.CurrencyCode,
                CreatedAt = source.CreatedAt?.ToString(),
                UpdatedAt = source.UpdatedAt?.ToString()
            };

            return dto;
        }
    }
}
