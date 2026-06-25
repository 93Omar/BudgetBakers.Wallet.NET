using BudgetBakers.Wallet.Net.Dtos.Stats;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Stats;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Tests.Mappers
{
    public class GetStatsRequestMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            GetStatsRequestMapper mapper = new();

            GetStatsRequestDto? result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            GetStatsRequestMapper mapper = new();
            GetStatsRequest source = new()
            {
                Period = new PeriodFilter
                {
                    Prefix = PeriodPrefix.Days,
                    Value = 30
                }
            };

            GetStatsRequestDto? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Period, Is.EqualTo("30days"));
        }
    }
}
