using Wallet.Api.Net.Dtos.Category;
using Wallet.Api.Net.Models.Category;

namespace Wallet.Api.Net.Services.Mappers
{
    public class GetCategoriesRequestMapper : IMapper<GetCategoriesRequest, GetCategoriesRequestDto>
    {
        public GetCategoriesRequestDto? Map(GetCategoriesRequest? source)
        {
            if (source is null)
                return null;

            GetCategoriesRequestDto dto = new GetCategoriesRequestDto
            {
                Limit = source.Limit,
                Offset = source.Offset,
                AgentHints = source.AgentHints,
                Id = source.Ids != null && source.Ids.Count > 0 ? string.Join(",", source.Ids) : null,
                Name = source.Name?.ToString(),
                CreatedAt = source.CreatedAt?.ToString(),
                UpdatedAt = source.UpdatedAt?.ToString()
            };

            return dto;
        }
    }
}
