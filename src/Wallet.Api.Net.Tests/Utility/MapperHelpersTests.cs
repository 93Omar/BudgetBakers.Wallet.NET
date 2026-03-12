using Wallet.Api.Net.Dtos;
using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Dtos.Label;
using Wallet.Api.Net.Dtos.Record;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Tests.Utility
{
    public class MapperHelpersTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ParseGuid_WhenInputIsNullOrWhitespace_ReturnsNull(string? value)
        {
            Guid? result = MapperHelpers.ParseGuid(value);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void ParseGuid_WhenInputIsInvalid_ReturnsNull()
        {
            Guid? result = MapperHelpers.ParseGuid("not-a-guid");

            Assert.That(result, Is.Null);
        }

        [Test]
        public void ParseGuid_WhenInputIsValid_ReturnsGuid()
        {
            Guid expected = Guid.NewGuid();

            Guid? result = MapperHelpers.ParseGuid(expected.ToString());

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("invalid-date")]
        public void ParseDateTime_WhenInputIsNullWhitespaceOrInvalid_ReturnsNull(string? value)
        {
            DateTime? result = MapperHelpers.ParseDateTime(value);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void ParseDateTime_WhenInputIsValid_ReturnsDateTime()
        {
            DateTime? result = MapperHelpers.ParseDateTime("2026-01-01 10:00:00");

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void MapAgentHint_WhenDtoIsNull_ReturnsNull()
        {
            AgentHintDto? dto = null;

            var result = MapperHelpers.MapAgentHint(dto);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void MapAgentHint_WhenActionIsNull_MapsWithoutAction()
        {
            var result = MapperHelpers.MapAgentHint(new AgentHintDto
            {
                Action = null,
                Data = "data",
                Severity = "high",
                Text = "text",
                Type = "type"
            });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result!.Action, Is.Null);
                Assert.That(result.Text, Is.EqualTo("text"));
            }
        }

        [Test]
        public void MapAgentHint_WhenActionIsPresent_MapsAction()
        {
            var result = MapperHelpers.MapAgentHint(new AgentHintDto
            {
                Action = new AgentActionDto { Url = "https://example.test" }
            });

            Assert.That(result!.Action!.Url, Is.EqualTo("https://example.test"));
        }

        [Test]
        public void MapBalance_WhenDtoIsNull_ReturnsNull()
        {
            BalanceDto? dto = null;

            var result = MapperHelpers.MapBalance(dto);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void MapBalance_WhenDtoIsValid_MapsValues()
        {
            var result = MapperHelpers.MapBalance(new BalanceDto
            {
                CurrencyCode = "EUR",
                Value = 10.5m
            });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result!.CurrencyCode, Is.EqualTo("EUR"));
                Assert.That(result.Value, Is.EqualTo(10.5m));
            }
        }

        [Test]
        public void MapLabel_WhenIdIsValid_SetsId()
        {
            Guid id = Guid.NewGuid();

            var result = MapperHelpers.MapLabel(new LabelDto
            {
                Id = id.ToString(),
                Name = "label"
            });

            Assert.That(result!.Id, Is.EqualTo(id));
        }

        [Test]
        public void MapLabel_WhenIdIsInvalid_DoesNotSetId()
        {
            var result = MapperHelpers.MapLabel(new LabelDto
            {
                Id = "invalid-guid",
                Name = "label"
            });

            Assert.That(result!.Id, Is.Null);
        }

        [Test]
        public void MapLabel_WhenDtoIsNull_ReturnsNull()
        {
            LabelDto? dto = null;

            var result = MapperHelpers.MapLabel(dto);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void MapRecordPhoto_WhenDtoIsNull_ReturnsNull()
        {
            PhotoDto? dto = null;

            var result = MapperHelpers.MapRecordPhoto(dto);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void MapPlace_WhenDtoIsNull_ReturnsNull()
        {
            PlaceDto? dto = null;

            var result = MapperHelpers.MapPlace(dto);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void MapPlace_WhenPlaceTypesIsNull_MapsEmptyList()
        {
            var dto = new PlaceDto
            {
                Name = "Office",
                PlaceTypes = null!
            };

            var result = MapperHelpers.MapPlace(dto);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result!.PlaceTypes, Is.Not.Null);
                Assert.That(result.PlaceTypes, Is.Empty);
            }
        }

        [Test]
        public void MapDateRange_WhenDtoIsNull_ReturnsNull()
        {
            DateRangeDto? dto = null;

            var result = MapperHelpers.MapDateRange(dto);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void MapRecordStats_WhenDtoIsNull_ReturnsNull()
        {
            RecordStatsDto? dto = null;

            var result = MapperHelpers.MapRecordStats(dto);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void MapRecordStats_WhenNestedRangesArePresent_MapsValues()
        {
            var dto = new RecordStatsDto
            {
                RecordCount = 5,
                CreatedAt = new DateRangeDto { Min = "2026-01-01", Max = "2026-01-31" },
                RecordDate = new DateRangeDto { Min = "2026-02-01", Max = "2026-02-28" }
            };

            var result = MapperHelpers.MapRecordStats(dto);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result!.RecordCount, Is.EqualTo(5));
                Assert.That(result.CreatedAt, Is.Not.Null);
                Assert.That(result.RecordDate, Is.Not.Null);
            }
        }
    }
}
