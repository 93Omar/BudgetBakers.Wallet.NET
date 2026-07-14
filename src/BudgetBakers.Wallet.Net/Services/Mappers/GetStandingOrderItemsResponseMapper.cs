using System.Linq;
using BudgetBakers.Wallet.Net.Dtos.StandingOrder;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Pagination;
using BudgetBakers.Wallet.Net.Models.StandingOrder;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetStandingOrderItemsResponseMapper : IMapper<GetStandingOrderItemsResponseDto, GetStandingOrderItemsResponse>
    {
        public GetStandingOrderItemsResponse? Map(GetStandingOrderItemsResponseDto? source)
        {
            if (source is null)
                return null;

            return new GetStandingOrderItemsResponse
            {
                Pagination = new PaginationInfo
                {
                    Limit = source.Limit,
                    Offset = source.Offset,
                    NextOffset = source.NextOffset,
                    Total = source.Total
                },
                StandingOrderItems = source.StandingOrderItems
                    .Select(MapItem)
                    .OfType<StandingOrderItem>()
                    .ToList(),
                AgentHints = source.AgentHints
                    .Select(MapperHelpers.MapAgentHint)
                    .OfType<AgentHint>()
                    .ToList()
            };
        }

        private static StandingOrderItem? MapItem(StandingOrderItemDto? dto)
        {
            if (dto is null)
                return null;

            return new StandingOrderItem
            {
                Id = dto.Id,
                StandingOrderId = dto.StandingOrderId,
                AlignedDate = MapperHelpers.ParseDateTime(dto.AlignedDate),
                Dismissed = dto.Dismissed,
                OriginalDate = MapperHelpers.ParseDateTime(dto.OriginalDate),
                PaidDate = MapperHelpers.ParseDateTime(dto.PaidDate),
                PaidFromAppDate = MapperHelpers.ParseDateTime(dto.PaidFromAppDate),
                RecordIds = dto.RecordIds.ToList()
            };
        }
    }
}
