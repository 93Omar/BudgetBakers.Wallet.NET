using Wallet.Api.Net.Dtos.Goal;
using Wallet.Api.Net.Models.Goal;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Mappers
{
    internal class GetGoalsRequestMapper : IMapper<GetGoalsRequest, GetGoalsRequestDto>
    {
        public GetGoalsRequestDto? Map(GetGoalsRequest? source)
        {
            if (source is null)
                return null;

            GetGoalsRequestDto requestDto = new GetGoalsRequestDto()
            {
                Limit = source.Limit,
                Offset = source.Offset,
                AgentHints = source.AgentHints,
                Id = MapperHelpers.JoinIds(source.Ids),
                Name = source.Name?.ToString(),
                Note = source.Note?.ToString(),
                CreatedAt = source.CreatedAt?.ToString(),
                UpdatedAt = source.UpdatedAt?.ToString()
            };

            return requestDto;
        }
    }
}

