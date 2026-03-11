using Wallet.Api.Net.Dtos.Record;
using Wallet.Api.Net.Models.Record;

namespace Wallet.Api.Net.Services.Mappers
{
    internal class GetRecordsRequestMapper : IMapper<GetRecordsRequest, GetRecordsRequestDto>
    {
        public GetRecordsRequestDto? Map(GetRecordsRequest? source)
        {
            if (source is null)
                return null;

            GetRecordsRequestDto dto = new GetRecordsRequestDto
            {
                AccountId = source.AccountId,
                RecordDate = source.RecordDate?.ToString(),
                Limit = source.Limit,
                Offset = source.Offset,
                AgentHints = source.AgentHints,
                CategoryId = source.CategoryId,
                LabelId = source.LabelId,
                Note = source.Note?.ToString(),
                Payee = source.Payee?.ToString(),
                Amount = source.Amount,
                CreatedAt = source.CreatedAt?.ToString(),
                UpdatedAt = source.UpdatedAt?.ToString(),
                SortBy = source.SortBy
            };

            return dto;
        }
    }
}

