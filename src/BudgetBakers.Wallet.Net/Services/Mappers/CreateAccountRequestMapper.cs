using BudgetBakers.Wallet.Net.Dtos.Account;
using BudgetBakers.Wallet.Net.Models.Account;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class CreateAccountRequestMapper : IMapper<CreateAccountRequest, CreateAccountRequestDto>
    {
        public CreateAccountRequestDto? Map(CreateAccountRequest? source)
        {
            if (source is null)
                return null;

            return new CreateAccountRequestDto
            {
                Name = source.Name,
                AccountType = source.AccountType.ToApiString(),
                CurrencyCode = source.CurrencyCode,
                InitialBalance = source.InitialBalance,
                Color = source.Color?.ToApiString(),
                BankAccountNumber = source.BankAccountNumber,
                ExcludeFromStats = source.ExcludeFromStats
            };
        }
    }
}
