using BudgetBakers.Wallet.Net.Dtos.StandingOrder;
using BudgetBakers.Wallet.Net.Models.StandingOrder;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetStandingOrdersRequestMapper : IMapper<GetStandingOrdersRequest, GetStandingOrdersRequestDto>
    {
        public GetStandingOrdersRequestDto? Map(GetStandingOrdersRequest? source)
        {
            if (source is null)
                return null;

            GetStandingOrdersRequestDto requestDto = new()
            {
                Limit = source.Limit,
                Offset = source.Offset,
                AgentHints = source.AgentHints,
                WithTotal = source.WithTotal,
                Id = MapperHelpers.JoinIds(source.Ids),
                Name = source.Name?.ToString(),
                CurrencyCode = source.CurrencyCode,
                CreatedAt = MapperHelpers.JoinFilters(source.CreatedAt),
                UpdatedAt = MapperHelpers.JoinFilters(source.UpdatedAt),
                LabelId = source.LabelId
            };

            return requestDto;
        }
    }
}
