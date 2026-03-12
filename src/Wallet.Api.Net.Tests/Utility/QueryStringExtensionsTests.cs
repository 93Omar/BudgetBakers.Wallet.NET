using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Wallet.Api.Net.Tests.Infrastructure;
using Wallet.Api.Net.Utility;

namespace Wallet.Api.Net.Tests.Utility
{
    public class QueryStringExtensionsTests
    {
        [Test]
        public void ToQueryString_WhenDtoIsNull_ReturnsNull()
        {
            SampleDto? dto = null;

            string? result = dto.ToQueryString();

            Assert.That(result, Is.Null);
        }

        [Test]
        public void ToQueryString_WhenDtoHasPrimitiveValues_EncodesAndFormatsBoolean()
        {
            var dto = new SampleDto
            {
                Name = "hello world",
                IsEnabled = true,
                Count = 10
            };

            string? result = dto.ToQueryString();

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Does.Contain("Name=hello%20world"));
                Assert.That(result, Does.Contain("IsEnabled=true"));
                Assert.That(result, Does.Contain("Count=10"));
            }
        }

        [Test]
        public void ToQueryString_WhenPropertiesHaveJsonAttributes_UsesCustomNames()
        {
            var dto = new AttributesDto
            {
                FromSystemText = "value-1",
                FromNewtonsoft = "value-2"
            };

            string? result = dto.ToQueryString();

            Assert.That(result, Is.EqualTo("system_text=value-1&newtonsoft=value-2"));
        }

        [Test]
        public void ToQueryString_WhenDtoContainsNestedObject_FlattensNestedProperties()
        {
            var dto = new NestedDto
            {
                Prefix = "outer",
                Inner = new InnerDto
                {
                    Value = "inside",
                    Active = false
                }
            };

            string? result = dto.ToQueryString();

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Does.Contain("Prefix=outer"));
                Assert.That(result, Does.Contain("Value=inside"));
                Assert.That(result, Does.Contain("Active=false"));
            }
        }

        [Test]
        public void ToQueryString_WhenPropertyToStringReturnsNull_ReturnsEmptyQueryString()
        {
            var dto = new QueryStringNullValueDto
            {
                Custom = new NullToStringValue()
            };

            string? result = dto.ToQueryString();

            Assert.That(result, Is.EqualTo(string.Empty));
        }

        private sealed class SampleDto
        {
            public string? Name { get; set; }
            public bool IsEnabled { get; set; }
            public int Count { get; set; }
        }

        private sealed class AttributesDto
        {
            [JsonPropertyName("system_text")]
            public string? FromSystemText { get; set; }

            [JsonProperty("newtonsoft")]
            public string? FromNewtonsoft { get; set; }
        }

        private sealed class NestedDto
        {
            public string? Prefix { get; set; }
            public InnerDto? Inner { get; set; }
        }

        private sealed class InnerDto
        {
            public string? Value { get; set; }
            public bool Active { get; set; }
        }

        private sealed class QueryStringNullValueDto
        {
            public NullToStringValue? Custom { get; set; }
        }

        private sealed class NullToStringValue
        {
            public override string ToString()
            {
                return null!;
            }
        }
    }
}
