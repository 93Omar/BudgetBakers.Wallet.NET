using BudgetBakers.Wallet.Net.Models;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Tests.Utility
{
    public class TextPrefixExtensionsTests
    {
        [TestCase(TextPrefix.Equals, "eq")]
        [TestCase(TextPrefix.Contains, "contains")]
        [TestCase(TextPrefix.ContainsIgnoreCase, "contains-i")]
        public void ToCustomString_WhenValueIsSupported_ReturnsExpectedString(TextPrefix value, string expected)
        {
            string result = value.ToCustomString();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToCustomString_WhenValueIsUnsupported_ThrowsInvalidOperationException()
        {
            TextPrefix value = (TextPrefix)999;

            Assert.That(() => value.ToCustomString(), Throws.TypeOf<InvalidOperationException>());
        }
    }
}
