using BudgetBakers.Wallet.Net.Dtos.Account;
using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Models.Account;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Tests.Mappers
{
    public class GetAccountsRequestMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new GetAccountsRequestMapper();

            GetAccountsRequestDto? result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenSourceIsValid_MapsAllProperties()
        {
            var mapper = new GetAccountsRequestMapper();

            var source = new GetAccountsRequest
            {
                Limit = 25,
                Offset = 10,
                AgentHints = true,
                Ids = new List<string> { "id-1", "id-2" },
                Name = new TextFilter { Prefix = TextPrefix.ContainsIgnoreCase, Value = "wallet" },
                BankAccountNumber = new TextFilter { Prefix = TextPrefix.Equals, Value = "IT60X0542811101000000123456" },
                AccountType = AccountType.CreditCard,
                CurrencyCode = "EUR",
                CreatedAt = new DateFilter { Prefix = RangePrefix.GreaterThanOrEqual, Value = new DateTime(2026, 01, 02, 03, 04, 05) },
                UpdatedAt = new DateFilter { Prefix = RangePrefix.LessThanOrEqual, Value = new DateTime(2026, 02, 03, 04, 05, 06) }
            };

            GetAccountsRequestDto? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Limit, Is.EqualTo(source.Limit));
                Assert.That(result.Offset, Is.EqualTo(source.Offset));
                Assert.That(result.AgentHints, Is.EqualTo(source.AgentHints));
                Assert.That(result.Id, Is.EqualTo("id-1,id-2"));
                Assert.That(result.Name, Is.EqualTo(source.Name!.ToString()));
                Assert.That(result.BankAccountNumber, Is.EqualTo(source.BankAccountNumber!.ToString()));
                Assert.That(result.AccountType, Is.EqualTo(source.AccountType!.ToString()));
                Assert.That(result.CurrencyCode, Is.EqualTo(source.CurrencyCode));
                Assert.That(result.CreatedAt, Is.EqualTo(source.CreatedAt!.ToString()));
                Assert.That(result.UpdatedAt, Is.EqualTo(source.UpdatedAt!.ToString()));
            }
        }
    }
}
