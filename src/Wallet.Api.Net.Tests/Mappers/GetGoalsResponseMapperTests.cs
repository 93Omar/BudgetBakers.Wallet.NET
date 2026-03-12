using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Dtos.Goal;
using Wallet.Api.Net.Models.Goal;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Tests.Mappers
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
            var goalId = Guid.NewGuid();
            var source = new GetGoalsResponseDto
            {
                Limit = 7,
                Offset = 2,
                NextOffset = 9,
                Goals = new List<GoalDto>
                {
                    new()
                    {
                        Id = goalId.ToString(),
                        Color = "#AA00BB",
                        CreatedAt = "2026-01-01 00:00:00",
                        DesiredDate = "2026-12-31",
                        IconName = "home",
                        InitialAmount = "5000",
                        Name = "Casa",
                        Note = "Acconto",
                        State = "active",
                        StateUpdatedAt = "2026-01-10",
                        TargetAmount = "20000",
                        UpdatedAt = "2026-01-02 00:00:00"
                    }
                },
                AgentHints = new List<AgentHintDto> { new() { Text = "hint" } }
            };

            GetGoalsResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            Goal mapped = result!.Goals[0];
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.NextOffset, Is.EqualTo(source.NextOffset));
                Assert.That(result.Goals, Has.Count.EqualTo(1));
                Assert.That(result.AgentHints, Has.Count.EqualTo(1));
                Assert.That(mapped.Id, Is.EqualTo(goalId));
                Assert.That(mapped.Name, Is.EqualTo(source.Goals[0].Name));
                Assert.That(mapped.Note, Is.EqualTo(source.Goals[0].Note));
                Assert.That(mapped.TargetAmount, Is.EqualTo(source.Goals[0].TargetAmount));
            }
        }

        [Test]
        public void Map_WhenGoalsContainNullAndInvalidId_FiltersNullAndLeavesIdNull()
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
                Assert.That(result.Goals[0].Id, Is.Null);
            }
        }
    }
}
