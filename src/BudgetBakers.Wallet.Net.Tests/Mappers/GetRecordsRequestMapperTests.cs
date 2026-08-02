using BudgetBakers.Wallet.Net.Dtos.Record;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Record;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Tests.Mappers
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
                AccountIds = new List<string> { "acc-1", "acc-2" },
                RecordDate = new DateFilter { Prefix = RangePrefix.Equals, Value = new DateTime(2026, 3, 1) },
                Limit = 5,
                Offset = 2,
                AgentHints = true,
                CategoryId = "cat-1",
                LabelId = "lab-1",
                Note = new TextFilter { Prefix = TextPrefix.Contains, Value = "expense" },
                CounterParty = new TextFilter { Prefix = TextPrefix.Equals, Value = "market" },
                Amount = new NumberFilter { Prefix = RangePrefix.GreaterThanOrEqual, Value = 120.0 },
                CreatedAt = new DateFilter { Prefix = RangePrefix.GreaterThanOrEqual, Value = new DateTime(2026, 1, 1) },
                UpdatedAt = new DateFilter { Prefix = RangePrefix.LessThanOrEqual, Value = new DateTime(2026, 3, 1) },
                IsTransfer = true,
                TransferIds = new List<string> { "transfer-1", "transfer-2" },
                SortBy = RecordSortBy.RecordDateDescending
            };

            GetRecordsRequestDto? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.AccountId, Is.EqualTo("acc-1,acc-2"));
                Assert.That(result.RecordDate, Is.EqualTo(source.RecordDate!.ToString()));
                Assert.That(result.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.AgentHints, Is.EqualTo(source.AgentHints));
                Assert.That(result.CategoryId, Is.EqualTo(source.CategoryId));
                Assert.That(result.LabelId, Is.EqualTo(source.LabelId));
                Assert.That(result.Note, Is.EqualTo(source.Note!.ToString()));
                Assert.That(result.CounterParty, Is.EqualTo(source.CounterParty!.ToString()));
                Assert.That(result.Amount, Is.EqualTo(source.Amount!.ToString()));
                Assert.That(result.CreatedAt, Is.EqualTo(source.CreatedAt!.ToString()));
                Assert.That(result.UpdatedAt, Is.EqualTo(source.UpdatedAt!.ToString()));
                Assert.That(result.IsTransfer, Is.EqualTo(source.IsTransfer));
                Assert.That(result.TransferId, Is.EqualTo("transfer-1,transfer-2"));
                Assert.That(result.SortBy, Is.EqualTo("-recordDate"));
            }
        }
    }
}
