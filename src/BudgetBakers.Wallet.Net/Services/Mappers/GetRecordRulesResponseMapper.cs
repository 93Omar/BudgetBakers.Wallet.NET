using System.Linq;
using BudgetBakers.Wallet.Net.Dtos.RecordRule;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Category;
using BudgetBakers.Wallet.Net.Models.Label;
using BudgetBakers.Wallet.Net.Models.Pagination;
using BudgetBakers.Wallet.Net.Models.RecordRule;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetRecordRulesResponseMapper : IMapper<GetRecordRulesResponseDto, GetRecordRulesResponse>
    {
        public GetRecordRulesResponse? Map(GetRecordRulesResponseDto? source)
        {
            if (source is null)
                return null;

            GetRecordRulesResponse response = new()
            {
                Pagination = new PaginationInfo
                {
                    Limit = source.Limit,
                    Offset = source.Offset,
                    NextOffset = source.NextOffset,
                    Total = source.Total
                },
                RecordRules = source.RecordRules
                                .Select(MapRecordRule)
                                .OfType<RecordRule>()
                                .ToList(),
                AgentHints = source.AgentHints
                                .Select(MapperHelpers.MapAgentHint)
                                .OfType<AgentHint>()
                                .ToList()
            };

            return response;
        }

        private static RecordRule? MapRecordRule(RecordRuleDto? dto)
        {
            if (dto is null)
                return null;

            return new RecordRule
            {
                Category = dto.Category is null ? null : new Category
                {
                    Color = dto.Category.Color,
                    Name = dto.Category.Name
                },
                CreatedAt = MapperHelpers.ParseDateTime(dto.CreatedAt),
                Name = dto.Name,
                ToAccountId = dto.ToAccountId,
                FromAccountId = dto.FromAccountId,
                Id = dto.Id,
                Keywords = dto.Keywords.ToList(),
                Labels = dto.Labels
                            .Select(MapperHelpers.MapLabel)
                            .OfType<Label>()
                            .ToList(),
                UpdatedAt = MapperHelpers.ParseDateTime(dto.UpdatedAt)
            };
        }
    }
}
