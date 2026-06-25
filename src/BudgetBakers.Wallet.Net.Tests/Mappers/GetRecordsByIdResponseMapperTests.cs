using BudgetBakers.Wallet.Net.Dtos;
using BudgetBakers.Wallet.Net.Dtos.Account;
using BudgetBakers.Wallet.Net.Dtos.Category;
using BudgetBakers.Wallet.Net.Dtos.Label;
using BudgetBakers.Wallet.Net.Dtos.Record;
using BudgetBakers.Wallet.Net.Models.Record;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Tests.Mappers
{
    public class GetRecordsByIdResponseMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetRecordsByIdResponseMapper();

            GetRecordsByIdResponse? result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetRecordsByIdResponseMapper();
            var recordId = Guid.NewGuid();
            var categoryId = Guid.NewGuid();
            var labelId = Guid.NewGuid();
            var source = new GetRecordsByIdResponseDto
            {
                Count = 1,
                Records = new List<RecordDto>
                {
                    new()
                    {
                        Id = recordId.ToString(),
                        AccountId = "acc-1",
                        Amount = new BalanceDto { CurrencyCode = "EUR", Value = 10.5m },
                        BaseAmount = new BalanceDto { CurrencyCode = "USD", Value = 11.5m },
                        Category = new CategoryDto { Id = categoryId.ToString(), Name = "Food", Color = "#222222", EnvelopeId = 2 },
                        CreatedAt = "2026-01-01 00:00:00",
                        Labels = new List<LabelDto> { new() { Id = labelId.ToString(), Name = "L1", CreatedAt = "2026-01-01", UpdatedAt = "2026-01-02" } },
                        Note = "note",
                        CounterParty = "store",
                        PaymentType = "debit_card",
                        Photos = new List<PhotoDto> { new() { CreatedAt = "2026-01-01 00:00:00", TemporaryUrl = "http://img" } },
                        Place = new PlaceDto { Id = "pl1", Name = "Milan", PlaceTypes = new List<int> { 1, 2 } },
                        RecordDate = "2026-01-15 00:00:00",
                        RecordState = "reconciled",
                        RecordType = "expense",
                        UpdatedAt = "2026-01-02 00:00:00"
                    }
                },
                AgentHints = new List<AgentHintDto> { new() { Severity = "info", Text = "hint", Type = "result.empty" } }
            };

            GetRecordsByIdResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            Record mapped = result!.Records[0];
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Count, Is.EqualTo(source.Count));
                Assert.That(result.Records, Has.Count.EqualTo(1));
                Assert.That(result.AgentHints, Has.Count.EqualTo(1));
                Assert.That(mapped.Id, Is.EqualTo(recordId));
                Assert.That(mapped.AccountId, Is.EqualTo(source.Records[0].AccountId));
                Assert.That(mapped.Amount?.Value, Is.EqualTo(source.Records[0].Amount?.Value));
                Assert.That(mapped.BaseAmount?.CurrencyCode, Is.EqualTo(source.Records[0].BaseAmount?.CurrencyCode));
                Assert.That(mapped.Category?.Id, Is.EqualTo(categoryId));
                Assert.That(mapped.Labels, Has.Count.EqualTo(1));
                Assert.That(mapped.Photos, Has.Count.EqualTo(1));
                Assert.That(mapped.Place?.Name, Is.EqualTo(source.Records[0].Place?.Name));
                Assert.That(mapped.RecordType, Is.EqualTo(RecordType.Expense));
            }
        }

        [Test]
        public void Map_WhenRecordsContainNullInvalidIdAndNullLabels_HandlesBranches()
        {
            var mapper = new GetRecordsByIdResponseMapper();
            var source = new GetRecordsByIdResponseDto
            {
                Count = 1,
                Records = new List<RecordDto>
                {
                    null!,
                    new RecordDto
                    {
                        Id = "invalid-guid",
                        Labels = null!,
                        Photos = new List<PhotoDto>()
                    }
                },
                AgentHints = new List<AgentHintDto>()
            };

            GetRecordsByIdResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Records, Has.Count.EqualTo(1));
                Assert.That(result.Records[0].Id, Is.Null);
                Assert.That(result.Records[0].Labels, Is.Empty);
            }
        }
    }
}
