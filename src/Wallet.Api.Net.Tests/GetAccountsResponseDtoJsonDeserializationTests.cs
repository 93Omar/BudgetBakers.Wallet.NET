using Newtonsoft.Json;
using Wallet.Api.Net.Dtos.Account;
using Wallet.Api.Net.Dtos.Budget;
using Wallet.Api.Net.Dtos.Category;
using Wallet.Api.Net.Dtos.Goal;
using Wallet.Api.Net.Dtos.Label;
using Wallet.Api.Net.Dtos.Record;
using Wallet.Api.Net.Dtos.RecordRule;
using Wallet.Api.Net.Dtos.StandingOrder;

namespace Wallet.Api.Net.Tests
{
    public class ResponseDtosJsonDeserializationTests
    {
        private const string ResponseDtosTestDataRoot = "TestData/Dtos";

        private static IEnumerable<TestCaseData> ResponseDtoJsonCases()
        {
            yield return CreateCase("Account empty", BuildJsonPath("Account", "GetAccountsResponseDto.empty.json"), typeof(GetAccountsResponseDto), "Accounts", 0);
            yield return CreateCase("Account sample", BuildJsonPath("Account", "GetAccountsResponseDto.sample.json"), typeof(GetAccountsResponseDto), "Accounts", 1);
            yield return CreateCase("Account populated", BuildJsonPath("Account", "GetAccountsResponseDto.populated.json"), typeof(GetAccountsResponseDto), "Accounts", 1);

            yield return CreateCase("Budget empty", BuildJsonPath("Budget", "GetBudgetsResponseDto.empty.json"), typeof(GetBudgetsResponseDto), "Budgets", 0);
            yield return CreateCase("Budget sample", BuildJsonPath("Budget", "GetBudgetsResponseDto.sample.json"), typeof(GetBudgetsResponseDto), "Budgets", 0);
            yield return CreateCase("Budget populated", BuildJsonPath("Budget", "GetBudgetsResponseDto.populated.json"), typeof(GetBudgetsResponseDto), "Budgets", 1);

            yield return CreateCase("Category empty", BuildJsonPath("Category", "GetCategoriesResponseDto.empty.json"), typeof(GetCategoriesResponseDto), "Categories", 0);
            yield return CreateCase("Category sample", BuildJsonPath("Category", "GetCategoriesResponseDto.sample.json"), typeof(GetCategoriesResponseDto), "Categories", 0);
            yield return CreateCase("Category populated", BuildJsonPath("Category", "GetCategoriesResponseDto.populated.json"), typeof(GetCategoriesResponseDto), "Categories", 1);

            yield return CreateCase("Goal empty", BuildJsonPath("Goal", "GetGoalsResponseDto.empty.json"), typeof(GetGoalsResponseDto), "Goals", 0);
            yield return CreateCase("Goal sample", BuildJsonPath("Goal", "GetGoalsResponseDto.sample.json"), typeof(GetGoalsResponseDto), "Goals", 0);
            yield return CreateCase("Goal populated", BuildJsonPath("Goal", "GetGoalsResponseDto.populated.json"), typeof(GetGoalsResponseDto), "Goals", 1);

            yield return CreateCase("Label empty", BuildJsonPath("Label", "GetLabelsResponseDto.empty.json"), typeof(GetLabelsResponseDto), "Labels", 0);
            yield return CreateCase("Label sample", BuildJsonPath("Label", "GetLabelsResponseDto.sample.json"), typeof(GetLabelsResponseDto), "Labels", 0);
            yield return CreateCase("Label populated", BuildJsonPath("Label", "GetLabelsResponseDto.populated.json"), typeof(GetLabelsResponseDto), "Labels", 1);

            yield return CreateCase("RecordRule empty", BuildJsonPath("RecordRule", "GetRecordRulesResponseDto.empty.json"), typeof(GetRecordRulesResponseDto), "RecordRules", 0);
            yield return CreateCase("RecordRule sample", BuildJsonPath("RecordRule", "GetRecordRulesResponseDto.sample.json"), typeof(GetRecordRulesResponseDto), "RecordRules", 0);
            yield return CreateCase("RecordRule populated", BuildJsonPath("RecordRule", "GetRecordRulesResponseDto.populated.json"), typeof(GetRecordRulesResponseDto), "RecordRules", 1);

            yield return CreateCase("Record empty", BuildJsonPath("Record", "GetRecordsResponseDto.empty.json"), typeof(GetRecordsResponseDto), "Records", 0);
            yield return CreateCase("Record sample", BuildJsonPath("Record", "GetRecordsResponseDto.sample.json"), typeof(GetRecordsResponseDto), "Records", 0);
            yield return CreateCase("Record populated", BuildJsonPath("Record", "GetRecordsResponseDto.populated.json"), typeof(GetRecordsResponseDto), "Records", 1);

            yield return CreateCase("RecordById empty", BuildJsonPath("Record", "GetRecordsByIdResponseDto.empty.json"), typeof(GetRecordsByIdResponseDto), "Records", 0);
            yield return CreateCase("RecordById sample", BuildJsonPath("Record", "GetRecordsByIdResponseDto.sample.json"), typeof(GetRecordsByIdResponseDto), "Records", 0);
            yield return CreateCase("RecordById populated", BuildJsonPath("Record", "GetRecordsByIdResponseDto.populated.json"), typeof(GetRecordsByIdResponseDto), "Records", 1);

            yield return CreateCase("StandingOrder empty", BuildJsonPath("StandingOrder", "GetStandingOrdersResponseDto.empty.json"), typeof(GetStandingOrdersResponseDto), "StandingOrders", 0);
            yield return CreateCase("StandingOrder sample", BuildJsonPath("StandingOrder", "GetStandingOrdersResponseDto.sample.json"), typeof(GetStandingOrdersResponseDto), "StandingOrders", 0);
            yield return CreateCase("StandingOrder populated", BuildJsonPath("StandingOrder", "GetStandingOrdersResponseDto.populated.json"), typeof(GetStandingOrdersResponseDto), "StandingOrders", 1);
        }

        [TestCaseSource(nameof(ResponseDtoJsonCases))]
        public void Deserialize_FromSampleJsonFile_ReturnsExpectedResponseDtoTypeAndCollectionSize(string relativePath, Type expectedType, string collectionPropertyName, int expectedCollectionCount)
        {
            string normalizedRelativePath = relativePath.Replace('/', Path.DirectorySeparatorChar);
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, normalizedRelativePath);
            string json = File.ReadAllText(path);

            object? dto = null;

            Assert.DoesNotThrow(() => dto = JsonConvert.DeserializeObject(json, expectedType));
            Assert.That(dto, Is.Not.Null);
            Assert.That(dto, Is.InstanceOf(expectedType));

            var collectionProperty = expectedType.GetProperty(collectionPropertyName);
            Assert.That(collectionProperty, Is.Not.Null);

            var collection = collectionProperty!.GetValue(dto) as System.Collections.ICollection;
            Assert.That(collection, Is.Not.Null);
            Assert.That(collection, Has.Count.EqualTo(expectedCollectionCount));
        }

        private static TestCaseData CreateCase(string name, string relativePath, Type expectedType, string collectionPropertyName, int expectedCollectionCount)
            => new TestCaseData(relativePath, expectedType, collectionPropertyName, expectedCollectionCount).SetName(name);

        private static string BuildJsonPath(string dtoArea, string fileName)
            => $"{ResponseDtosTestDataRoot}/{dtoArea}/{fileName}";
    }
}
