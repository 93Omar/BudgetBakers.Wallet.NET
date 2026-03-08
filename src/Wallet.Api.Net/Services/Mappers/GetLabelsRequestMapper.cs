using Wallet.Api.Net.Dtos.Label;
using Wallet.Api.Net.Models.Label;

namespace Wallet.Api.Net.Services.Mappers
{
    public class GetLabelsRequestMapper : IMapper<GetLabelsRequest, GetLabelsRequestDto>
    {
        public GetLabelsRequestDto? Map(GetLabelsRequest? source)
        {
            if (source is null)
                return null;

            GetLabelsRequestDto dto = new GetLabelsRequestDto
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
