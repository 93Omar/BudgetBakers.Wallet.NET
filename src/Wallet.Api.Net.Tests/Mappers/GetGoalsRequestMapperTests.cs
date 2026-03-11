using Wallet.Api.Net.Models;
using Wallet.Api.Net.Models.Goal;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Tests
{
    public class GetGoalsRequestMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetGoalsRequestMapper();

            var result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetGoalsRequestMapper();
            var source = new GetGoalsRequest
            {
                Limit = 8,
                Offset = 0,
                AgentHints = true,
                Ids = new List<string> { "g1", "g2" },
                Name = new TextFilter { Prefix = TextPrefix.Contains, Value = "Casa" },
                Note = new TextFilter { Prefix = TextPrefix.ContainsIgnoreCase, Value = "Mutuo" },
                CreatedAt = new DateFilter { Prefix = RangePrefix.Equals, Value = new DateTime(2026, 1, 1) },
                UpdatedAt = new DateFilter { Prefix = RangePrefix.LessThan, Value = new DateTime(2026, 2, 1) }
            };

            var result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.AgentHints, Is.EqualTo(source.AgentHints));
                Assert.That(result.Id, Is.EqualTo("g1,g2"));
                Assert.That(result.Name, Is.EqualTo(source.Name!.ToString()));
                Assert.That(result.Note, Is.EqualTo(source.Note!.ToString()));
                Assert.That(result.CreatedAt, Is.EqualTo(source.CreatedAt!.ToString()));
                Assert.That(result.UpdatedAt, Is.EqualTo(source.UpdatedAt!.ToString()));
            }
        }
    }
}
