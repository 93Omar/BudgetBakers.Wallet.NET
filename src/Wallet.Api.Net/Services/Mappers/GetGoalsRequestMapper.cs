using Wallet.Api.Net.Dtos.Goal;
using Wallet.Api.Net.Models.Goal;

namespace Wallet.Api.Net.Services.Mappers
{
    public class GetGoalsRequestMapper : IMapper<GetGoalsRequest, GetGoalsRequestDto>
    {
        public GetGoalsRequestDto? Map(GetGoalsRequest? source)
        {
            if (source is null)
                return null;

            GetGoalsRequestDto dto = new GetGoalsRequestDto
            {
                Limit = source.Limit,
                Offset = source.Offset,
                AgentHints = source.AgentHints,
                Id = source.Ids.Any() ? string.Join(",", source.Ids) : null,
                Name = source.Name?.ToString(),
                Note = source.Note?.ToString(),
                CreatedAt = source.CreatedAt?.ToString(),
                UpdatedAt = source.UpdatedAt?.ToString()
            };

            return dto;
        }
    }
}
