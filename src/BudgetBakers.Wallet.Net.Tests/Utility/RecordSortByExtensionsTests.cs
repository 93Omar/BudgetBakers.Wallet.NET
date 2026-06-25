using BudgetBakers.Wallet.Net.Models.Record;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Tests.Utility
{
    public class RecordSortByExtensionsTests
    {
        [TestCase(RecordSortBy.RecordDateAscending, "+recordDate")]
        [TestCase(RecordSortBy.RecordDateDescending, "-recordDate")]
        [TestCase(RecordSortBy.AmountAscending, "+amount")]
        [TestCase(RecordSortBy.AmountDescending, "-amount")]
        [TestCase(RecordSortBy.CreatedAtDescending, "-createdAt")]
        [TestCase(RecordSortBy.UpdatedAtDescending, "-updatedAt")]
        public void ToApiString_WhenValueIsSupported_ReturnsExpectedString(RecordSortBy value, string expected)
        {
            string result = value.ToApiString();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToApiString_WhenValueIsUnsupported_ThrowsInvalidOperationException()
        {
            RecordSortBy value = (RecordSortBy)999;

            Assert.That(() => value.ToApiString(), Throws.TypeOf<InvalidOperationException>());
        }
    }
}
