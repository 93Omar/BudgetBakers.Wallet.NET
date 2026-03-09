using Wallet.Api.Net.Dtos.RecordRule;
using Wallet.Api.Net.Models.RecordRule;

namespace Wallet.Api.Net.Services.Mappers
{
    public class GetRecordRulesRequestMapper : IMapper<GetRecordRulesRequest, GetRecordRulesRequestDto>
    {
        public GetRecordRulesRequestDto? Map(GetRecordRulesRequest? source)
        {
            if (source is null)
                return null;

            GetRecordRulesRequestDto dto = new GetRecordRulesRequestDto
            {
                Limit = source.Limit,
                Offset = source.Offset,
                AgentHints = source.AgentHints,
                Id = source.Ids.Any() ? string.Join(",", source.Ids) : null,
                Name = source.Name?.ToString(),
                CreatedAt = source.CreatedAt?.ToString(),
                UpdatedAt = source.UpdatedAt?.ToString()
            };

            return dto;
        }
    }
}
