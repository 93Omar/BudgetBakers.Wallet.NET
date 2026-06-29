using BudgetBakers.Wallet.Net.Dtos.References;
using BudgetBakers.Wallet.Net.Models.References;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetReferencesRequestMapper : IMapper<GetReferencesRequest, GetReferencesRequestDto>
    {
        public GetReferencesRequestDto? Map(GetReferencesRequest? source)
        {
            if (source is null)
                return null;

            return new GetReferencesRequestDto
            {
                Id = MapperHelpers.JoinIds(source.Ids)
            };
        }
    }
}
