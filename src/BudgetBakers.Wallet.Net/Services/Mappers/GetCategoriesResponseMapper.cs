using System;
using System.Collections.Generic;
using System.Linq;
using BudgetBakers.Wallet.Net.Dtos.Category;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Category;
using BudgetBakers.Wallet.Net.Models.Pagination;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetCategoriesResponseMapper : IMapper<GetCategoriesResponseDto, GetCategoriesResponse>
    {
        public GetCategoriesResponse? Map(GetCategoriesResponseDto? source)
        {
            if (source is null)
                return null;

            GetCategoriesResponse response = new GetCategoriesResponse()
            {
                Pagination = new PaginationInfo
                {
                    Limit = source.Limit,
                    Offset = source.Offset,
                    NextOffset = source.NextOffset,
                    Total = source.Total
                },
                Categories = source.Categories
                                .Select(MapperHelpers.MapCategory)
                                .OfType<Category>()
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
