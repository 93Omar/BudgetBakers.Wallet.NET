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
                CreatedAt = source.CreatedAt?.ToString(),
                UpdatedAt = source.UpdatedAt?.ToString(),
                CustomCategory = source.CustomCategory,
                Archived = source.Archived,
                BudgetId = source.BudgetId,
                SortBy = source.SortBy?.ToApiString()
            };

            return requestDto;
        }
    }
}

