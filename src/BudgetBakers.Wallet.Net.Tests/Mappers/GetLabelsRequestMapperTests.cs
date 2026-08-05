using BudgetBakers.Wallet.Net.Dtos.Label;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Label;
using BudgetBakers.Wallet.Net.Services.Mappers;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Tests.Mappers
{
    public class GetLabelsRequestMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetLabelsRequestMapper();

            GetLabelsRequestDto? result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetLabelsRequestMapper();
            var source = new GetLabelsRequest
            {
                Limit = 9,
                Offset = 4,
                AgentHints = true,
                Ids = new List<string> { "l1", "l2" },
                Name = new TextFilter { Prefix = TextPrefix.Contains, Value = "tag" },
                CreatedAt = new List<DateFilter>
                {
                    new() { Prefix = RangePrefix.GreaterThan, Value = new DateTime(2026, 1, 5) }
                },
                UpdatedAt = new List<DateFilter>
                {
                    new() { Prefix = RangePrefix.GreaterThan, Value = new DateTime(2026, 1, 5) },
                    new() { Prefix = RangePrefix.LessThan, Value = new DateTime(2026, 2, 5) }
                }
            };

            GetLabelsRequestDto? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.AgentHints, Is.EqualTo(source.AgentHints));
                Assert.That(result.Id, Is.EqualTo("l1,l2"));
                Assert.That(result.Name, Is.EqualTo(source.Name!.ToString()));
                Assert.That(result.CreatedAt, Is.EqualTo(MapperHelpers.JoinFilters(source.CreatedAt)));
                Assert.That(result.UpdatedAt, Is.EqualTo(MapperHelpers.JoinFilters(source.UpdatedAt)));
            }
        }
    }
}
