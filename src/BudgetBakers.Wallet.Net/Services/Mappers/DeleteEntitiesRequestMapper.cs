using BudgetBakers.Wallet.Net.Dtos.Delete;
using BudgetBakers.Wallet.Net.Models.Delete;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class DeleteEntitiesRequestMapper : IMapper<DeleteEntitiesRequest, DeleteEntitiesRequestDto>
    {
        public DeleteEntitiesRequestDto? Map(DeleteEntitiesRequest? source)
        {
            if (source is null)
                return null;

            return new DeleteEntitiesRequestDto
            {
                Ids = source.Ids
            };
        }
    }
}
