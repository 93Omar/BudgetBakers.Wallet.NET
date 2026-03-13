using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Dtos.Label;
using Wallet.Api.Net.Dtos.StandingOrder;
using Wallet.Api.Net.Models.StandingOrder;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Tests.Mappers
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
            var standingOrderId = Guid.NewGuid();
            var categoryId = Guid.NewGuid();

            var source = new GetStandingOrdersResponseDto
            {
                Limit = 4,
                Offset = 2,
                NextOffset = 6,
                StandingOrders = new List<StandingOrderDto>
                {
                    new()
                    {
                        Id = standingOrderId.ToString(),
                        AccountId = "acc-1",
                        Amount = "1500",
                        CategoryId = categoryId.ToString(),
                        CreatedAt = "2026-01-01 00:00:00",
                        CurrencyCode = "EUR",
                        GenerateFromDate = "2026-02-01",
                        Labels = new List<LabelDto> { new() { Name = "Home", CreatedAt = "2026-01-01", UpdatedAt = "2026-01-02" } },
                        ManualPayment = true,
                        Name = "Rent",
                        Note = "Monthly",
                        Payee = "Landlord",
                        Payer = "Me",
                        PaymentType = "bank_transfer",
                        RecurrenceRule = "FREQ=MONTHLY",
                        Type = "expense",
                        UpdatedAt = "2026-01-02 00:00:00"
                    }
                },
                AgentHints = new List<AgentHintDto> { new() { Text = "hint" } }
            };

            GetStandingOrdersResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            StandingOrder mapped = result!.StandingOrders[0];
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Pagination.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Pagination.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.Pagination.NextOffset, Is.EqualTo(source.NextOffset));
                Assert.That(result.StandingOrders, Has.Count.EqualTo(1));
                Assert.That(result.AgentHints, Has.Count.EqualTo(1));
                Assert.That(mapped.Id, Is.EqualTo(standingOrderId));
                Assert.That(mapped.CategoryId, Is.EqualTo(categoryId));
                Assert.That(mapped.Name, Is.EqualTo(source.StandingOrders[0].Name));
                Assert.That(mapped.ManualPayment, Is.EqualTo(source.StandingOrders[0].ManualPayment));
                Assert.That(mapped.Labels, Has.Count.EqualTo(1));
            }
        }

        [Test]
        public void Map_WhenStandingOrdersContainNullAndInvalidId_FiltersNullAndLeavesIdNull()
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
                Assert.That(result.StandingOrders[0].Id, Is.Null);
            }
        }
    }
}
