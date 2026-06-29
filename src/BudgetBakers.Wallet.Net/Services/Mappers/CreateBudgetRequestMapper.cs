using System.Globalization;
using BudgetBakers.Wallet.Net.Dtos.Budget;
using BudgetBakers.Wallet.Net.Models.Budget;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class CreateBudgetRequestMapper : IMapper<CreateBudgetRequest, CreateBudgetRequestDto>
    {
        public CreateBudgetRequestDto? Map(CreateBudgetRequest? source)
        {
            if (source is null)
                return null;

            return new CreateBudgetRequestDto
            {
                Name = source.Name,
                CurrencyCode = source.CurrencyCode,
                Type = source.Type.ToApiString(),
                Limit = source.Limit,
                AccountIds = source.AccountIds,
                CategoryIds = source.CategoryIds,
                LabelIds = source.LabelIds,
                StartDate = source.StartDate?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                EndDate = source.EndDate?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
            };
        }
    }
}
