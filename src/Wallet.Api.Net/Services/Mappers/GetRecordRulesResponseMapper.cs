using System;
using System.Collections.Generic;
using System.Linq;
using Wallet.Api.Net.Dtos.RecordRule;
using Wallet.Api.Net.Models.RecordRule;
using Wallet.Api.Net.Models.Label;
using Wallet.Api.Net.Models.Category;
using Wallet.Api.Net.Utility;
using Wallet.Api.Net.Models;

namespace Wallet.Api.Net.Services.Mappers
{
    internal class GetRecordRulesResponseMapper : IMapper<GetRecordRulesResponseDto, GetRecordRulesResponse>
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
                ToAccountId = MapperHelpers.ParseGuid(dto.ToAccountId),
                FromAccountId = MapperHelpers.ParseGuid(dto.FromAccountId),
                Keywords = dto.Keywords.ToList(),
                Labels = dto.Labels
                            .Select(MapperHelpers.MapLabel)
                            .OfType<Label>()
                            .ToList(),
                UpdatedAt = MapperHelpers.ParseDateTime(dto.UpdatedAt)
            };

            if (MapperHelpers.ParseGuid(dto.Id) is Guid id)
                rule.Id = id;

            return rule;
        }
    }
}

