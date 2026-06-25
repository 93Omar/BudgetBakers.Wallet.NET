using BudgetBakers.Wallet.Net.Dtos.RecordRule;
using BudgetBakers.Wallet.Net.Models.RecordRule;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
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

