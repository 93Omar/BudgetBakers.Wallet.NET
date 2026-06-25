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
                    NextOffset = source.NextOffset
                },
                Categories = source.Categories
                                .Select(MapCategory)
                                .OfType<Category>()
                                .ToList(),
                AgentHints = source.AgentHints
                                .Select(MapperHelpers.MapAgentHint)
                                .OfType<AgentHint>()
                                .ToList()
            };

            return response;
        }

        private static Category? MapCategory(CategoryDto? dto)
        {
            if (dto is null)
                return null;

            var category = new Category
            {
                Archived = dto.Archived,
                Cardinality = dto.Cardinality,
                Color = dto.Color,
                CreatedAt = MapperHelpers.ParseDateTime(dto.CreatedAt),
                CustomCategory = dto.CustomCategory,
                CustomColor = dto.CustomColor,
                CustomName = dto.CustomName,
                Enabled = dto.Enabled,
                EnvelopeId = dto.EnvelopeId,
                IconName = dto.IconName,
                Name = dto.Name,
                UpdatedAt = MapperHelpers.ParseDateTime(dto.UpdatedAt)
            };

            if (MapperHelpers.ParseGuid(dto.Id) is Guid id)
                category.Id = id;

            return category;
        }
    }
}

