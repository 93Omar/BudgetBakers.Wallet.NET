using System;
using System.Collections.Generic;
using System.Linq;
using Wallet.Api.Net.Dtos.Label;
using Wallet.Api.Net.Models.Label;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Mappers
{
    public class GetLabelsResponseMapper : IMapper<GetLabelsResponseDto, GetLabelsResponse>
    {
        public GetLabelsResponse? Map(GetLabelsResponseDto? source)
        {
            if (source is null)
                return null;

            GetLabelsResponse response = new GetLabelsResponse()
            {
                Limit = source.Limit,
                Offset = source.Offset,
                NextOffset = source.NextOffset,
                Labels = source.Labels?.Select(MapLabel).ToList() ?? new List<Label>(),
                AgentHints = source.AgentHints?.Select(MapperHelpers.MapAgentHint).ToList() ?? new List<Models.Account.AgentHint>()
            };

            return response;
        }

        private static Label MapLabel(LabelDto? dto)
        {
            if (dto is null)
                return new Label();

            var label = new Label
            {
                Archived = dto.Archived,
                Color = dto.Color,
                CreatedAt = MapperHelpers.ParseDateTime(dto.CreatedAt),
                Name = dto.Name,
                UpdatedAt = MapperHelpers.ParseDateTime(dto.UpdatedAt)
            };

            if (!string.IsNullOrWhiteSpace(dto.Id) && Guid.TryParse(dto.Id, out var id))
                label.Id = id;

            return label;
        }
    }
}
