using FluentResults;
using BudgetBakers.Wallet.Net.Constants;
using BudgetBakers.Wallet.Net.Dtos.Delete;
using BudgetBakers.Wallet.Net.Models.Delete;
using BudgetBakers.Wallet.Net.Services.Executors;
using BudgetBakers.Wallet.Net.Services.Mappers;
using BudgetBakers.Wallet.Net.Utility;

namespace BudgetBakers.Wallet.Net.Services.Clients
{
    public class DeleteClient : IWalletClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<DeleteEntitiesRequest, DeleteEntitiesRequestDto> _deleteEntitiesRequestMapper = new DeleteEntitiesRequestMapper();
        private readonly IMapper<DeleteEntitiesResponseDto, DeleteEntitiesResponse> _deleteEntitiesResponseMapper = new DeleteEntitiesResponseMapper();

        public DeleteClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Result<DeleteEntitiesResponse>> DeleteAsync(DeleteEntitiesRequest request, CancellationToken ct = default)
        {
            if (request is null)
            {
                Result<DeleteEntitiesResponse> nullRequestResult = Result.Fail<DeleteEntitiesResponse>(
                    new Error(ApiConstant.Message.NullRequest).WithMetadata(ApiConstant.Metadata.Endpoint, ApiConstant.Endpoint.DeleteTemplate));

                return Task.FromResult(nullRequestResult);
            }

            return WalletApiWriteExecutor.ExecuteAsync<DeleteEntitiesRequest, DeleteEntitiesRequestDto, DeleteEntitiesResponseDto, DeleteEntitiesResponse>(
                _httpClient,
                HttpMethod.Delete,
                string.Format(ApiConstant.Endpoint.DeleteTemplate, request.EntityType.ToApiString()),
                request,
                _deleteEntitiesRequestMapper,
                _deleteEntitiesResponseMapper,
                ct: ct);
        }
    }
}
