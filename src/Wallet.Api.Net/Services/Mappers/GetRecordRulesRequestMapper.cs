using Wallet.Api.Net.Dtos.RecordRule;
using Wallet.Api.Net.Models.RecordRule;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Mappers
{
    internal class GetRecordRulesRequestMapper : IMapper<GetRecordRulesRequest, GetRecordRulesRequestDto>
    {
        public GetRecordRulesRequestDto? Map(GetRecordRulesRequest? source)
        {
            if (source is null)
                return null;

            GetRecordRulesRequestDto requestDto = new GetRecordRulesRequestDto()
            {
                Limit = source.Limit,
                Offset = source.Offset,
                AgentHints = source.AgentHints,
                Id = MapperHelpers.JoinIds(source.Ids),
                Name = source.Name?.ToString(),
                CreatedAt = source.CreatedAt?.ToString(),
                UpdatedAt = source.UpdatedAt?.ToString()
            };

            return requestDto;
        }
    }
}

