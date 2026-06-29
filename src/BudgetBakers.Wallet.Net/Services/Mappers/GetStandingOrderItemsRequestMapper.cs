using BudgetBakers.Wallet.Net.Dtos.StandingOrder;
using BudgetBakers.Wallet.Net.Models.StandingOrder;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetStandingOrderItemsRequestMapper : IMapper<GetStandingOrderItemsRequest, GetStandingOrderItemsRequestDto>
    {
        public GetStandingOrderItemsRequestDto? Map(GetStandingOrderItemsRequest? source)
        {
            if (source is null)
                return null;

            return new GetStandingOrderItemsRequestDto
            {
                Limit = source.Limit,
                Offset = source.Offset,
                AgentHints = source.AgentHints,
                WithTotal = source.WithTotal,
                StandingOrderId = source.StandingOrderId,
                OriginalDate = source.OriginalDate?.ToString(),
                Dismissed = source.Dismissed,
                RecordId = source.RecordId,
                PaidDate = source.PaidDate?.ToString()
            };
        }
    }
}
