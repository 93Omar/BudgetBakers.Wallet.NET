using Wallet.Api.Net.Dtos;
using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Models.Account;
using Wallet.Api.Net.Services.Mappers;

namespace Wallet.Api.Net.Tests.Mappers
{
    public class GetAccountsResponseMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetAccountsResponseMapper();

            var result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetAccountsResponseMapper();
            var accountId = Guid.NewGuid();
            var createdAt = "2026-01-02 03:04:05";
            var updatedAt = "2026-02-03 04:05:06";
            var hintData = new Dictionary<string, string> { ["source"] = "unit-test" };

            var source = new GetAccountsResponseDto
            {
                Limit = 50,
                Offset = 5,
                NextOffset = 55,
                Accounts = new List<AccountDto>
                {
                    new()
                    {
                        AccountType = nameof(AccountType.CreditCard),
                        Archived = true,
                        BankAccountNumber = "1234567890",
                        Color = "#112233",
                        CreatedAt = createdAt,
                        ExcludeFromStats = true,
                        Id = accountId.ToString(),
                        InitialBalance = new BalanceDto { CurrencyCode = "EUR", Value = 100.50m },
                        InitialBaseBalance = new BalanceDto { CurrencyCode = "USD", Value = 120.70m },
                        Name = "Main card",
                        RecordStats = new RecordStatsDto
                        {
                            RecordCount = 3,
                            CreatedAt = new DateRangeDto { Min = "2026-01-01 00:00:00", Max = "2026-01-31 23:59:59" },
                            RecordDate = new DateRangeDto { Min = "2026-02-01 00:00:00", Max = "2026-02-28 23:59:59" }
                        },
                        UpdatedAt = updatedAt
                    }
                },
                AgentHints = new List<AgentHintDto>
                {
                    new()
                    {
                        Action = new AgentActionDto { Url = "https://wallet.test/hint" },
                        Data = hintData,
                        Severity = "info",
                        Text = "hint text",
                        Type = "account"
                    }
                }
            };

            var result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.NextOffset, Is.EqualTo(source.NextOffset));
                Assert.That(result.Accounts, Has.Count.EqualTo(1));
                Assert.That(result.AgentHints, Has.Count.EqualTo(1));
            }

            var mappedAccount = result!.Accounts[0];
            var sourceAccount = source.Accounts[0];

            using (Assert.EnterMultipleScope())
            {
                Assert.That(mappedAccount.AccountType, Is.EqualTo(AccountType.CreditCard));
                Assert.That(mappedAccount.Archived, Is.EqualTo(sourceAccount.Archived));
                Assert.That(mappedAccount.BankAccountNumber, Is.EqualTo(sourceAccount.BankAccountNumber));
                Assert.That(mappedAccount.Color, Is.EqualTo(sourceAccount.Color));
                Assert.That(mappedAccount.CreatedAt, Is.EqualTo(DateTime.Parse(sourceAccount.CreatedAt!)));
                Assert.That(mappedAccount.ExcludeFromStats, Is.EqualTo(sourceAccount.ExcludeFromStats));
                Assert.That(mappedAccount.Id, Is.EqualTo(accountId));
                Assert.That(mappedAccount.InitialBalance?.CurrencyCode, Is.EqualTo(sourceAccount.InitialBalance?.CurrencyCode));
                Assert.That(mappedAccount.InitialBalance?.Value, Is.EqualTo(sourceAccount.InitialBalance?.Value));
                Assert.That(mappedAccount.InitialBaseBalance?.CurrencyCode, Is.EqualTo(sourceAccount.InitialBaseBalance?.CurrencyCode));
                Assert.That(mappedAccount.InitialBaseBalance?.Value, Is.EqualTo(sourceAccount.InitialBaseBalance?.Value));
                Assert.That(mappedAccount.Name, Is.EqualTo(sourceAccount.Name));
                Assert.That(mappedAccount.RecordStats?.RecordCount, Is.EqualTo(sourceAccount.RecordStats?.RecordCount));
                Assert.That(mappedAccount.RecordStats?.CreatedAt?.Min, Is.EqualTo(DateTime.Parse(sourceAccount.RecordStats!.CreatedAt!.Min!)));
                Assert.That(mappedAccount.RecordStats?.CreatedAt?.Max, Is.EqualTo(DateTime.Parse(sourceAccount.RecordStats!.CreatedAt!.Max!)));
                Assert.That(mappedAccount.RecordStats?.RecordDate?.Min, Is.EqualTo(DateTime.Parse(sourceAccount.RecordStats!.RecordDate!.Min!)));
                Assert.That(mappedAccount.RecordStats?.RecordDate?.Max, Is.EqualTo(DateTime.Parse(sourceAccount.RecordStats!.RecordDate!.Max!)));
                Assert.That(mappedAccount.UpdatedAt, Is.EqualTo(DateTime.Parse(sourceAccount.UpdatedAt!)));
            }

            var mappedHint = result.AgentHints[0];
            var sourceHint = source.AgentHints[0];

            using (Assert.EnterMultipleScope())
            {
                Assert.That(mappedHint.Action?.Url, Is.EqualTo(sourceHint.Action?.Url));
                Assert.That(mappedHint.Data, Is.SameAs(sourceHint.Data));
                Assert.That(mappedHint.Severity, Is.EqualTo(sourceHint.Severity));
                Assert.That(mappedHint.Text, Is.EqualTo(sourceHint.Text));
                Assert.That(mappedHint.Type, Is.EqualTo(sourceHint.Type));
            }
        }
    }
}
