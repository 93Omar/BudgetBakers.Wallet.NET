using System.Linq;
using Wallet.Api.Net.Dtos.Stats;
using Wallet.Api.Net.Models.Stats;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Mappers
{
    internal class GetStatsResponseMapper : IMapper<GetStatsResponseDto, GetStatsResponse>
    {
        public GetStatsResponse? Map(GetStatsResponseDto? source)
        {
            if (source is null)
                return null;

            GetStatsResponse response = new()
            {
                Granularity = source.Granularity,
                Period = source.Period,
                Total = source.Total,
                Usage = source.Usage
                    .Select(MapUsage)
                    .OfType<StatsUsage>()
                    .ToList()
            };

            return response;
        }

        private static StatsUsage? MapUsage(StatsUsageDto? dto)
        {
            if (dto is null)
                return null;

            return new StatsUsage
            {
                From = MapperHelpers.ParseDateTime(dto.From),
                To = MapperHelpers.ParseDateTime(dto.To),
                Total = dto.Total
            };
        }
    }
}
