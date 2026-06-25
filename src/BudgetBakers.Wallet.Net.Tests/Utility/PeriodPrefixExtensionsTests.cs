using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Tests.Utility
{
    public class PeriodPrefixExtensionsTests
    {
        [TestCase(PeriodPrefix.Days, "days")]
        [TestCase(PeriodPrefix.Weeks, "weeks")]
        [TestCase(PeriodPrefix.Months, "months")]
        public void ToCustomString_WhenValueIsSupported_ReturnsExpectedString(PeriodPrefix value, string expected)
        {
            string result = value.ToCustomString();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToCustomString_WhenValueIsUnsupported_ThrowsInvalidOperationException()
        {
            PeriodPrefix value = (PeriodPrefix)999;

            Assert.That(() => value.ToCustomString(), Throws.TypeOf<InvalidOperationException>());
        }
    }
}
