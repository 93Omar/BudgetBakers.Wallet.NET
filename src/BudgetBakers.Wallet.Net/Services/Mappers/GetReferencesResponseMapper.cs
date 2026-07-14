using System.Collections.Generic;
using System.Linq;
using BudgetBakers.Wallet.Net.Dtos.References;
using BudgetBakers.Wallet.Net.Models.References;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetReferencesResponseMapper : IMapper<GetReferencesResponseDto, GetReferencesResponse>
    {
        public GetReferencesResponse? Map(GetReferencesResponseDto? source)
        {
            if (source is null)
                return null;

            var references = source.ToDictionary(
                kvp => kvp.Key,
                kvp => MapEntry(kvp.Value));

            return new GetReferencesResponse
            {
                References = references
            };
        }

        private static EntityReferences MapEntry(ReferencesEntryDto? dto)
        {
            if (dto is null)
                return new EntityReferences();

            return new EntityReferences
            {
                Budgets = MapResult(dto.Budgets),
                RecordRules = MapResult(dto.RecordRules),
                Records = MapResult(dto.Records),
                StandingOrders = MapResult(dto.StandingOrders),
                Error = dto.Error,
                Message = dto.Message,
                ActualType = dto.ActualType
            };
        }

        private static ReferenceResult? MapResult(ReferenceResultDto? dto)
        {
            if (dto is null)
                return null;

            return new ReferenceResult
            {
                Field = dto.Field,
                HasMore = dto.HasMore,
                Ids = dto.Ids.ToList(),
                Limit = dto.Limit,
                Total = dto.Total
            };
        }
    }
}
