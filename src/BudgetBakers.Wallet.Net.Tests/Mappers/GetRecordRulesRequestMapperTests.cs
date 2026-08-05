using BudgetBakers.Wallet.Net.Dtos.RecordRule;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.RecordRule;
using BudgetBakers.Wallet.Net.Services.Mappers;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Tests.Mappers
{
    public class GetRecordRulesRequestMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetRecordRulesRequestMapper();

            GetRecordRulesRequestDto? result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetRecordRulesRequestMapper();
            var source = new GetRecordRulesRequest
            {
                Limit = 10,
                Offset = 0,
                AgentHints = true,
                Ids = new List<string> { "r1", "r2" },
                Name = new TextFilter { Prefix = TextPrefix.Equals, Value = "Rule" },
                CreatedAt = new List<DateFilter>
                {
                    new() { Prefix = RangePrefix.Equals, Value = new DateTime(2026, 1, 1) }
                },
                UpdatedAt = new List<DateFilter>
                {
                    new() { Prefix = RangePrefix.Equals, Value = new DateTime(2026, 1, 2) }
                }
            };

            GetRecordRulesRequestDto? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.AgentHints, Is.EqualTo(source.AgentHints));
                Assert.That(result.Id, Is.EqualTo("r1,r2"));
                Assert.That(result.Name, Is.EqualTo(source.Name!.ToString()));
                Assert.That(result.CreatedAt, Is.EqualTo(MapperHelpers.JoinFilters(source.CreatedAt)));
                Assert.That(result.UpdatedAt, Is.EqualTo(MapperHelpers.JoinFilters(source.UpdatedAt)));
            }
        }
    }
}
