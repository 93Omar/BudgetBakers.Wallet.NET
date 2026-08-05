using BudgetBakers.Wallet.Net.Dtos.StandingOrder;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.StandingOrder;
using BudgetBakers.Wallet.Net.Services.Mappers;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Tests.Mappers
{
    public class GetStandingOrdersRequestMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetStandingOrdersRequestMapper();

            GetStandingOrdersRequestDto? result = mapper.Map(null);

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
                Name = new TextFilter { Prefix = TextPrefix.Contains, Value = "Rent" },
                CurrencyCode = "EUR",
                CreatedAt = new List<DateFilter>
                {
                    new() { Prefix = RangePrefix.GreaterThanOrEqual, Value = new DateTime(2026, 1, 1) }
                },
                UpdatedAt = new List<DateFilter>
                {
                    new() { Prefix = RangePrefix.GreaterThanOrEqual, Value = new DateTime(2026, 1, 1) },
                    new() { Prefix = RangePrefix.LessThanOrEqual, Value = new DateTime(2026, 1, 31) }
                }
            };

            GetStandingOrdersRequestDto? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.AgentHints, Is.EqualTo(source.AgentHints));
                Assert.That(result.Id, Is.EqualTo("so1,so2"));
                Assert.That(result.Name, Is.EqualTo(source.Name!.ToString()));
                Assert.That(result.CurrencyCode, Is.EqualTo(source.CurrencyCode));
                Assert.That(result.CreatedAt, Is.EqualTo(MapperHelpers.JoinFilters(source.CreatedAt)));
                Assert.That(result.UpdatedAt, Is.EqualTo(MapperHelpers.JoinFilters(source.UpdatedAt)));
            }
        }
    }
}
