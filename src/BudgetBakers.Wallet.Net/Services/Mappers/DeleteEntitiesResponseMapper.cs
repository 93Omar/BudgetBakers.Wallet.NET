using BudgetBakers.Wallet.Net.Dtos.Delete;
using BudgetBakers.Wallet.Net.Models.Delete;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class DeleteEntitiesResponseMapper : IMapper<DeleteEntitiesResponseDto, DeleteEntitiesResponse>
    {
        public DeleteEntitiesResponse? Map(DeleteEntitiesResponseDto? source)
        {
            if (source is null)
                return null;

            return new DeleteEntitiesResponse
            {
                Results = source.Results
                                .Select(result => new DeleteResult
                                {
                                    InputIndex = result.InputIndex,
                                    Id = result.Id,
                                    Success = result.Success,
                                    Error = result.Error,
                                    ErrorType = result.ErrorType,
                                    Fields = result.Fields?.ToList() ?? []
                                })
                                .ToList(),
                Summary = MapperHelpers.MapBatchOperationSummary(source.Summary)
            };
        }
    }
}
