using Wallet.Api.Net.Dtos;
using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Dtos.Category;
using Wallet.Api.Net.Dtos.Label;
using Wallet.Api.Net.Dtos.Record;
using Wallet.Api.Net.Models.Record;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Tests.Mappers
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
            var recordId = Guid.NewGuid();
            var categoryId = Guid.NewGuid();
            var labelId = Guid.NewGuid();
            var source = new GetRecordsResponseDto
            {
                Limit = 3,
                Offset = 0,
                NextOffset = 3,
                RecordDateRange = new List<string> { "2026-01-01", "2026-01-31" },
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
                        Note = "nota",
                        Payee = "negozio",
                        Payer = "io",
                        PaymentType = "card",
                        Photos = new List<PhotoDto> { new() { CreatedAt = "2026-01-01 00:00:00", TemporaryUrl = "http://img" } },
                        Place = new PlaceDto { Id = "pl1", Name = "Milano", PlaceTypes = new List<int> { 1, 2 } },
                        RecordDate = "2026-01-15 00:00:00",
                        RecordState = "booked",
                        RecordType = "expense",
                        UpdatedAt = "2026-01-02 00:00:00"
                    }
                },
                AgentHints = new List<AgentHintDto> { new() { Text = "hint" } }
            };

            GetRecordsResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            Record mapped = result!.Records[0];
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.NextOffset, Is.EqualTo(source.NextOffset));
                Assert.That(result.RecordDateRange, Is.EqualTo(source.RecordDateRange));
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
                Assert.That(mapped.RecordType, Is.EqualTo(source.Records[0].RecordType));
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
                Assert.That(result.Records[0].Id, Is.Null);
                Assert.That(result.Records[0].Labels, Is.Empty);
            }
        }
    }
}
