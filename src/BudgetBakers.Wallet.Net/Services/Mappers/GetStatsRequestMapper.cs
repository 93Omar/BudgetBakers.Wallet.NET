using BudgetBakers.Wallet.Net.Dtos.Stats;
using BudgetBakers.Wallet.Net.Models.Stats;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetStatsRequestMapper : IMapper<GetStatsRequest, GetStatsRequestDto>
    {
        public GetStatsRequestDto? Map(GetStatsRequest? source)
        {
            if (source is null)
                return null;

            GetStatsRequestDto requestDto = new()
            {
                Period = source.Period.ToString()
            };

            return requestDto;
        }
    }
}
