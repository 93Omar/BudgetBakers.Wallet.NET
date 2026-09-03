using BudgetBakers.Wallet.Net.Dtos;
using BudgetBakers.Wallet.Net.Dtos.Record;
using BudgetBakers.Wallet.Net.Models.Record;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Tests.Mappers
{
    public class CreateRecordsResponseMapperTests
    {
        [Test]
        public void Map_WhenSourceIsNull_ReturnsNull()
        {
            var mapper = new CreateRecordsResponseMapper();

            CreateRecordsResponse? result = mapper.Map(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Map_WhenResultHasCreatedMirrorRecordId_MapsMirrorId()
        {
            var mapper = new CreateRecordsResponseMapper();
            var source = new CreateRecordsResponseDto
            {
                Results = new List<CreateRecordResultDto>
                {
                    new()
                    {
                        InputIndex = 0,
                        Id = "rec-a",
                        Success = true,
                        CreatedMirrorRecordId = null
                    },
                    new()
                    {
                        InputIndex = 1,
                        Id = "rec-b",
                        Success = true,
                        CreatedMirrorRecordId = "rec-b-mirror"
                    }
                },
                Summary = new BatchOperationSummaryDto { Total = 2, Succeeded = 2, ClientErrors = 0, ServerErrors = 0, DocumentsWritten = 3 }
            };

            CreateRecordsResponse? result = mapper.Map(source);

            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result!.Results, Has.Count.EqualTo(2));
                Assert.That(result.Results[0].CreatedMirrorRecordId, Is.Null);
                Assert.That(result.Results[1].CreatedMirrorRecordId, Is.EqualTo("rec-b-mirror"));
                Assert.That(result.Summary.DocumentsWritten, Is.EqualTo(3));
            }
        }
    }
}
