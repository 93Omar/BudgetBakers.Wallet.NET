using BudgetBakers.Wallet.Net.Dtos.Category;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Category;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class CreateCategoryResponseMapper : IMapper<CreateCategoryResponseDto, CreateCategoryResponse>
    {
        public CreateCategoryResponse? Map(CreateCategoryResponseDto? source)
        {
            if (source is null)
                return null;

            return new CreateCategoryResponse
            {
                Category = MapperHelpers.MapCategory(source.Category),
                AgentHints = source.AgentHints
                                   .Select(MapperHelpers.MapAgentHint)
                                   .OfType<AgentHint>()
                                   .ToList()
            };
        }
    }
}
