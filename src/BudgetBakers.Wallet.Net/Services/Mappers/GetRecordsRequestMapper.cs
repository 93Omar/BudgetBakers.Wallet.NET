using System.Linq;
using BudgetBakers.Wallet.Net.Dtos.Record;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Record;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetRecordsRequestMapper : IMapper<GetRecordsRequest, GetRecordsRequestDto>
    {
        public GetRecordsRequestDto? Map(GetRecordsRequest? source)
        {
            if (source is null)
                return null;

            GetRecordsRequestDto dto = new GetRecordsRequestDto
            {
                Id = MapperHelpers.JoinIds(source.Ids),
                AccountId = MapperHelpers.JoinIds(source.AccountIds),
                RecordDate = MapperHelpers.JoinFilters(source.RecordDate),
                Limit = source.Limit,
                Offset = source.Offset,
                AgentHints = source.AgentHints,
                WithTotal = source.WithTotal,
                CategoryId = MapperHelpers.JoinIds(source.CategoryIds),
                LabelId = source.LabelId,
                Note = source.Note?.ToString(),
                CounterParty = source.CounterParty?.ToString(),
                Amount = MapperHelpers.JoinFilters(source.Amount),
                CreatedAt = MapperHelpers.JoinFilters(source.CreatedAt),
                UpdatedAt = MapperHelpers.JoinFilters(source.UpdatedAt),
                RecordType = source.RecordType?.ToApiString(),
                IsTransfer = source.IsTransfer,
                TransferId = MapperHelpers.JoinIds(source.TransferIds),
                RecordState = MapperHelpers.JoinIds(source.RecordStates.Select(state => state.ToApiString())),
                Source = MapperHelpers.JoinIds(source.Sources),
                ConvertTo = source.ConvertTo,
                SortBy = source.SortBy?.ToApiString()
            };

            return dto;
        }
    }
}

