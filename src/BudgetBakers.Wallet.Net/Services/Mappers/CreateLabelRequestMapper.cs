using BudgetBakers.Wallet.Net.Dtos.Label;
using BudgetBakers.Wallet.Net.Models.Label;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class CreateLabelRequestMapper : IMapper<CreateLabelRequest, CreateLabelRequestDto>
    {
        public CreateLabelRequestDto? Map(CreateLabelRequest? source)
        {
            if (source is null)
                return null;

            return new CreateLabelRequestDto
            {
                Name = source.Name,
                Color = source.Color?.ToApiString()
            };
        }
    }
}
