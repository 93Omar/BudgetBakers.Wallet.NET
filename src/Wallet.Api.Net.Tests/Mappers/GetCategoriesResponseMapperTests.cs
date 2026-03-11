using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Dtos.Category;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Tests
{
    public class GetCategoriesResponseMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetCategoriesResponseMapper();

            var result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetCategoriesResponseMapper();
            var categoryId = Guid.NewGuid();
            var source = new GetCategoriesResponseDto
            {
                Limit = 10,
                Offset = 1,
                NextOffset = 11,
                Categories = new List<CategoryDto>
                {
                    new()
                    {
                        Id = categoryId.ToString(),
                        Archived = true,
                        Cardinality = "many",
                        Color = "#123456",
                        CreatedAt = "2026-01-01 00:00:00",
                        CustomCategory = true,
                        CustomColor = true,
                        CustomName = false,
                        Enabled = true,
                        EnvelopeId = 5,
                        IconName = "cart",
                        Name = "Shopping",
                        UpdatedAt = "2026-01-02 00:00:00"
                    }
                },
                AgentHints = new List<AgentHintDto> { new() { Text = "hint" } }
            };

            var result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            var mapped = result!.Categories[0];
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.NextOffset, Is.EqualTo(source.NextOffset));
                Assert.That(result.Categories, Has.Count.EqualTo(1));
                Assert.That(result.AgentHints, Has.Count.EqualTo(1));
                Assert.That(mapped.Id, Is.EqualTo(categoryId));
                Assert.That(mapped.Archived, Is.EqualTo(source.Categories[0].Archived));
                Assert.That(mapped.Cardinality, Is.EqualTo(source.Categories[0].Cardinality));
                Assert.That(mapped.EnvelopeId, Is.EqualTo(source.Categories[0].EnvelopeId));
                Assert.That(mapped.Name, Is.EqualTo(source.Categories[0].Name));
            }
        }
    }
}
