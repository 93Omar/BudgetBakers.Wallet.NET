using BudgetBakers.Wallet.Net.Models;

namespace BudgetBakers.Wallet.Net.Tests.Models
{
    public class PeriodFilterTests
    {
        [TestCase(30, PeriodPrefix.Days, "30days")]
        [TestCase(12, PeriodPrefix.Weeks, "12weeks")]
        [TestCase(6, PeriodPrefix.Months, "6months")]
        public void ToString_WhenValueIsValid_ReturnsExpectedString(int value, PeriodPrefix prefix, string expected)
        {
            PeriodFilter filter = new()
            {
                Prefix = prefix,
                Value = value
            };

            string result = filter.ToString();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
