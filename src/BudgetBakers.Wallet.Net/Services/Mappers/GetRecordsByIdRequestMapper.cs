using System;
using BudgetBakers.Wallet.Net.Dtos.Record;
using BudgetBakers.Wallet.Net.Models.Record;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
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

