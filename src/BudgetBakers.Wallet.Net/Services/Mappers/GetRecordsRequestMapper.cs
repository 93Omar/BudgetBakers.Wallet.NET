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
                AccountId = source.AccountId,
                RecordDate = source.RecordDate?.ToString(),
                Limit = source.Limit,
                Offset = source.Offset,
                AgentHints = source.AgentHints,
                WithTotal = source.WithTotal,
                CategoryId = source.CategoryId,
                LabelId = source.LabelId,
                Note = source.Note?.ToString(),
                CounterParty = source.CounterParty?.ToString(),
                Amount = source.Amount?.ToString(),
                CreatedAt = source.CreatedAt?.ToString(),
                UpdatedAt = source.UpdatedAt?.ToString(),
                RecordType = source.RecordType?.ToApiString(),
                PaymentType = source.PaymentType?.ToApiString(),
                RecordState = source.RecordState?.ToApiString(),
                Source = source.Source,
                ConvertTo = source.ConvertTo,
                SortBy = source.SortBy?.ToApiString()
            };

            return dto;
        }
    }
}

