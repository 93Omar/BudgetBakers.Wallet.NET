using BudgetBakers.Wallet.Net.Dtos.Stats;
using BudgetBakers.Wallet.Net.Models.Stats;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Tests.Mappers
{
    public class GetStatsResponseMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            GetStatsResponseMapper mapper = new();

            GetStatsResponse? result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            GetStatsResponseMapper mapper = new();
            GetStatsResponseDto source = new()
            {
                Granularity = "daily",
                Period = "30days",
                Total = 150,
                Usage = new List<StatsUsageDto>
                {
                    new()
                    {
                        From = "2025-01-08T00:00:00Z",
                        To = "2025-01-09T00:00:00Z",
                        Total = 25
                    },
                    new()
                    {
                        From = "2025-01-09T00:00:00Z",
                        To = "2025-01-10T00:00:00Z",
                        Total = 18
                    }
                }
            };

            GetStatsResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            StatsUsage mappedUsage = result!.Usage[0];
            StatsUsageDto sourceUsage = source.Usage[0];

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.Granularity, Is.EqualTo(source.Granularity));
                Assert.That(result.Period, Is.EqualTo(source.Period));
                Assert.That(result.Total, Is.EqualTo(source.Total));
                Assert.That(result.Usage, Has.Count.EqualTo(2));
                Assert.That(mappedUsage.From, Is.EqualTo(DateTime.Parse(sourceUsage.From!)));
                Assert.That(mappedUsage.To, Is.EqualTo(DateTime.Parse(sourceUsage.To!)));
                Assert.That(mappedUsage.Total, Is.EqualTo(sourceUsage.Total));
            }
        }

        [Test]
        public void Map_WhenUsageContainsNullAndInvalidDates_FiltersNullAndLeavesDatesNull()
        {
            GetStatsResponseMapper mapper = new();
            GetStatsResponseDto source = new()
            {
                Usage = new List<StatsUsageDto>
                {
                    null!,
                    new()
                    {
                        From = "invalid-date",
                        To = null,
                        Total = 3
                    }
                }
            };

            GetStatsResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Usage, Has.Count.EqualTo(1));
                Assert.That(result.Usage[0].From, Is.Null);
                Assert.That(result.Usage[0].To, Is.Null);
                Assert.That(result.Usage[0].Total, Is.EqualTo(3));
            }
        }
    }
}
