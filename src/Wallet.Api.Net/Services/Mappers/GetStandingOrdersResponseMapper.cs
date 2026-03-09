using System;
using System.Collections.Generic;
using System.Linq;
using Wallet.Api.Net.Dtos.StandingOrder;
using Wallet.Api.Net.Models;
using Wallet.Api.Net.Models.Label;
using Wallet.Api.Net.Models.StandingOrder;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Mappers
{
    public class GetStandingOrdersResponseMapper : IMapper<GetStandingOrdersResponseDto, GetStandingOrdersResponse>
    {
        public GetStandingOrdersResponse? Map(GetStandingOrdersResponseDto? source)
        {
            if (source is null)
                return null;

            GetStandingOrdersResponse response = new GetStandingOrdersResponse()
            {
                Limit = source.Limit,
                Offset = source.Offset,
                NextOffset = source.NextOffset,
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
                Payee = dto.Payee,
                Payer = dto.Payer,
                PaymentType = dto.PaymentType,
                RecurrenceRule = dto.RecurrenceRule,
                Type = dto.Type,
                UpdatedAt = MapperHelpers.ParseDateTime(dto.UpdatedAt),
                Labels = dto.Labels
                            .Select(MapperHelpers.MapLabel)
                            .OfType<Label>()
                            .ToList()
            };

            if (!string.IsNullOrWhiteSpace(dto.Id) && Guid.TryParse(dto.Id, out var id))
                so.Id = id;

            return so;
        }       
    }
}
