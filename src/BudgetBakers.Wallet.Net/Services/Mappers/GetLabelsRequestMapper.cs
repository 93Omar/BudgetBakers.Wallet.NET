using BudgetBakers.Wallet.Net.Dtos.Label;
using BudgetBakers.Wallet.Net.Models.Label;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
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
                WithTotal = source.WithTotal,
                Id = MapperHelpers.JoinIds(source.Ids),
                Name = source.Name?.ToString(),
                CreatedAt = source.CreatedAt?.ToString(),
                UpdatedAt = source.UpdatedAt?.ToString(),
                Archived = source.Archived,
                RecordId = source.RecordId,
                BudgetId = source.BudgetId,
                StandingOrderId = source.StandingOrderId,
                RecordRuleId = source.RecordRuleId,
                SortBy = source.SortBy?.ToApiString()
            };

            return requestDto;
        }
    }
}

