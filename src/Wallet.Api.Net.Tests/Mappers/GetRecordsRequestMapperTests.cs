using Wallet.Api.Net.Dtos.Record;
using Wallet.Api.Net.Models;
using Wallet.Api.Net.Models.Record;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Tests.Mappers
{
    public class GetRecordsRequestMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetRecordsRequestMapper();

            GetRecordsRequestDto? result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetRecordsRequestMapper();
            var source = new GetRecordsRequest
            {
                AccountId = "acc-1",
                RecordDate = new DateFilter { Prefix = RangePrefix.Equals, Value = new DateTime(2026, 3, 1) },
                Limit = 5,
                Offset = 2,
                AgentHints = true,
                CategoryId = "cat-1",
                LabelId = "lab-1",
                Note = new TextFilter { Prefix = TextPrefix.Contains, Value = "spesa" },
                Payee = new TextFilter { Prefix = TextPrefix.Equals, Value = "market" },
                Amount = "120",
                CreatedAt = new DateFilter { Prefix = RangePrefix.GreaterThanOrEqual, Value = new DateTime(2026, 1, 1) },
                UpdatedAt = new DateFilter { Prefix = RangePrefix.LessThanOrEqual, Value = new DateTime(2026, 3, 1) },
                SortBy = "recordDate.desc"
            };

            GetRecordsRequestDto? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.AccountId, Is.EqualTo(source.AccountId));
                Assert.That(result.RecordDate, Is.EqualTo(source.RecordDate!.ToString()));
                Assert.That(result.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.AgentHints, Is.EqualTo(source.AgentHints));
                Assert.That(result.CategoryId, Is.EqualTo(source.CategoryId));
                Assert.That(result.LabelId, Is.EqualTo(source.LabelId));
                Assert.That(result.Note, Is.EqualTo(source.Note!.ToString()));
                Assert.That(result.Payee, Is.EqualTo(source.Payee!.ToString()));
                Assert.That(result.Amount, Is.EqualTo(source.Amount));
                Assert.That(result.CreatedAt, Is.EqualTo(source.CreatedAt!.ToString()));
                Assert.That(result.UpdatedAt, Is.EqualTo(source.UpdatedAt!.ToString()));
                Assert.That(result.SortBy, Is.EqualTo(source.SortBy));
            }
        }
    }
}
