using BudgetBakers.Wallet.Net.Dtos.Record;
using BudgetBakers.Wallet.Net.Models.Record;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class CreateRecordsRequestMapper : IMapper<CreateRecordsRequest, List<CreateRecordItemDto>>
    {
        public List<CreateRecordItemDto>? Map(CreateRecordsRequest? source)
        {
            if (source is null)
                return null;

            return source.Items
                         .Select(item => new CreateRecordItemDto
                         {
                             AccountId = item.AccountId,
                             Amount = new RecordAmountDto
                             {
                                 Value = item.Amount.Value,
                                 CurrencyCode = item.Amount.CurrencyCode
                             },
                             RecordDate = item.RecordDate,
                             PaymentType = item.PaymentType.ToApiString(),
                             CategoryId = item.CategoryId,
                             CounterParty = item.CounterParty,
                             Note = item.Note,
                             LabelIds = item.LabelIds,
                             RecordState = item.RecordState?.ToApiString(),
                             Place = MapPlace(item.Place)
                         })
                         .ToList();
        }

        private static RecordPlaceInputDto? MapPlace(RecordPlaceInput? source)
        {
            if (source is null)
                return null;

            return new RecordPlaceInputDto
            {
                Address = source.Address,
                Latitude = source.Latitude,
                Longitude = source.Longitude,
                Name = source.Name
            };
        }
    }
}
