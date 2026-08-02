using BudgetBakers.Wallet.Net.Dtos.Account;
using BudgetBakers.Wallet.Net.Dtos.Category;
using BudgetBakers.Wallet.Net.Models.Category;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Tests.Mappers
{
    public class GetCategoriesResponseMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetCategoriesResponseMapper();

            GetCategoriesResponse? result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetCategoriesResponseMapper();
            var categoryId = Guid.NewGuid().ToString();
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
                        Cardinality = "want",
                        Color = "#123456",
                        CreatedAt = "2026-01-01 00:00:00",
                        CustomCategory = true,
                        CustomName = false,
                        Enabled = true,
                        Name = "Shopping",
                        UpdatedAt = "2026-01-02 00:00:00"
                    }
                },
                AgentHints = new List<AgentHintDto> { new() { Severity = "info", Text = "hint", Type = "result.empty" } }
            };

            GetCategoriesResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            Category mapped = result!.Categories[0];
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Pagination.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Pagination.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.Pagination.NextOffset, Is.EqualTo(source.NextOffset));
                Assert.That(result.Categories, Has.Count.EqualTo(1));
                Assert.That(result.AgentHints, Has.Count.EqualTo(1));
                Assert.That(mapped.Id, Is.EqualTo(categoryId));
                Assert.That(mapped.Archived, Is.EqualTo(source.Categories[0].Archived));
                Assert.That(mapped.Cardinality, Is.EqualTo(CategoryCardinality.Want));
                Assert.That(mapped.Name, Is.EqualTo(source.Categories[0].Name));
            }
        }

        [Test]
        public void Map_WhenCategoriesContainNullAndInvalidId_FiltersNullAndLeavesIdNull()
        {
            var mapper = new GetCategoriesResponseMapper();
            var source = new GetCategoriesResponseDto
            {
                Categories = new List<CategoryDto>
                {
                    null!,
                    new CategoryDto { Id = "invalid-guid", Name = "No Guid" }
                },
                AgentHints = new List<AgentHintDto>()
            };

            GetCategoriesResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Categories, Has.Count.EqualTo(1));
                Assert.That(result.Categories[0].Id, Is.EqualTo("invalid-guid"));
            }
        }
    }
}
