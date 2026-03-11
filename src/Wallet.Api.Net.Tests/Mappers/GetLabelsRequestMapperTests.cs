using Wallet.Api.Net.Models;
using Wallet.Api.Net.Models.Label;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Tests
{
    public class GetLabelsRequestMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetLabelsRequestMapper();

            var result = mapper.Map(null);

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
                CreatedAt = new DateFilter { Prefix = RangePrefix.GreaterThan, Value = new DateTime(2026, 1, 5) },
                UpdatedAt = new DateFilter { Prefix = RangePrefix.LessThan, Value = new DateTime(2026, 2, 5) }
            };

            var result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.AgentHints, Is.EqualTo(source.AgentHints));
                Assert.That(result.Id, Is.EqualTo("l1,l2"));
                Assert.That(result.Name, Is.EqualTo(source.Name!.ToString()));
                Assert.That(result.CreatedAt, Is.EqualTo(source.CreatedAt!.ToString()));
                Assert.That(result.UpdatedAt, Is.EqualTo(source.UpdatedAt!.ToString()));
            }
        }
    }
}
