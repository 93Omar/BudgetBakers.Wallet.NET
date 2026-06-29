using BudgetBakers.Wallet.Net.Dtos.Category;
using BudgetBakers.Wallet.Net.Dtos.Label;
using BudgetBakers.Wallet.Net.Dtos.RecordRule;
using BudgetBakers.Wallet.Net.Models.RecordRule;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Tests.Mappers
{
    public class GetRecordRulesResponseMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetRecordRulesResponseMapper();

            GetRecordRulesResponse? result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetRecordRulesResponseMapper();
            var ruleId = Guid.NewGuid().ToString();
            var fromId = Guid.NewGuid().ToString();
            var toId = Guid.NewGuid().ToString();

            var source = new GetRecordRulesResponseDto
            {
                Limit = 6,
                Offset = 0,
                NextOffset = 6,
                RecordRules = new List<RecordRuleDto>
                {
                    new()
                    {
                        Id = ruleId.ToString(),
                        Name = "Test rule",
                        FromAccountId = fromId.ToString(),
                        ToAccountId = toId.ToString(),
                        CreatedAt = "2026-01-01 00:00:00",
                        UpdatedAt = "2026-01-02 00:00:00",
                        Keywords = new List<string> { "foo", "bar" },
                        Category = new CategoryDto { Name = "Food", Color = "#111111" },
                        Labels = new List<LabelDto>
                        {
                            new() { Id = Guid.NewGuid().ToString(), Name = "Label", CreatedAt = "2026-01-01", UpdatedAt = "2026-01-02" }
                        }
                    }
                },
                AgentHints = new List<BudgetBakers.Wallet.Net.Dtos.Account.AgentHintDto>
                {
                    new() { Severity = "info", Text = "hint", Type = "result.empty" }
                }
            };

            GetRecordRulesResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            RecordRule mapped = result!.RecordRules[0];
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Pagination.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Pagination.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.Pagination.NextOffset, Is.EqualTo(source.NextOffset));
                Assert.That(result.RecordRules, Has.Count.EqualTo(1));
                Assert.That(result.AgentHints, Has.Count.EqualTo(1));
                Assert.That(mapped.Id, Is.EqualTo(ruleId));
                Assert.That(mapped.FromAccountId, Is.EqualTo(fromId));
                Assert.That(mapped.ToAccountId, Is.EqualTo(toId));
                Assert.That(mapped.Name, Is.EqualTo(source.RecordRules[0].Name));
                Assert.That(mapped.Keywords, Is.EquivalentTo(source.RecordRules[0].Keywords));
                Assert.That(mapped.Category?.Name, Is.EqualTo(source.RecordRules[0].Category?.Name));
                Assert.That(mapped.Labels, Has.Count.EqualTo(1));
            }
        }

        [Test]
        public void Map_WhenRecordRulesContainNullAndInvalidId_FiltersNullAndLeavesIdNull()
        {
            var mapper = new GetRecordRulesResponseMapper();
            var source = new GetRecordRulesResponseDto
            {
                RecordRules = new List<RecordRuleDto>
                {
                    null!,
                    new RecordRuleDto
                    {
                        Id = "invalid-guid",
                        Keywords = new List<string>(),
                        Labels = new List<LabelDto>()
                    }
                },
                AgentHints = new List<BudgetBakers.Wallet.Net.Dtos.Account.AgentHintDto>()
            };

            GetRecordRulesResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.RecordRules, Has.Count.EqualTo(1));
                Assert.That(result.RecordRules[0].Id, Is.EqualTo("invalid-guid"));
            }
        }
    }
}
