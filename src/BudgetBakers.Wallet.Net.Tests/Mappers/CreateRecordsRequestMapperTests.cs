using BudgetBakers.Wallet.Net.Dtos.Record;
using BudgetBakers.Wallet.Net.Models.Record;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Tests.Mappers
{
    public class CreateRecordsRequestMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new CreateRecordsRequestMapper();

            List<CreateRecordItemDto>? result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenTransferIsProvided_MapsTransferFields()
        {
            var mapper = new CreateRecordsRequestMapper();
            var source = new CreateRecordsRequest
            {
                Items = new List<CreateRecordItem>
                {
                    new()
                    {
                        AccountId = "acc-1",
                        Amount = new RecordAmount { Value = -10 },
                        RecordDate = DateTime.UtcNow,
                        Transfer = new CreateRecordTransferInput
                        {
                            PairingMode = TransferPairingMode.New,
                            AccountId = "acc-2",
                            CounterAmount = new RecordAmount { Value = 10, CurrencyCode = "EUR" }
                        }
                    }
                }
            };

            List<CreateRecordItemDto>? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            CreateRecordItemDto mapped = result![0];
            using (Assert.EnterMultipleScope())
            {
                Assert.That(mapped.Transfer, Is.Not.Null);
                Assert.That(mapped.Transfer!.PairingMode, Is.EqualTo("new"));
                Assert.That(mapped.Transfer.AccountId, Is.EqualTo("acc-2"));
                Assert.That(mapped.Transfer.CounterAmount?.Value, Is.EqualTo(10));
                Assert.That(mapped.Transfer.CounterAmount?.CurrencyCode, Is.EqualTo("EUR"));
            }
        }

        [Test]
        public void Map_WhenTransferIsNull_MapsNullTransfer()
        {
            var mapper = new CreateRecordsRequestMapper();
            var source = new CreateRecordsRequest
            {
                Items = new List<CreateRecordItem>
                {
                    new()
                    {
                        AccountId = "acc-1",
                        Amount = new RecordAmount { Value = -10 },
                        RecordDate = DateTime.UtcNow
                    }
                }
            };

            List<CreateRecordItemDto>? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            CreateRecordItemDto mapped = result![0];
            Assert.That(mapped.Transfer, Is.Null);
        }
    }
}
