using BudgetBakers.Wallet.Net.Dtos;
using BudgetBakers.Wallet.Net.Dtos.Record;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Record;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Mappers
{
    internal class UpdateRecordsRequestMapper : IMapper<UpdateRecordsRequest, List<UpdateRecordItemDto>>
    {
        public List<UpdateRecordItemDto>? Map(UpdateRecordsRequest? source)
        {
            if (source is null)
                return null;

            return source.Items
                         .Select(item => new UpdateRecordItemDto
                         {
                             Id = item.Id,
                             AccountId = item.AccountId,
                             Amount = item.Amount is null ? null : new RecordAmountDto
                             {
                                 Value = item.Amount.Value,
                                 CurrencyCode = item.Amount.CurrencyCode
                             },
                             RecordDate = item.RecordDate,
                             RecordState = item.RecordState?.ToApiString(),
                             CategoryId = item.CategoryId,
                             CounterParty = item.CounterParty,
                             Note = item.Note,
                             LabelIds = MapIdsOperation(item.LabelIds),
                             Clear = item.Clear?.Select(clearField => clearField.ToApiString()).ToList(),
                             Place = MapPlace(item.Place)
                         })
                         .ToList();
        }

        private static IdsOperationDto? MapIdsOperation(IdsOperation? source)
        {
            if (source is null)
                return null;

            return new IdsOperationDto
            {
                ReplaceWith = source.ReplaceWith,
                Add = source.Add,
                Remove = source.Remove
            };
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
