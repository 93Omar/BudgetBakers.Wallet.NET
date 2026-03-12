using Wallet.Api.Net.Dtos.Label;
using Wallet.Api.Net.Models.Label;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Mappers
{
    internal class GetLabelsRequestMapper : IMapper<GetLabelsRequest, GetLabelsRequestDto>
    {
        public GetLabelsRequestDto? Map(GetLabelsRequest? source)
        {
            if (source is null)
                return null;

            GetLabelsRequestDto requestDto = new GetLabelsRequestDto()
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

