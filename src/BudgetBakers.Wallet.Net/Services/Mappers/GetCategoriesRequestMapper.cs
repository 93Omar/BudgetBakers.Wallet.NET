using BudgetBakers.Wallet.Net.Dtos.Category;
using BudgetBakers.Wallet.Net.Models.Category;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetCategoriesRequestMapper : IMapper<GetCategoriesRequest, GetCategoriesRequestDto>
    {
        public GetCategoriesRequestDto? Map(GetCategoriesRequest? source)
        {
            if (source is null)
                return null;

            GetCategoriesRequestDto requestDto = new GetCategoriesRequestDto()
            {
                Limit = source.Limit,
                Offset = source.Offset,
                AgentHints = source.AgentHints,
                WithTotal = source.WithTotal,
                Id = MapperHelpers.JoinIds(source.Ids),
                Name = source.Name?.ToString(),
                CreatedAt = MapperHelpers.JoinFilters(source.CreatedAt),
                UpdatedAt = MapperHelpers.JoinFilters(source.UpdatedAt),
                CustomCategory = source.CustomCategory,
                Archived = source.Archived,
                BudgetId = source.BudgetId,
                Cardinality = source.Cardinality?.ToApiString(),
                SortBy = source.SortBy?.ToApiString()
            };

            return requestDto;
        }
    }
}

