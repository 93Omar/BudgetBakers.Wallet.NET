using BudgetBakers.Wallet.Net.Dtos.Category;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Category;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class UpdateCategoriesResponseMapper : IMapper<UpdateCategoriesResponseDto, UpdateCategoriesResponse>
    {
        public UpdateCategoriesResponse? Map(UpdateCategoriesResponseDto? source)
        {
            if (source is null)
                return null;

            return new UpdateCategoriesResponse
            {
                Results = source.Results
                                .Select(result => new UpdateCategoryResult
                                {
                                    InputIndex = result.InputIndex,
                                    Id = result.Id,
                                    Success = result.Success,
                                    Category = MapperHelpers.MapCategory(result.Category),
                                    Error = result.Error,
                                    ErrorType = result.ErrorType,
                                    Fields = result.Fields?.ToList() ?? []
                                })
                                .ToList(),
                Summary = MapperHelpers.MapBatchOperationSummary(source.Summary),
                AgentHints = source.AgentHints
                                .Select(MapperHelpers.MapAgentHint)
                                .OfType<AgentHint>()
                                .ToList()
            };
        }
    }
}
