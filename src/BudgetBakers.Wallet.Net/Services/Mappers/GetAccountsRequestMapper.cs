using BudgetBakers.Wallet.Net.Dtos.Account;
using BudgetBakers.Wallet.Net.Models.Account;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetAccountsRequestMapper : IMapper<GetAccountsRequest, GetAccountsRequestDto>
    {
        public GetAccountsRequestDto? Map(GetAccountsRequest? source)
        {
            if (source is null)
                return null;

            GetAccountsRequestDto requestDto = new GetAccountsRequestDto()
            {
                Limit = source.Limit,
                Offset = source.Offset,
                AgentHints = source.AgentHints,
                WithTotal = source.WithTotal,
                Id = MapperHelpers.JoinIds(source.Ids),
                Name = source.Name?.ToString(),
                AccountType = source.AccountType?.ToString(),
                CurrencyCode = source.CurrencyCode,
                CreatedAt = source.CreatedAt?.ToString(),
                UpdatedAt = source.UpdatedAt?.ToString(),
                Archived = source.Archived,
                BudgetId = source.BudgetId,
                SortBy = source.SortBy?.ToApiString()
            };

            return requestDto;
        }
    }
}
