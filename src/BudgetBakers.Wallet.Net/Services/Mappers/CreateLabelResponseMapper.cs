using BudgetBakers.Wallet.Net.Dtos.Label;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Label;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class CreateLabelResponseMapper : IMapper<CreateLabelResponseDto, CreateLabelResponse>
    {
        public CreateLabelResponse? Map(CreateLabelResponseDto? source)
        {
            if (source is null)
                return null;

            return new CreateLabelResponse
            {
                Label = MapperHelpers.MapLabel(source.Label),
                Summary = MapperHelpers.MapBatchOperationSummary(source.Summary),
                AgentHints = source.AgentHints
                                   .Select(MapperHelpers.MapAgentHint)
                                   .OfType<AgentHint>()
                                   .ToList()
            };
        }
    }
}
