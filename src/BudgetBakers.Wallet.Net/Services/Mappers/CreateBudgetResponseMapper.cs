using BudgetBakers.Wallet.Net.Dtos.Budget;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Budget;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class CreateBudgetResponseMapper : IMapper<CreateBudgetResponseDto, CreateBudgetResponse>
    {
        public CreateBudgetResponse? Map(CreateBudgetResponseDto? source)
        {
            if (source is null)
                return null;

            return new CreateBudgetResponse
            {
                Budget = MapperHelpers.MapBudget(source.Budget),
                Summary = MapperHelpers.MapBatchOperationSummary(source.Summary),
                AgentHints = source.AgentHints
                                   .Select(MapperHelpers.MapAgentHint)
                                   .OfType<AgentHint>()
                                   .ToList()
            };
        }
    }
}
