using System;
using System.Collections.Generic;
using System.Linq;
using BudgetBakers.Wallet.Net.Dtos.StandingOrder;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Label;
using BudgetBakers.Wallet.Net.Models.StandingOrder;
using BudgetBakers.Wallet.Net.Models.Pagination;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetStandingOrdersResponseMapper : IMapper<GetStandingOrdersResponseDto, GetStandingOrdersResponse>
    {
        public GetStandingOrdersResponse? Map(GetStandingOrdersResponseDto? source)
        {
            if (source is null)
                return null;

            GetStandingOrdersResponse response = new GetStandingOrdersResponse()
            {
                Pagination = new PaginationInfo
                {
                    Limit = source.Limit,
                    Offset = source.Offset,
                    NextOffset = source.NextOffset
                },
                StandingOrders = source.StandingOrders
                                    .Select(MapStandingOrder)
                                    .OfType<StandingOrder>()
                                    .ToList(),
                AgentHints = source.AgentHints
                                    .Select(MapperHelpers.MapAgentHint)
                                    .OfType<AgentHint>()
                                    .ToList()
            };

            return response;
        }

        private static StandingOrder? MapStandingOrder(StandingOrderDto? dto)
        {
            if (dto is null)
                return null;

            var so = new StandingOrder
            {
                AccountId = dto.AccountId,
                Amount = dto.Amount,
                CategoryId = MapperHelpers.ParseGuid(dto.CategoryId),
                CreatedAt = MapperHelpers.ParseDateTime(dto.CreatedAt),
                CurrencyCode = dto.CurrencyCode,
                GenerateFromDate = dto.GenerateFromDate,
                ManualPayment = dto.ManualPayment,
                Name = dto.Name,
                Note = dto.Note,
                CounterParty = dto.CounterParty,
                PaymentType = dto.PaymentType,
                RecurrenceRule = dto.RecurrenceRule,
                Type = MapperHelpers.ParseStandingOrderType(dto.Type),
                UpdatedAt = MapperHelpers.ParseDateTime(dto.UpdatedAt),
                Labels = dto.Labels
                            .Select(MapperHelpers.MapLabel)
                            .OfType<Label>()
                            .ToList()
            };

            if (MapperHelpers.ParseGuid(dto.Id) is Guid id)
                so.Id = id;

            return so;
        }       
    }
}

