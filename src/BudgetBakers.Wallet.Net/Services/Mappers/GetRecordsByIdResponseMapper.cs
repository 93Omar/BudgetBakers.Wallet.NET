using System;
using System.Linq;
using BudgetBakers.Wallet.Net.Dtos.Record;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Label;
using BudgetBakers.Wallet.Net.Models.Record;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class GetRecordsByIdResponseMapper : IMapper<GetRecordsByIdResponseDto, GetRecordsByIdResponse>
    {
        public GetRecordsByIdResponse? Map(GetRecordsByIdResponseDto? source)
        {
            if (source is null)
                return null;

            GetRecordsByIdResponse response = new GetRecordsByIdResponse
            {
                Count = source.Count,
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

            Record record = new Record
            {
                AccountId = dto.AccountId,
                Amount = MapperHelpers.MapBalance(dto.Amount),
                BaseAmount = MapperHelpers.MapBalance(dto.BaseAmount),
                Category = dto.Category is null ? null : new BudgetBakers.Wallet.Net.Models.Category.Category
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
                PaymentType = MapperHelpers.ParsePaymentType(dto.PaymentType),
                Photos = dto.Photos
                            .Select(MapperHelpers.MapRecordPhoto)
                            .OfType<RecordPhoto>()
                            .ToList(),
                Place = MapperHelpers.MapPlace(dto.Place),
                RecordDate = MapperHelpers.ParseDateTime(dto.RecordDate),
                RecordState = MapperHelpers.ParseRecordState(dto.RecordState),
                RecordType = MapperHelpers.ParseRecordType(dto.RecordType),
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

