using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Models.Account;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Mappers
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
                Id = MapperHelpers.JoinIds(source.Ids),
                Name = source.Name?.ToString(),
                BankAccountNumber = source.BankAccountNumber?.ToString(),
                AccountType = source.AccountType?.ToString(),
                CurrencyCode = source.CurrencyCode,
                CreatedAt = source.CreatedAt?.ToString(),
                UpdatedAt = source.UpdatedAt?.ToString()
            };

            return requestDto;
        }
    }
}
