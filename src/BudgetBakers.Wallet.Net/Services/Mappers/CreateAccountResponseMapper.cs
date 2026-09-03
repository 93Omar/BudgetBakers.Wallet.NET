using BudgetBakers.Wallet.Net.Dtos.Account;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Account;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class CreateAccountResponseMapper : IMapper<CreateAccountResponseDto, CreateAccountResponse>
    {
        public CreateAccountResponse? Map(CreateAccountResponseDto? source)
        {
            if (source is null)
                return null;

            return new CreateAccountResponse
            {
                Account = MapperHelpers.MapAccount(source.Account),
                Summary = MapperHelpers.MapBatchOperationSummary(source.Summary),
                AgentHints = source.AgentHints
                                   .Select(MapperHelpers.MapAgentHint)
                                   .OfType<AgentHint>()
                                   .ToList()
            };
        }
    }
}
