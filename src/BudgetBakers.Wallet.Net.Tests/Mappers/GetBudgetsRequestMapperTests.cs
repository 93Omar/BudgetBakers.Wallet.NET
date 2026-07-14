using BudgetBakers.Wallet.Net.Dtos.Budget;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Budget;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Tests.Mappers
{
    public class GetBudgetsRequestMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetBudgetsRequestMapper();

            GetBudgetsRequestDto? result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetBudgetsRequestMapper();
            var source = new GetBudgetsRequest
            {
                Limit = 10,
                Offset = 2,
                AgentHints = true,
                Ids = new List<string> { "b1", "b2" },
                Name = new TextFilter { Prefix = TextPrefix.Contains, Value = "budget" },
                CurrencyCode = "EUR",
                StartDate = new DateOnlyFilter { Prefix = RangePrefix.GreaterThanOrEqual, Value = new DateOnly(2026, 1, 1) },
                EndDate = new DateOnlyFilter { Prefix = RangePrefix.LessThanOrEqual, Value = new DateOnly(2026, 12, 31) },
                CreatedAt = new DateFilter { Prefix = RangePrefix.GreaterThan, Value = new DateTime(2026, 1, 1) },
                UpdatedAt = new DateFilter { Prefix = RangePrefix.LessThan, Value = new DateTime(2026, 2, 1) }
            };

            GetBudgetsRequestDto? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.AgentHints, Is.EqualTo(source.AgentHints));
                Assert.That(result.Id, Is.EqualTo("b1,b2"));
                Assert.That(result.Name, Is.EqualTo(source.Name!.ToString()));
                Assert.That(result.CurrencyCode, Is.EqualTo(source.CurrencyCode));
                Assert.That(result.StartDate, Is.EqualTo(source.StartDate!.ToString()));
                Assert.That(result.EndDate, Is.EqualTo(source.EndDate!.ToString()));
                Assert.That(result.CreatedAt, Is.EqualTo(source.CreatedAt!.ToString()));
                Assert.That(result.UpdatedAt, Is.EqualTo(source.UpdatedAt!.ToString()));
            }
        }
    }
}
