using BudgetBakers.Wallet.Net.Dtos.Goal;
using BudgetBakers.Wallet.Net.Models.Goal;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
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
                WithTotal = source.WithTotal,
                Id = MapperHelpers.JoinIds(source.Ids),
                Name = source.Name?.ToString(),
                Note = source.Note?.ToString(),
                CreatedAt = MapperHelpers.JoinFilters(source.CreatedAt),
                UpdatedAt = MapperHelpers.JoinFilters(source.UpdatedAt)
            };

            return requestDto;
        }
    }
}

