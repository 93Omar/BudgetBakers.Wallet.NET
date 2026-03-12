using System;
using System.Collections.Generic;
using System.Linq;
using Wallet.Api.Net.Dtos.Record;
using Wallet.Api.Net.Models;
using Wallet.Api.Net.Models.Label;
using Wallet.Api.Net.Models.Record;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Services.Mappers
{
    internal class GetRecordsResponseMapper : IMapper<GetRecordsResponseDto, GetRecordsResponse>
    {
        public GetRecordsResponse? Map(GetRecordsResponseDto? source)
        {
            if (source is null)
                return null;

            GetRecordsResponse response = new GetRecordsResponse()
            {
                Limit = source.Limit,
                Offset = source.Offset,
                NextOffset = source.NextOffset,
                RecordDateRange = source.RecordDateRange.ToList(),
                Records = source.Records
                            .Select(MapRecord)
                            .OfType<Record>()
                            .ToList(),
                AgentHints = source.AgentHints
                            .Select(MapperHelpers.MapAgentHint)
                            .OfType<AgentHint>()
                            .ToList()
            };

            return response;
        }

        private static Record? MapRecord(RecordDto? dto)
        {
            if (dto is null)
                return null;

            var record = new Record
            {
                AccountId = dto.AccountId,
                Amount = MapperHelpers.MapBalance(dto.Amount),
                BaseAmount = MapperHelpers.MapBalance(dto.BaseAmount),
                Category = dto.Category is null ? null : new Wallet.Api.Net.Models.Category.Category
                {
                    Id = MapperHelpers.ParseGuid(dto.Category.Id),
                    Name = dto.Category.Name,
                    Color = dto.Category.Color,
                    EnvelopeId = dto.Category.EnvelopeId
                },
                CreatedAt = MapperHelpers.ParseDateTime(dto.CreatedAt),
                Note = dto.Note,
                Payee = dto.Payee,
                Payer = dto.Payer,
                PaymentType = dto.PaymentType,
                Photos = dto.Photos
                            .Select(MapperHelpers.MapRecordPhoto)
                            .OfType<RecordPhoto>()
                            .ToList(),
                Place = MapperHelpers.MapPlace(dto.Place),
                RecordDate = MapperHelpers.ParseDateTime(dto.RecordDate),
                RecordState = dto.RecordState,
                RecordType = dto.RecordType,
                UpdatedAt = MapperHelpers.ParseDateTime(dto.UpdatedAt)
            };

            if (MapperHelpers.ParseGuid(dto.Id) is Guid id)
                record.Id = id;

            if (dto.Labels != null && dto.Labels.Any())
                record.Labels = dto.Labels
                                .Select(MapperHelpers.MapLabel)
                                .OfType<Label>()
                                .ToList();

            return record;
        }
    }
}

