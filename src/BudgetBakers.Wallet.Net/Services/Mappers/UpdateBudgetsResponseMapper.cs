using BudgetBakers.Wallet.Net.Dtos.Budget;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Budget;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class UpdateBudgetsResponseMapper : IMapper<UpdateBudgetsResponseDto, UpdateBudgetsResponse>
    {
        public UpdateBudgetsResponse? Map(UpdateBudgetsResponseDto? source)
        {
            if (source is null)
                return null;

            return new UpdateBudgetsResponse
            {
                Results = source.Results
                                .Select(result => new UpdateBudgetResult
                                {
                                    InputIndex = result.InputIndex,
                                    Id = result.Id,
                                    Success = result.Success,
                                    Budget = MapperHelpers.MapBudget(result.Budget),
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
