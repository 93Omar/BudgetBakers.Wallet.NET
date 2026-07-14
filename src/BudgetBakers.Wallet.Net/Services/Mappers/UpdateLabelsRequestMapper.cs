using BudgetBakers.Wallet.Net.Dtos.Label;
using BudgetBakers.Wallet.Net.Models.Label;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class UpdateLabelsRequestMapper : IMapper<UpdateLabelsRequest, List<UpdateLabelItemDto>>
    {
        public List<UpdateLabelItemDto>? Map(UpdateLabelsRequest? source)
        {
            if (source is null)
                return null;

            return source.Items
                         .Select(item => new UpdateLabelItemDto
                         {
                             Id = item.Id,
                             Name = item.Name,
                             Color = item.Color?.ToApiString(),
                             Archived = item.Archived
                         })
                         .ToList();
        }
    }
}
