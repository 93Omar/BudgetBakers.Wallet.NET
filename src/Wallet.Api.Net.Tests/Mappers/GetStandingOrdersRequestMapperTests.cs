using Wallet.Api.Net.Models;
using Wallet.Api.Net.Models.StandingOrder;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Tests.Mappers
{
    public class GetStandingOrdersRequestMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetStandingOrdersRequestMapper();

            var result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetStandingOrdersRequestMapper();
            var source = new GetStandingOrdersRequest
            {
                Limit = 4,
                Offset = 1,
                AgentHints = true,
                Ids = new List<string> { "so1", "so2" },
                Name = "Affitto",
                CurrencyCode = "EUR",
                CreatedAt = new DateFilter { Prefix = RangePrefix.GreaterThanOrEqual, Value = new DateTime(2026, 1, 1) },
                UpdatedAt = new DateFilter { Prefix = RangePrefix.LessThanOrEqual, Value = new DateTime(2026, 1, 31) }
            };

            var result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.AgentHints, Is.EqualTo(source.AgentHints));
                Assert.That(result.Id, Is.EqualTo("so1,so2"));
                Assert.That(result.Name, Is.EqualTo(source.Name));
                Assert.That(result.CurrencyCode, Is.EqualTo(source.CurrencyCode));
                Assert.That(result.CreatedAt, Is.EqualTo(source.CreatedAt!.ToString()));
                Assert.That(result.UpdatedAt, Is.EqualTo(source.UpdatedAt!.ToString()));
            }
        }
    }
}
