using System;
using System.Collections.Generic;
using System.Linq;
using BudgetBakers.Wallet.Net.Dtos.Record;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Label;
using BudgetBakers.Wallet.Net.Models.Record;
using BudgetBakers.Wallet.Net.Models.Pagination;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetRecordsResponseMapper : IMapper<GetRecordsResponseDto, GetRecordsResponse>
    {
        public GetRecordsResponse? Map(GetRecordsResponseDto? source)
        {
            if (source is null)
                return null;

            GetRecordsResponse response = new GetRecordsResponse()
            {
                Pagination = new PaginationInfo
                {
                    Limit = source.Limit,
                    Offset = source.Offset,
                    NextOffset = source.NextOffset,
                    Total = source.Total
                },
                AppliedRecordDateFilters = MapperHelpers.ParseDateFilters(source.AppliedRecordDateFilters),
                Records = source.Records
                            .Select(MapperHelpers.MapRecord)
                            .OfType<Record>()
                            .ToList(),
                AgentHints = source.AgentHints
                            .Select(MapperHelpers.MapAgentHint)
                            .OfType<AgentHint>()
                            .ToList()
            };

            return response;
        }
    }
}
