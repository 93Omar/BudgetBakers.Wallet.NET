using BudgetBakers.Wallet.Net.Dtos.Account;
using BudgetBakers.Wallet.Net.Models.Account;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class UpdateAccountsRequestMapper : IMapper<UpdateAccountsRequest, List<UpdateAccountItemDto>>
    {
        public List<UpdateAccountItemDto>? Map(UpdateAccountsRequest? source)
        {
            if (source is null)
                return null;

            return source.Items
                         .Select(item => new UpdateAccountItemDto
                         {
                             Id = item.Id,
                             Name = item.Name,
                             Color = item.Color?.ToApiString(),
                             Archived = item.Archived,
                             ExcludeFromStats = item.ExcludeFromStats,
                             InitialBalance = item.InitialBalance,
                             BankAccountNumber = item.BankAccountNumber
                         })
                         .ToList();
        }
    }
}
