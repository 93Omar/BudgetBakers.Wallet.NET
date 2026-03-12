using Wallet.Api.Net.Dtos.Category;
using Wallet.Api.Net.Models.Category;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Mappers
{
    internal class GetCategoriesRequestMapper : IMapper<GetCategoriesRequest, GetCategoriesRequestDto>
    {
        public GetCategoriesRequestDto? Map(GetCategoriesRequest? source)
        {
            if (source is null)
                return null;

            GetCategoriesRequestDto requestDto = new GetCategoriesRequestDto()
            {
                Limit = source.Limit,
                Offset = source.Offset,
                AgentHints = source.AgentHints,
                Id = MapperHelpers.JoinIds(source.Ids),
                Name = source.Name?.ToString(),
                CreatedAt = source.CreatedAt?.ToString(),
                UpdatedAt = source.UpdatedAt?.ToString()
            };

            return requestDto;
        }
    }
}

