using BudgetBakers.Wallet.Net.Dtos.Budget;
using BudgetBakers.Wallet.Net.Models.Budget;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetBudgetsRequestMapper : IMapper<GetBudgetsRequest, GetBudgetsRequestDto>
    {
        public GetBudgetsRequestDto? Map(GetBudgetsRequest? source)
        {
            if (source is null)
                return null;

            GetBudgetsRequestDto requestDto = new()
            {
                Limit = source.Limit,
                Offset = source.Offset,
                AgentHints = source.AgentHints,
                WithTotal = source.WithTotal,
                Id = MapperHelpers.JoinIds(source.Ids),
                Name = source.Name?.ToString(),
                CurrencyCode = source.CurrencyCode,
                CreatedAt = source.CreatedAt?.ToString(),
                UpdatedAt = source.UpdatedAt?.ToString(),
                Closed = source.Closed,
                Type = source.Type?.ToApiString(),
                LabelId = source.LabelId,
                AccountId = source.AccountId,
                CategoryId = source.CategoryId,
                StartDate = source.StartDate?.ToString(),
                EndDate = source.EndDate?.ToString(),
                Spending = source.Spending?.ToApiString()
            };

            return requestDto;
        }
    }
}
