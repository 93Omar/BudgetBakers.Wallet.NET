using BudgetBakers.Wallet.Net.Dtos;
using BudgetBakers.Wallet.Net.Dtos.Budget;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Budget;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class UpdateBudgetsRequestMapper : IMapper<UpdateBudgetsRequest, List<UpdateBudgetItemDto>>
    {
        public List<UpdateBudgetItemDto>? Map(UpdateBudgetsRequest? source)
        {
            if (source is null)
                return null;

            return source.Items
                         .Select(item => new UpdateBudgetItemDto
                         {
                             Id = item.Id,
                             Name = item.Name,
                             Closed = item.Closed,
                             StartDate = item.StartDate,
                             EndDate = item.EndDate,
                             AccountIds = MapIdsOperation(item.AccountIds),
                             CategoryIds = MapIdsOperation(item.CategoryIds),
                             LabelIds = MapIdsOperation(item.LabelIds),
                             ResetLimit = item.ResetLimit,
                             LimitOverrides = item.LimitOverrides?.Select(limitOverride => new LimitOverrideDto
                             {
                                 Period = limitOverride.Period,
                                 Limit = limitOverride.Limit,
                                 SetBaseline = limitOverride.SetBaseline
                             }).ToList()
                         })
                         .ToList();
        }

        private static IdsOperationDto? MapIdsOperation(IdsOperation? source)
        {
            if (source is null)
                return null;

            return new IdsOperationDto
            {
                ReplaceWith = source.ReplaceWith,
                Add = source.Add,
                Remove = source.Remove
            };
        }
    }
}
