using BudgetBakers.Wallet.Net.Dtos.Account;
using BudgetBakers.Wallet.Net.Dtos.Budget;
using BudgetBakers.Wallet.Net.Models.Budget;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Tests.Mappers
{
    public class GetBudgetsResponseMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetBudgetsResponseMapper();

            GetBudgetsResponse? result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetBudgetsResponseMapper();
            var budgetId = Guid.NewGuid().ToString();
            var accountId = Guid.NewGuid().ToString();
            var categoryId = Guid.NewGuid().ToString();
            var labelId = Guid.NewGuid().ToString();

            var source = new GetBudgetsResponseDto
            {
                Limit = 20,
                Offset = 1,
                NextOffset = 21,
                Budgets = new List<BudgetDto>
                {
                    new()
                    {
                        Id = budgetId,
                        AccountIds = new List<string> { accountId, "not-guid" },
                        Limit = 100.00m,
                        CategoryIds = new List<string> { categoryId },
                        CreatedAt = "2026-01-01 00:00:00",
                        CurrencyCode = "EUR",
                        EndDate = "2026-12-31",
                        LabelIds = new List<string> { labelId, "not-a-guid" },
                        LimitOverrides = new List<BudgetChangeEntryDto>
                        {
                            new() { CreatedAt = "2026-01-02", Limit = 55, Period = "month", PeriodStart = "2026-01-01" }
                        },
                        Name = "Budget annuale",
                        PastLimitOverrides = new List<BudgetChangeEntryDto>
                        {
                            new() { CreatedAt = "2025-12-02", Limit = 45, Period = "month", PeriodStart = "2025-12-01" }
                        },
                        Spending = new BudgetSpendingDto
                        {
                            ComputedAt = "2026-01-03 00:00:00",
                            Current = new BudgetPeriodSpendingDto
                            {
                                ConvertedCurrencies = new List<string> { "EUR" },
                                Excluded = new ExcludedBreakdownDto { Total = 1 },
                                Remaining = 10
                            }
                        },
                        StartDate = "2026-01-01",
                        Type = "monthly",
                        UpdatedAt = "2026-01-03 00:00:00"
                    }
                },
                AgentHints = new List<AgentHintDto>
                {
                    new() { Severity = "info", Text = "hint", Type = "param.inferred" }
                }
            };

            GetBudgetsResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            Budget mappedBudget = result!.Budgets[0];
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.Pagination.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Pagination.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.Pagination.NextOffset, Is.EqualTo(source.NextOffset));
                Assert.That(result.Budgets, Has.Count.EqualTo(1));
                Assert.That(result.AgentHints, Has.Count.EqualTo(1));
                Assert.That(mappedBudget.Id, Is.EqualTo(budgetId));
                Assert.That(mappedBudget.AccountIds, Has.Count.EqualTo(2));
                Assert.That(mappedBudget.AccountIds[0], Is.EqualTo(accountId));
                Assert.That(mappedBudget.CategoryIds[0], Is.EqualTo(categoryId));
                Assert.That(mappedBudget.LabelIds[0], Is.EqualTo(labelId));
                Assert.That(mappedBudget.LimitOverrides, Has.Count.EqualTo(1));
                Assert.That(mappedBudget.PastLimitOverrides, Has.Count.EqualTo(1));
                Assert.That(mappedBudget.Spending?.Current?.Remaining, Is.EqualTo(10));
                Assert.That(mappedBudget.CurrencyCode, Is.EqualTo(source.Budgets[0].CurrencyCode));
                Assert.That(mappedBudget.Name, Is.EqualTo(source.Budgets[0].Name));
                Assert.That(result.AgentHints[0].Text, Is.EqualTo(source.AgentHints[0].Text));
            }
        }

        [Test]
        public void Map_WhenBudgetsContainNullAndStringValues_HandlesBranches()
        {
            var mapper = new GetBudgetsResponseMapper();
            var source = new GetBudgetsResponseDto
            {
                Budgets = new List<BudgetDto>
                {
                    null!,
                    new BudgetDto
                    {
                        Id = "invalid-guid",
                        AccountIds = new List<string>(),
                        CategoryIds = new List<string> { "not-a-guid" },
                        LabelIds = new List<string>()
                    }
                },
                AgentHints = new List<AgentHintDto>()
            };

            GetBudgetsResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Budgets, Has.Count.EqualTo(1));
                Assert.That(result.Budgets[0].Id, Is.EqualTo("invalid-guid"));
                Assert.That(result.Budgets[0].AccountIds, Is.Empty);
                Assert.That(result.Budgets[0].CategoryIds, Has.Count.EqualTo(1));
            }
        }
    }
}
