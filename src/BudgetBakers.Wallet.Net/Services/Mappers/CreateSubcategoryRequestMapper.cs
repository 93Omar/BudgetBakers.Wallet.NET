using BudgetBakers.Wallet.Net.Dtos.Category;
using BudgetBakers.Wallet.Net.Models.Category;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class CreateSubcategoryRequestMapper : IMapper<CreateSubcategoryRequest, CreateSubcategoryRequestDto>
    {
        public CreateSubcategoryRequestDto? Map(CreateSubcategoryRequest? source)
        {
            if (source is null)
                return null;

            return new CreateSubcategoryRequestDto
            {
                Name = source.Name,
                ParentId = source.ParentId,
                Color = source.Color?.ToApiString(),
                Cardinality = source.Cardinality?.ToApiString()
            };
        }
    }
}
