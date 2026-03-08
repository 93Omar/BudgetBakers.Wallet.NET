using System;
using System.Collections.Generic;
using System.Linq;
using Wallet.Api.Net.Dtos.RecordRule;
using Wallet.Api.Net.Models.RecordRule;
using Wallet.Api.Net.Models.Label;
using Wallet.Api.Net.Models.Category;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Mappers
{
    public class GetRecordRulesResponseMapper : IMapper<GetRecordRulesResponseDto, GetRecordRulesResponse>
    {
        public GetRecordRulesResponse? Map(GetRecordRulesResponseDto? source)
        {
            if (source is null)
                return null;

            GetRecordRulesResponse response = new GetRecordRulesResponse()
            {
                Limit = source.Limit,
                Offset = source.Offset,
                NextOffset = source.NextOffset,
                RecordRules = source.RecordRules?.Select(MapRecordRule).ToList() ?? new List<RecordRule>(),
                AgentHints = source.AgentHints?.Select(MapperHelpers.MapAgentHint).ToList() ?? new List<Models.Account.AgentHint>()
            };

            return response;
        }

        private static RecordRule MapRecordRule(RecordRuleDto? dto)
        {
            if (dto is null)
                return new RecordRule();

            var rule = new RecordRule
            {
                Category = dto.Category is null ? null : new Category
                {
                    Color = dto.Category.Color,
                    EnvelopeId = dto.Category.EnvelopeId,
                    Name = dto.Category.Name
                },
                CreatedAt = MapperHelpers.ParseDateTime(dto.CreatedAt),
                Name = dto.Name,
                ToAccountId = ParseGuid(dto.ToAccountId),
                FromAccountId = ParseGuid(dto.FromAccountId),
                Keywords = dto.Keywords?.ToList() ?? new List<string>(),
                Labels = dto.Labels?.Select(MapLabel).ToList() ?? new List<Label>(),
                UpdatedAt = MapperHelpers.ParseDateTime(dto.UpdatedAt)
            };

            if (!string.IsNullOrWhiteSpace(dto.Id) && Guid.TryParse(dto.Id, out var id))
                rule.Id = id;

            return rule;
        }

        private static Label MapLabel(Wallet.Api.Net.Dtos.Label.LabelDto? dto)
        {
            if (dto is null)
                return new Label();

            var label = new Label
            {
                Archived = dto.Archived,
                Color = dto.Color,
                Name = dto.Name,
                CreatedAt = MapperHelpers.ParseDateTime(dto.CreatedAt),
                UpdatedAt = MapperHelpers.ParseDateTime(dto.UpdatedAt)
            };

            if (!string.IsNullOrWhiteSpace(dto.Id) && Guid.TryParse(dto.Id, out var id))
                label.Id = id;

            return label;
        }

        private static Guid? ParseGuid(string? s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return null;

            if (Guid.TryParse(s, out var g))
                return g;

            return null;
        }
    }
}
