using Wallet.Api.Net.Dtos.Stats;
using Wallet.Api.Net.Models.Stats;

namespace Wallet.Api.Net.Services.Mappers
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
