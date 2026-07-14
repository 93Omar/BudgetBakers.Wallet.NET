using System;
using System.Collections.Generic;
using System.Linq;
using BudgetBakers.Wallet.Net.Dtos.Label;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Label;
using BudgetBakers.Wallet.Net.Models.Pagination;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetLabelsResponseMapper : IMapper<GetLabelsResponseDto, GetLabelsResponse>
    {
        public GetLabelsResponse? Map(GetLabelsResponseDto? source)
        {
            if (source is null)
                return null;

            GetLabelsResponse response = new GetLabelsResponse()
            {
                Pagination = new PaginationInfo
                {
                    Limit = source.Limit,
                    Offset = source.Offset,
                    NextOffset = source.NextOffset,
                    Total = source.Total
                },
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

