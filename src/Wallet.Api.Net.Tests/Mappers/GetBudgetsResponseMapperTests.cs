using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Dtos.Budget;
using Wallet.Api.Net.Dtos.Label;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Tests.Mappers
{
    public class GetBudgetsResponseMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetBudgetsResponseMapper();

            var result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetBudgetsResponseMapper();
            var budgetId = Guid.NewGuid();
            var accountId = Guid.NewGuid();
            var categoryId = Guid.NewGuid();

            var source = new GetBudgetsResponseDto
            {
                Limit = 20,
                Offset = 1,
                NextOffset = 21,
                Budgets = new List<BudgetDto>
                {
                    new()
                    {
                        Id = budgetId.ToString(),
                        AccountIds = new List<string> { accountId.ToString(), "not-guid" },
                        Amount = "100.00",
                        CategoryIds = new List<string> { categoryId.ToString() },
                        CreatedAt = "2026-01-01 00:00:00",
                        CurrencyCode = "EUR",
                        EndDate = "2026-12-31",
                        Labels = new List<LabelDto>
                        {
                            new() { Id = Guid.NewGuid().ToString(), Name = "Essenziale", Color = "#FFFFFF", Archived = false, CreatedAt = "2026-01-01", UpdatedAt = "2026-01-02" }
                        },
                        Name = "Budget annuale",
                        StartDate = "2026-01-01",
                        Type = "monthly",
                        UpdatedAt = "2026-01-03 00:00:00"
                    }
                },
                AgentHints = new List<AgentHintDto>
                {
                    new() { Text = "hint", Severity = "info", Type = "budget" }
                }
            };

            var result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            var mappedBudget = result!.Budgets[0];
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.NextOffset, Is.EqualTo(source.NextOffset));
                Assert.That(result.Budgets, Has.Count.EqualTo(1));
                Assert.That(result.AgentHints, Has.Count.EqualTo(1));
                Assert.That(mappedBudget.Id, Is.EqualTo(budgetId));
                Assert.That(mappedBudget.AccountIds, Has.Count.EqualTo(1));
                Assert.That(mappedBudget.AccountIds[0], Is.EqualTo(accountId));
                Assert.That(mappedBudget.CategoryIds[0], Is.EqualTo(categoryId));
                Assert.That(mappedBudget.Amount, Is.EqualTo(source.Budgets[0].Amount));
                Assert.That(mappedBudget.CurrencyCode, Is.EqualTo(source.Budgets[0].CurrencyCode));
                Assert.That(mappedBudget.Name, Is.EqualTo(source.Budgets[0].Name));
                Assert.That(mappedBudget.Labels, Has.Count.EqualTo(1));
                Assert.That(result.AgentHints[0].Text, Is.EqualTo(source.AgentHints[0].Text));
            }
        }
    }
}
