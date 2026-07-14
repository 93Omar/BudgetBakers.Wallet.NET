using BudgetBakers.Wallet.Net.Dtos.Record;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Record;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class UpdateRecordsResponseMapper : IMapper<UpdateRecordsResponseDto, UpdateRecordsResponse>
    {
        public UpdateRecordsResponse? Map(UpdateRecordsResponseDto? source)
        {
            if (source is null)
                return null;

            return new UpdateRecordsResponse
            {
                Results = source.Results
                                .Select(result => new UpdateRecordResult
                                {
                                    Id = result.Id,
                                    Success = result.Success,
                                    Record = MapperHelpers.MapRecord(result.Record),
                                    Error = result.Error,
                                    ErrorType = result.ErrorType
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
