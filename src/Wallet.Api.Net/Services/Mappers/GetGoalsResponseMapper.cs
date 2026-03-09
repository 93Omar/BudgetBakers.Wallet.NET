using System;
using System.Collections.Generic;
using System.Linq;
using Wallet.Api.Net.Dtos.Goal;
using Wallet.Api.Net.Models;
using Wallet.Api.Net.Models.Goal;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Mappers
{
    public class GetGoalsResponseMapper : IMapper<GetGoalsResponseDto, GetGoalsResponse>
    {
        public GetGoalsResponse? Map(GetGoalsResponseDto? source)
        {
            if (source is null)
                return null;

            GetGoalsResponse response = new GetGoalsResponse()
            {
                Limit = source.Limit,
                Offset = source.Offset,
                NextOffset = source.NextOffset,
                Goals = source.Goals
                            .Select(MapGoal)
                            .OfType<Goal>()
                            .ToList(),
                AgentHints = source.AgentHints
                            .Select(MapperHelpers.MapAgentHint)
                            .OfType<AgentHint>()
                            .ToList()
            };

            return response;
        }

        private static Goal? MapGoal(GoalDto? dto)
        {
            if (dto is null)
                return null;

            var goal = new Goal
            {
                Color = dto.Color,
                CreatedAt = MapperHelpers.ParseDateTime(dto.CreatedAt),
                DesiredDate = dto.DesiredDate,
                IconName = dto.IconName,
                InitialAmount = dto.InitialAmount,
                Name = dto.Name,
                Note = dto.Note,
                State = dto.State,
                StateUpdatedAt = dto.StateUpdatedAt,
                TargetAmount = dto.TargetAmount,
                UpdatedAt = MapperHelpers.ParseDateTime(dto.UpdatedAt)
            };

            if (!string.IsNullOrWhiteSpace(dto.Id) && Guid.TryParse(dto.Id, out var id))
                goal.Id = id;

            return goal;
        }
    }
}
