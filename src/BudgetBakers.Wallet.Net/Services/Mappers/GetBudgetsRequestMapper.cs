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
                CreatedAt = MapperHelpers.JoinFilters(source.CreatedAt),
                UpdatedAt = MapperHelpers.JoinFilters(source.UpdatedAt),
                Closed = source.Closed,
                Type = source.Type?.ToApiString(),
                LabelId = source.LabelId,
                AccountId = source.AccountId,
                CategoryId = MapperHelpers.JoinIds(source.CategoryIds),
                StartDate = MapperHelpers.JoinFilters(source.StartDate),
                EndDate = MapperHelpers.JoinFilters(source.EndDate),
                Spending = source.Spending?.ToApiString()
            };

            return requestDto;
        }
    }
}
