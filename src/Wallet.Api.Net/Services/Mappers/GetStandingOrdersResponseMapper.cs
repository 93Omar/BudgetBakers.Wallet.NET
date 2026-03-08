using System;
using System.Collections.Generic;
using System.Linq;
using Wallet.Api.Net.Dtos.StandingOrder;
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
                StandingOrders = source.StandingOrders?.Select(MapStandingOrder).ToList() ?? new List<StandingOrder>(),
                AgentHints = source.AgentHints?.Select(MapperHelpers.MapAgentHint).ToList() ?? new List<Models.Account.AgentHint>()
            };

            return response;
        }

        private static StandingOrder MapStandingOrder(StandingOrderDto? dto)
        {
            if (dto is null)
                return new StandingOrder();

            var so = new StandingOrder
            {
                AccountId = dto.AccountId,
                Amount = dto.Amount,
                CategoryId = ParseGuid(dto.CategoryId),
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
                Labels = dto.Labels?.Select(MapLabel).ToList() ?? new List<Wallet.Api.Net.Models.Label.Label>()
            };

            if (!string.IsNullOrWhiteSpace(dto.Id) && Guid.TryParse(dto.Id, out var id))
                so.Id = id;

            return so;
        }

        private static Wallet.Api.Net.Models.Label.Label MapLabel(Wallet.Api.Net.Dtos.Label.LabelDto? dto)
        {
            if (dto is null)
                return new Wallet.Api.Net.Models.Label.Label();

            var label = new Wallet.Api.Net.Models.Label.Label
            {
                Archived = dto.Archived,
                Color = dto.Color,
                Name = dto.Name
            };

            if (!string.IsNullOrWhiteSpace(dto.Id) && Guid.TryParse(dto.Id, out var id))
                label.Id = id;

            return label;
        }

        private static Guid? ParseGuid(string? s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return null;

            if (Guid.TryParse(s, out var g))
                return g;

            return null;
        }
    }
}
