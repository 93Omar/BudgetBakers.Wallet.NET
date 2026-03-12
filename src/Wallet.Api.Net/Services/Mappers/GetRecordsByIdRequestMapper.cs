using System;
using Wallet.Api.Net.Dtos.Record;
using Wallet.Api.Net.Models.Record;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Mappers
{
    internal class GetRecordsByIdRequestMapper : IMapper<GetRecordsByIdRequest, GetRecordsByIdRequestDto>
    {
        public GetRecordsByIdRequestDto? Map(GetRecordsByIdRequest? source)
        {
            if (source is null)
                return null;

            GetRecordsByIdRequestDto dto = new GetRecordsByIdRequestDto
            {
                AgentHints = source.AgentHints,
                Id = MapperHelpers.JoinIds(source.Ids)
            };

            return dto;
        }
    }
}

