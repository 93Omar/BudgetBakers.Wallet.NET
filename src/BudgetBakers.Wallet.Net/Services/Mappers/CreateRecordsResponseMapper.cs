using BudgetBakers.Wallet.Net.Dtos.Record;
using BudgetBakers.Wallet.Net.Models.Record;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class CreateRecordsResponseMapper : IMapper<CreateRecordsResponseDto, CreateRecordsResponse>
    {
        public CreateRecordsResponse? Map(CreateRecordsResponseDto? source)
        {
            if (source is null)
                return null;

            return new CreateRecordsResponse
            {
                Results = source.Results
                                .Select(result => new CreateRecordResult
                                {
                                    InputIndex = result.InputIndex,
                                    Id = result.Id,
                                    Success = result.Success,
                                    Record = MapperHelpers.MapRecord(result.Record),
                                    Error = result.Error,
                                    ErrorType = result.ErrorType
                                })
                                .ToList(),
                Summary = MapperHelpers.MapBatchOperationSummary(source.Summary)
            };
        }
    }
}
