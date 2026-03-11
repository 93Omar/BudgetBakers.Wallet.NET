using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Dtos.Label;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Tests
{
    public class GetLabelsResponseMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetLabelsResponseMapper();

            var result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetLabelsResponseMapper();
            var labelId = Guid.NewGuid();
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
                        Name = "Casa",
                        UpdatedAt = "2026-01-02 00:00:00"
                    }
                },
                AgentHints = new List<AgentHintDto> { new() { Text = "hint" } }
            };

            var result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            var mapped = result!.Labels[0];
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.NextOffset, Is.EqualTo(source.NextOffset));
                Assert.That(result.Labels, Has.Count.EqualTo(1));
                Assert.That(result.AgentHints, Has.Count.EqualTo(1));
                Assert.That(mapped.Id, Is.EqualTo(labelId));
                Assert.That(mapped.Name, Is.EqualTo(source.Labels[0].Name));
                Assert.That(mapped.Color, Is.EqualTo(source.Labels[0].Color));
            }
        }
    }
}
