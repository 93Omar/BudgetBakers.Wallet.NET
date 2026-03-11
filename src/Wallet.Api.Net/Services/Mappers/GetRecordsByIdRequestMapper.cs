using System;
using Wallet.Api.Net.Dtos.Record;
using Wallet.Api.Net.Models.Record;

namespace Wallet.Api.Net.Services.Mappers
{
    public class GetRecordsByIdRequestMapper : IMapper<GetRecordsByIdRequest, GetRecordsByIdRequestDto>
    {
        public GetRecordsByIdRequestDto? Map(GetRecordsByIdRequest? source)
        {
            if (source is null)
                return null;

            GetRecordsByIdRequestDto dto = new GetRecordsByIdRequestDto
            {
                AgentHints = source.AgentHints,
                Id = source.Ids.Any() ? string.Join(",", source.Ids) : null
            };

            return dto;
        }
    }
}
