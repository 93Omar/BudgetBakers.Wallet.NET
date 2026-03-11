using System;
using System.Collections.Generic;
using System.Linq;
using Wallet.Api.Net.Dtos.Label;
using Wallet.Api.Net.Models;
using Wallet.Api.Net.Models.Label;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Mappers
{
    internal class GetLabelsResponseMapper : IMapper<GetLabelsResponseDto, GetLabelsResponse>
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
                Labels = source.Labels
                            .Select(MapperHelpers.MapLabel)
                            .OfType<Label>()
                            .ToList(),
                AgentHints = source.AgentHints
                            .Select(MapperHelpers.MapAgentHint)
                            .OfType<AgentHint>()
                            .ToList()
            };

            return response;
        }      
    }
}

