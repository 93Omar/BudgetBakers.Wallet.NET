using BudgetBakers.Wallet.Net.Dtos.Label;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Label;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class UpdateLabelsResponseMapper : IMapper<UpdateLabelsResponseDto, UpdateLabelsResponse>
    {
        public UpdateLabelsResponse? Map(UpdateLabelsResponseDto? source)
        {
            if (source is null)
                return null;

            return new UpdateLabelsResponse
            {
                Results = source.Results
                                .Select(result => new UpdateLabelResult
                                {
                                    InputIndex = result.InputIndex,
                                    Id = result.Id,
                                    Success = result.Success,
                                    Label = MapperHelpers.MapLabel(result.Label),
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
