using System;
using System.Collections.Generic;
using System.Text;
using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Models.Account;

namespace Wallet.Api.Net.Services.Mappers
{
    public class GetAccountsResponseMapper : IMapper<GetAccountsResponseDto, GetAccountsResponse>
    {
        public GetAccountsResponse? Map(GetAccountsResponseDto? source)
        {
            if (source is null)
                return null;

            GetAccountsResponse response = new GetAccountsResponse()
            {
                Limit = source.Limit,
                Offset = source.Offset,
                NextOffset = source.NextOffset
            };

            return response;
        }
    }
}
