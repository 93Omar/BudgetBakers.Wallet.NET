using BudgetBakers.Wallet.Net.Dtos;
using BudgetBakers.Wallet.Net.Dtos.Account;
using BudgetBakers.Wallet.Net.Dtos.Category;
using BudgetBakers.Wallet.Net.Dtos.Label;
using BudgetBakers.Wallet.Net.Dtos.Record;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Record;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Tests.Mappers
{
    public class GetRecordsResponseMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetRecordsResponseMapper();

            GetRecordsResponse? result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetRecordsResponseMapper();
            var recordId = Guid.NewGuid().ToString();
            var categoryId = Guid.NewGuid().ToString();
            var labelId = Guid.NewGuid().ToString();
            var source = new GetRecordsResponseDto
            {
                Limit = 3,
                Offset = 0,
                NextOffset = 3,
                AppliedRecordDateFilters = new List<string> { "gte.2026-01-01T00:00:00Z", "lt.2026-01-31T00:00:00Z" },
                Records = new List<RecordDto>
                {
                    new()
                    {
                        Id = recordId.ToString(),
                        AccountId = "acc-1",
                        Amount = new BalanceDto { CurrencyCode = "EUR", Value = 10.5m },
                        Category = new CategoryDto { Id = categoryId.ToString(), Name = "Food", Color = "#222222" },
                        CreatedAt = "2026-01-01 00:00:00",
                        Labels = new List<LabelDto> { new() { Id = labelId.ToString(), Name = "L1", CreatedAt = "2026-01-01", UpdatedAt = "2026-01-02" } },
                        Note = "note",
                        CounterParty = "store",
                        Photos = new List<PhotoDto> { new() { CreatedAt = "2026-01-01 00:00:00", TemporaryUrl = "http://img" } },
                        Place = new PlaceDto { Id = "pl1", Name = "Milan", PlaceTypes = new List<int> { 1, 2 } },
                        RecordDate = "2026-01-15 00:00:00",
                        RecordState = "reconciled",
                        RecordType = "expense",
                        Transfer = new TransferOutputDto
                        {
                            Type = "paired",
                            MirrorRecord = new MirrorRecordEmbedDto
                            {
                                AccountId = "acc-2",
                                Amount = new AmountWithCurrencyDto { CurrencyCode = "EUR", Value = -10.5m },
                                CounterParty = "store",
                                Id = "mirror-id",
                                Note = "mirror note"
                            }
                        },
                        UpdatedAt = "2026-01-02 00:00:00"
                    }
                },
                AgentHints = new List<AgentHintDto> { new() { Severity = "info", Text = "hint", Type = "result.empty" } }
            };

            GetRecordsResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            Record mapped = result!.Records[0];
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Pagination.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Pagination.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.Pagination.NextOffset, Is.EqualTo(source.NextOffset));
                Assert.That(result.AppliedRecordDateFilters, Has.Count.EqualTo(2));
                Assert.That(result.AppliedRecordDateFilters[0].Prefix, Is.EqualTo(RangePrefix.GreaterThanOrEqual));
                Assert.That(result.AppliedRecordDateFilters[0].Value.ToUniversalTime(), Is.EqualTo(new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)));
                Assert.That(result.AppliedRecordDateFilters[1].Prefix, Is.EqualTo(RangePrefix.LessThan));
                Assert.That(result.AppliedRecordDateFilters[1].Value.ToUniversalTime(), Is.EqualTo(new DateTime(2026, 1, 31, 0, 0, 0, DateTimeKind.Utc)));
                Assert.That(result.Records, Has.Count.EqualTo(1));
                Assert.That(result.AgentHints, Has.Count.EqualTo(1));
                Assert.That(mapped.Id, Is.EqualTo(recordId));
                Assert.That(mapped.AccountId, Is.EqualTo(source.Records[0].AccountId));
                Assert.That(mapped.Amount?.Value, Is.EqualTo(source.Records[0].Amount?.Value));
                Assert.That(mapped.Category?.Id, Is.EqualTo(categoryId));
                Assert.That(mapped.Labels, Has.Count.EqualTo(1));
                Assert.That(mapped.Photos, Has.Count.EqualTo(1));
                Assert.That(mapped.Place?.Name, Is.EqualTo(source.Records[0].Place?.Name));
                Assert.That(mapped.RecordType, Is.EqualTo(RecordType.Expense));
                Assert.That(mapped.Transfer?.Type, Is.EqualTo(TransferType.Paired));
                Assert.That(mapped.Transfer?.MirrorRecord?.Id, Is.EqualTo("mirror-id"));
                Assert.That(mapped.Transfer?.MirrorRecord?.Amount?.Value, Is.EqualTo(-10.5));
            }
        }

        [Test]
        public void Map_WhenRecordsContainNullInvalidIdAndNullLabels_HandlesBranches()
        {
            var mapper = new GetRecordsResponseMapper();
            var source = new GetRecordsResponseDto
            {
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

            GetRecordsResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Records, Has.Count.EqualTo(1));
                Assert.That(result.Records[0].Id, Is.EqualTo("invalid-guid"));
                Assert.That(result.Records[0].Labels, Is.Empty);
            }
        }
    }
}
