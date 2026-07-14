using BudgetBakers.Wallet.Net.Dtos.Account;
using BudgetBakers.Wallet.Net.Dtos.Label;
using BudgetBakers.Wallet.Net.Models.Label;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Tests.Mappers
{
    public class GetLabelsResponseMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetLabelsResponseMapper();

            GetLabelsResponse? result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetLabelsResponseMapper();
            var labelId = Guid.NewGuid().ToString();
            var source = new GetLabelsResponseDto
            {
                Limit = 12,
                Offset = 2,
                NextOffset = 14,
                Labels = new List<LabelDto>
                {
                    new()
                    {
                        Id = labelId.ToString(),
                        Archived = true,
                        Color = "#FFFFFF",
                        CreatedAt = "2026-01-01 00:00:00",
                        Name = "Home",
                        UpdatedAt = "2026-01-02 00:00:00"
                    }
                },
                AgentHints = new List<AgentHintDto> { new() { Severity = "info", Text = "hint", Type = "result.empty" } }
            };

            GetLabelsResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            Label mapped = result!.Labels[0];
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Pagination.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Pagination.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.Pagination.NextOffset, Is.EqualTo(source.NextOffset));
                Assert.That(result.Labels, Has.Count.EqualTo(1));
                Assert.That(result.AgentHints, Has.Count.EqualTo(1));
                Assert.That(mapped.Id, Is.EqualTo(labelId));
                Assert.That(mapped.Name, Is.EqualTo(source.Labels[0].Name));
                Assert.That(mapped.Color, Is.EqualTo(source.Labels[0].Color));
            }
        }
    }
}
