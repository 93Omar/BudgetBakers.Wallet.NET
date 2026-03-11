using Wallet.Api.Net.Models.Record;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Tests.Mappers
{
    public class GetRecordsByIdRequestMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetRecordsByIdRequestMapper();

            var result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetRecordsByIdRequestMapper();
            var source = new GetRecordsByIdRequest
            {
                AgentHints = true,
                Ids = new List<string> { "1", "2" }
            };

            var result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.AgentHints, Is.EqualTo(source.AgentHints));
                Assert.That(result.Id, Is.EqualTo("1,2"));
            }
        }
    }
}
