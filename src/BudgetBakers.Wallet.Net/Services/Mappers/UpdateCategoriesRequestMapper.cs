using BudgetBakers.Wallet.Net.Dtos.Category;
using BudgetBakers.Wallet.Net.Models.Category;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class UpdateCategoriesRequestMapper : IMapper<UpdateCategoriesRequest, List<UpdateCategoryItemDto>>
    {
        public List<UpdateCategoryItemDto>? Map(UpdateCategoriesRequest? source)
        {
            if (source is null)
                return null;

            return source.Items
                         .Select(item => new UpdateCategoryItemDto
                         {
                             Id = item.Id,
                             Name = item.Name,
                             Color = item.Color?.ToApiString(),
                             Cardinality = item.Cardinality?.ToApiString(),
                             ResetName = item.ResetName
                         })
                         .ToList();
        }
    }
}
