using BudgetBakers.Wallet.Net.Dtos.Account;
using BudgetBakers.Wallet.Net.Dtos.Label;
using BudgetBakers.Wallet.Net.Dtos.StandingOrder;
using BudgetBakers.Wallet.Net.Models.StandingOrder;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Tests.Mappers
{
    public class GetStandingOrdersResponseMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetStandingOrdersResponseMapper();

            GetStandingOrdersResponse? result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetStandingOrdersResponseMapper();
            var standingOrderId = Guid.NewGuid().ToString();
            var categoryId = Guid.NewGuid().ToString();

            var source = new GetStandingOrdersResponseDto
            {
                Limit = 4,
                Offset = 2,
                NextOffset = 6,
                StandingOrders = new List<StandingOrderDto>
                {
                    new()
                    {
                        Id = standingOrderId,
                        AccountId = "acc-1",
                        Amount = 1500,
                        CategoryId = categoryId,
                        CreatedAt = "2026-01-01 00:00:00",
                        CurrencyCode = "EUR",
                        DueDate = "2026-01-28T00:00:00",
                        DueDateNotificationEnabled = true,
                        GenerateFromDate = "2026-02-01",
                        Labels = new List<LabelDto> { new() { Name = "Home", CreatedAt = "2026-01-01", UpdatedAt = "2026-01-02" } },
                        ManualPayment = true,
                        Name = "Rent",
                        Note = "Monthly",
                        CounterParty = "Landlord",
                        RecurrenceRule = "FREQ=MONTHLY",
                        Reminder = "email",
                        ThreeDaysBeforeNotificationEnabled = true,
                        Type = "expense",
                        UpdatedAt = "2026-01-02 00:00:00"
                    }
                },
                AgentHints = new List<AgentHintDto> { new() { Severity = "info", Text = "hint", Type = "result.empty" } }
            };

            GetStandingOrdersResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            StandingOrder mapped = result!.StandingOrders[0];
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.Pagination.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Pagination.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.Pagination.NextOffset, Is.EqualTo(source.NextOffset));
                Assert.That(result.StandingOrders, Has.Count.EqualTo(1));
                Assert.That(result.AgentHints, Has.Count.EqualTo(1));
                Assert.That(mapped.Id, Is.EqualTo(standingOrderId));
                Assert.That(mapped.CategoryId, Is.EqualTo(categoryId));
                Assert.That(mapped.Amount, Is.EqualTo(1500));
                Assert.That(mapped.DueDateNotificationEnabled, Is.True);
                Assert.That(mapped.ThreeDaysBeforeNotificationEnabled, Is.True);
                Assert.That(mapped.Name, Is.EqualTo(source.StandingOrders[0].Name));
                Assert.That(mapped.ManualPayment, Is.EqualTo(source.StandingOrders[0].ManualPayment));
                Assert.That(mapped.Labels, Has.Count.EqualTo(1));
            }
        }

        [Test]
        public void Map_WhenStandingOrdersContainNullAndStringId_FiltersNullAndKeepsId()
        {
            var mapper = new GetStandingOrdersResponseMapper();
            var source = new GetStandingOrdersResponseDto
            {
                StandingOrders = new List<StandingOrderDto>
                {
                    null!,
                    new StandingOrderDto
                    {
                        Id = "invalid-guid",
                        Labels = new List<LabelDto>()
                    }
                },
                AgentHints = new List<AgentHintDto>()
            };

            GetStandingOrdersResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.StandingOrders, Has.Count.EqualTo(1));
                Assert.That(result.StandingOrders[0].Id, Is.EqualTo("invalid-guid"));
            }
        }
    }
}
