using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Api.Net.Dtos.Label;
using Wallet.Api.Net.Dtos.Record;
using Wallet.Api.Net.Models.Label;
using Wallet.Api.Net.Models.Record;

namespace Wallet.Api.Net.Services.Mappers
{
    public class GetRecordsByIdRequestMapper : IMapper<GetRecordsByIdRequest, GetRecordsByIdRequestDto>
    {
        public GetRecordsByIdRequestDto? Map(GetRecordsByIdRequest? source)
        {
            throw new NotImplementedException();
        }
    }
}
