using BudgetBakers.Wallet.Net.Dtos.Account;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Account;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class UpdateAccountsResponseMapper : IMapper<UpdateAccountsResponseDto, UpdateAccountsResponse>
    {
        public UpdateAccountsResponse? Map(UpdateAccountsResponseDto? source)
        {
            if (source is null)
                return null;

            return new UpdateAccountsResponse
            {
                Results = source.Results
                                .Select(result => new UpdateAccountResult
                                {
                                    InputIndex = result.InputIndex,
                                    Id = result.Id,
                                    Success = result.Success,
                                    Account = MapperHelpers.MapAccount(result.Account),
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
