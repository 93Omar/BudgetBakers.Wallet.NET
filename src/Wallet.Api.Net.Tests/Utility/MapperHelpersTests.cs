using Wallet.Api.Net.Constants;
using Wallet.Api.Net.Dtos;
using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Dtos.Label;
using Wallet.Api.Net.Dtos.Record;
using Wallet.Api.Net.Models;
using Wallet.Api.Net.Models.Label;
using Wallet.Api.Net.Models.Record;
using Wallet.Api.Net.Models.StandingOrder;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Tests.Utility
{
    public class MapperHelpersTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ParseGuid_WhenInputIsNullOrWhitespace_ReturnsNull(string? value)
        {
            Guid? result = MapperHelpers.ParseGuid(value);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void ParseGuid_WhenInputIsInvalid_ReturnsNull()
        {
            Guid? result = MapperHelpers.ParseGuid("not-a-guid");

            Assert.That(result, Is.Null);
        }

        [Test]
        public void ParseGuid_WhenInputIsValid_ReturnsGuid()
        {
            Guid expected = Guid.NewGuid();

            Guid? result = MapperHelpers.ParseGuid(expected.ToString());

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("invalid-date")]
        public void ParseDateTime_WhenInputIsNullWhitespaceOrInvalid_ReturnsNull(string? value)
        {
            DateTime? result = MapperHelpers.ParseDateTime(value);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void ParseDateTime_WhenInputIsValid_ReturnsDateTime()
        {
            DateTime? result = MapperHelpers.ParseDateTime("2026-01-01 10:00:00");

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void MapAgentHint_WhenDtoIsNull_ReturnsNull()
        {
            AgentHintDto? dto = null;

            AgentHint? result = MapperHelpers.MapAgentHint(dto);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void MapAgentHint_WhenActionIsNull_MapsWithoutAction()
        {
            AgentHint? result = MapperHelpers.MapAgentHint(new AgentHintDto
            {
                Action = null,
                Data = "data",
                Severity = "warning",
                Text = "text",
                Type = "data.recency"
            });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result!.Action, Is.Null);
                Assert.That(result.Text, Is.EqualTo("text"));
            }
        }

        [Test]
        public void MapAgentHint_WhenActionIsPresent_MapsAction()
        {
            AgentHint? result = MapperHelpers.MapAgentHint(new AgentHintDto
            {
                Action = new AgentActionDto { Url = "https://example.test" },
                Severity = "instruction",
                Text = "follow link",
                Type = "pagination.has_more"
            });

            Assert.That(result!.Action!.Url, Is.EqualTo("https://example.test"));
        }

        [Test]
        public void MapBalance_WhenDtoIsNull_ReturnsNull()
        {
            BalanceDto? dto = null;

            Balance? result = MapperHelpers.MapBalance(dto);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void MapBalance_WhenDtoIsValid_MapsValues()
        {
            Balance? result = MapperHelpers.MapBalance(new BalanceDto
            {
                CurrencyCode = "EUR",
                Value = 10.5m
            });

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result!.CurrencyCode, Is.EqualTo("EUR"));
                Assert.That(result.Value, Is.EqualTo(10.5m));
            }
        }

        [Test]
        public void MapLabel_WhenIdIsValid_SetsId()
        {
            Guid id = Guid.NewGuid();

            Label? result = MapperHelpers.MapLabel(new LabelDto
            {
                Id = id.ToString(),
                Name = "label"
            });

            Assert.That(result!.Id, Is.EqualTo(id));
        }

        [Test]
        public void MapLabel_WhenIdIsInvalid_DoesNotSetId()
        {
            Label? result = MapperHelpers.MapLabel(new LabelDto
            {
                Id = "invalid-guid",
                Name = "label"
            });

            Assert.That(result!.Id, Is.Null);
        }

        [Test]
        public void MapLabel_WhenDtoIsNull_ReturnsNull()
        {
            LabelDto? dto = null;

            Label? result = MapperHelpers.MapLabel(dto);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void MapRecordPhoto_WhenDtoIsNull_ReturnsNull()
        {
            PhotoDto? dto = null;

            RecordPhoto? result = MapperHelpers.MapRecordPhoto(dto);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void MapPlace_WhenDtoIsNull_ReturnsNull()
        {
            PlaceDto? dto = null;

            RecordPlace? result = MapperHelpers.MapPlace(dto);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void MapPlace_WhenPlaceTypesIsNull_MapsEmptyList()
        {
            var dto = new PlaceDto
            {
                Name = "Office",
                PlaceTypes = null!
            };

            RecordPlace? result = MapperHelpers.MapPlace(dto);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result!.PlaceTypes, Is.Not.Null);
                Assert.That(result.PlaceTypes, Is.Empty);
            }
        }

        [Test]
        public void MapDateRange_WhenDtoIsNull_ReturnsNull()
        {
            DateRangeDto? dto = null;

            DateRange? result = MapperHelpers.MapDateRange(dto);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void MapRecordStats_WhenDtoIsNull_ReturnsNull()
        {
            RecordStatsDto? dto = null;

            RecordStats? result = MapperHelpers.MapRecordStats(dto);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void MapRecordStats_WhenNestedRangesArePresent_MapsValues()
        {
            var dto = new RecordStatsDto
            {
                RecordCount = 5,
                CreatedAt = new DateRangeDto { Min = "2026-01-01", Max = "2026-01-31" },
                RecordDate = new DateRangeDto { Min = "2026-02-01", Max = "2026-02-28" }
            };

            RecordStats? result = MapperHelpers.MapRecordStats(dto);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result!.RecordCount, Is.EqualTo(5));
                Assert.That(result.CreatedAt, Is.Not.Null);
                Assert.That(result.RecordDate, Is.Not.Null);
            }
        }

        [Test]
        public void JoinIds_WhenInputIsNull_ReturnsNull()
        {
            string? result = MapperHelpers.JoinIds(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void JoinIds_WhenInputIsEmpty_ReturnsNull()
        {
            string? result = MapperHelpers.JoinIds([]);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void JoinIds_WhenInputContainsValues_UsesApiSeparator()
        {
            string? result = MapperHelpers.JoinIds(["id-1", "id-2"]);

            Assert.That(result, Is.EqualTo($"id-1{ApiConstant.Separator.Ids}id-2"));
        }

        [TestCase("info", AgentHintSeverity.Info)]
        [TestCase("warning", AgentHintSeverity.Warning)]
        [TestCase("instruction", AgentHintSeverity.Instruction)]
        public void ParseAgentHintSeverity_WhenValueIsKnown_ReturnsExpectedSeverity(string value, AgentHintSeverity expected)
        {
            AgentHintSeverity result = MapperHelpers.ParseAgentHintSeverity(value);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(null)]
        [TestCase("unknown")]
        public void ParseAgentHintSeverity_WhenValueIsUnknown_ThrowsInvalidOperationException(string? value)
        {
            Assert.That(() => MapperHelpers.ParseAgentHintSeverity(value), Throws.TypeOf<InvalidOperationException>());
        }

        [TestCase("pagination.has_more", AgentHintType.PaginationHasMore)]
        [TestCase("result.partial_match", AgentHintType.ResultPartialMatch)]
        [TestCase("result.empty", AgentHintType.ResultEmpty)]
        [TestCase("param.inferred", AgentHintType.ParamInferred)]
        [TestCase("rate_limit.warning", AgentHintType.RateLimitWarning)]
        [TestCase("data.recency", AgentHintType.DataRecency)]
        public void ParseAgentHintType_WhenValueIsKnown_ReturnsExpectedType(string value, AgentHintType expected)
        {
            AgentHintType result = MapperHelpers.ParseAgentHintType(value);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(null)]
        [TestCase("unknown")]
        public void ParseAgentHintType_WhenValueIsUnknown_ThrowsInvalidOperationException(string? value)
        {
            Assert.That(() => MapperHelpers.ParseAgentHintType(value), Throws.TypeOf<InvalidOperationException>());
        }

        [TestCase("cash", PaymentType.Cash)]
        [TestCase("debit_card", PaymentType.DebitCard)]
        [TestCase("credit_card", PaymentType.CreditCard)]
        [TestCase("transfer", PaymentType.Transfer)]
        [TestCase("voucher", PaymentType.Voucher)]
        [TestCase("mobile_payment", PaymentType.MobilePayment)]
        [TestCase("web_payment", PaymentType.WebPayment)]
        public void ParsePaymentType_WhenValueIsKnown_ReturnsExpectedPaymentType(string value, PaymentType expected)
        {
            PaymentType? result = MapperHelpers.ParsePaymentType(value);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ParsePaymentType_WhenValueIsNull_ReturnsNull()
        {
            PaymentType? result = MapperHelpers.ParsePaymentType(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void ParsePaymentType_WhenValueIsUnknown_ThrowsInvalidOperationException()
        {
            Assert.That(() => MapperHelpers.ParsePaymentType("unknown"), Throws.TypeOf<InvalidOperationException>());
        }

        [TestCase("reconciled", RecordState.Reconciled)]
        [TestCase("cleared", RecordState.Cleared)]
        [TestCase("uncleared", RecordState.Uncleared)]
        [TestCase("void", RecordState.Void)]
        [TestCase("waitForAssign", RecordState.WaitForAssign)]
        public void ParseRecordState_WhenValueIsKnown_ReturnsExpectedRecordState(string value, RecordState expected)
        {
            RecordState? result = MapperHelpers.ParseRecordState(value);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ParseRecordState_WhenValueIsNull_ReturnsNull()
        {
            RecordState? result = MapperHelpers.ParseRecordState(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void ParseRecordState_WhenValueIsUnknown_ThrowsInvalidOperationException()
        {
            Assert.That(() => MapperHelpers.ParseRecordState("unknown"), Throws.TypeOf<InvalidOperationException>());
        }

        [TestCase("income", RecordType.Income)]
        [TestCase("expense", RecordType.Expense)]
        public void ParseRecordType_WhenValueIsKnown_ReturnsExpectedRecordType(string value, RecordType expected)
        {
            RecordType? result = MapperHelpers.ParseRecordType(value);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ParseRecordType_WhenValueIsNull_ReturnsNull()
        {
            RecordType? result = MapperHelpers.ParseRecordType(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void ParseRecordType_WhenValueIsUnknown_ThrowsInvalidOperationException()
        {
            Assert.That(() => MapperHelpers.ParseRecordType("unknown"), Throws.TypeOf<InvalidOperationException>());
        }

        [TestCase("income", StandingOrderType.Income)]
        [TestCase("expense", StandingOrderType.Expense)]
        public void ParseStandingOrderType_WhenValueIsKnown_ReturnsExpectedStandingOrderType(string value, StandingOrderType expected)
        {
            StandingOrderType? result = MapperHelpers.ParseStandingOrderType(value);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ParseStandingOrderType_WhenValueIsNull_ReturnsNull()
        {
            StandingOrderType? result = MapperHelpers.ParseStandingOrderType(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void ParseStandingOrderType_WhenValueIsUnknown_ThrowsInvalidOperationException()
        {
            Assert.That(() => MapperHelpers.ParseStandingOrderType("unknown"), Throws.TypeOf<InvalidOperationException>());
        }
    }
}
