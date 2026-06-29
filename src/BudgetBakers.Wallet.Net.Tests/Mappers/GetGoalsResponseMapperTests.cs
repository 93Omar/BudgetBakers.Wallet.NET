using BudgetBakers.Wallet.Net.Dtos;
using BudgetBakers.Wallet.Net.Dtos.Account;
using BudgetBakers.Wallet.Net.Dtos.Goal;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Goal;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Tests.Mappers
{
    public class GetGoalsResponseMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetGoalsResponseMapper();

            GetGoalsResponse? result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetGoalsResponseMapper();
            var goalId = Guid.NewGuid().ToString();
            var source = new GetGoalsResponseDto
            {
                Limit = 7,
                Offset = 2,
                NextOffset = 9,
                Goals = new List<GoalDto>
                {
                    new()
                    {
                        Id = goalId,
                        Color = "#AA00BB",
                        CreatedAt = "2026-01-01 00:00:00",
                        DesiredDate = "2026-12-31",
                        InitialAmount = new AmountWithCurrencyDto { CurrencyCode = "USD", Value = 5000 },
                        Name = "House",
                        Note = "Down payment",
                        State = "active",
                        StateUpdatedAt = "2026-01-10",
                        TargetAmount = new AmountWithCurrencyDto { CurrencyCode = "USD", Value = 20000 },
                        UpdatedAt = "2026-01-02 00:00:00"
                    }
                },
                AgentHints = new List<AgentHintDto> { new() { Severity = "info", Text = "hint", Type = "result.empty" } }
            };

            GetGoalsResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            Goal mapped = result!.Goals[0];
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.Pagination.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Pagination.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.Pagination.NextOffset, Is.EqualTo(source.NextOffset));
                Assert.That(result.Goals, Has.Count.EqualTo(1));
                Assert.That(result.AgentHints, Has.Count.EqualTo(1));
                Assert.That(mapped.Id, Is.EqualTo(goalId));
                Assert.That(mapped.DesiredDate, Is.EqualTo(new DateTime(2026, 12, 31)));
                Assert.That(mapped.Name, Is.EqualTo(source.Goals[0].Name));
                Assert.That(mapped.Note, Is.EqualTo(source.Goals[0].Note));
                Assert.That(mapped.TargetAmount?.Value, Is.EqualTo(source.Goals[0].TargetAmount?.Value));
                Assert.That(mapped.TargetAmount?.CurrencyCode, Is.EqualTo(source.Goals[0].TargetAmount?.CurrencyCode));
                Assert.That(mapped.InitialAmount?.Value, Is.EqualTo(source.Goals[0].InitialAmount?.Value));
                Assert.That(mapped.InitialAmount?.CurrencyCode, Is.EqualTo(source.Goals[0].InitialAmount?.CurrencyCode));
            }
        }

        [Test]
        public void Map_WhenGoalsContainNullAndStringId_FiltersNullAndKeepsId()
        {
            var mapper = new GetGoalsResponseMapper();
            var source = new GetGoalsResponseDto
            {
                Goals = new List<GoalDto>
                {
                    null!,
                    new GoalDto { Id = "invalid-guid", Name = "No Guid" }
                },
                AgentHints = new List<AgentHintDto>()
            };

            GetGoalsResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Goals, Has.Count.EqualTo(1));
                Assert.That(result.Goals[0].Id, Is.EqualTo("invalid-guid"));
            }
        }
    }
}

