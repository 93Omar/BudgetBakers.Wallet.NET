using System;
using System.Collections.Generic;
using System.Linq;
using BudgetBakers.Wallet.Net.Dtos.Goal;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Goal;
using BudgetBakers.Wallet.Net.Models.Pagination;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetGoalsResponseMapper : IMapper<GetGoalsResponseDto, GetGoalsResponse>
    {
        public GetGoalsResponse? Map(GetGoalsResponseDto? source)
        {
            if (source is null)
                return null;

            GetGoalsResponse response = new GetGoalsResponse()
            {
                Pagination = new PaginationInfo
                {
                    Limit = source.Limit,
                    Offset = source.Offset,
                    NextOffset = source.NextOffset
                },
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
                InitialAmount = dto.InitialAmount is null ? null : new AmountWithCurrency
                {
                    CurrencyCode = dto.InitialAmount.CurrencyCode,
                    Value = dto.InitialAmount.Value
                },
                Name = dto.Name,
                Note = dto.Note,
                State = dto.State,
                StateUpdatedAt = dto.StateUpdatedAt,
                TargetAmount = dto.TargetAmount is null ? null : new AmountWithCurrency
                {
                    CurrencyCode = dto.TargetAmount.CurrencyCode,
                    Value = dto.TargetAmount.Value
                },
                UpdatedAt = MapperHelpers.ParseDateTime(dto.UpdatedAt)
            };

            if (MapperHelpers.ParseGuid(dto.Id) is Guid id)
                goal.Id = id;

            return goal;
        }
    }
}

