using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Tests.Utility
{
    public class RangePrefixExtensionsTests
    {
        [TestCase(RangePrefix.Equals, "eq")]
        [TestCase(RangePrefix.GreaterThan, "gt")]
        [TestCase(RangePrefix.GreaterThanOrEqual, "gte")]
        [TestCase(RangePrefix.LessThan, "lt")]
        [TestCase(RangePrefix.LessThanOrEqual, "lte")]
        public void ToCustomString_WhenValueIsSupported_ReturnsExpectedString(RangePrefix value, string expected)
        {
            string result = value.ToCustomString();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToCustomString_WhenValueIsUnsupported_ThrowsInvalidOperationException()
        {
            RangePrefix value = (RangePrefix)999;

            Assert.That(() => value.ToCustomString(), Throws.TypeOf<InvalidOperationException>());
        }
    }
}
