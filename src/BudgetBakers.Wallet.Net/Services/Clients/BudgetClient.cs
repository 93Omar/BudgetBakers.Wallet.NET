using System.Collections.Generic;
using FluentResults;
using BudgetBakers.Wallet.Net.Dtos.Budget;
using BudgetBakers.Wallet.Net.Models.Budget;
using BudgetBakers.Wallet.Net.Services.Executors;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Services.Clients
{
    public class BudgetClient : IWalletClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetBudgetsRequest, GetBudgetsRequestDto> _getBudgetsRequestMapper = new GetBudgetsRequestMapper();
        private readonly IMapper<GetBudgetsResponseDto, GetBudgetsResponse> _getBudgetsResponseMapper = new GetBudgetsResponseMapper();
        private readonly IMapper<CreateBudgetRequest, CreateBudgetRequestDto> _createBudgetRequestMapper = new CreateBudgetRequestMapper();
        private readonly IMapper<CreateBudgetResponseDto, CreateBudgetResponse> _createBudgetResponseMapper = new CreateBudgetResponseMapper();
        private readonly IMapper<UpdateBudgetsRequest, List<UpdateBudgetItemDto>> _updateBudgetsRequestMapper = new UpdateBudgetsRequestMapper();
        private readonly IMapper<UpdateBudgetsResponseDto, UpdateBudgetsResponse> _updateBudgetsResponseMapper = new UpdateBudgetsResponseMapper();

        public BudgetClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Result<GetBudgetsResponse>> GetAsync(GetBudgetsRequest request, CancellationToken ct = default)
            => WalletApiGetExecutor.ExecuteAsync<GetBudgetsRequest, GetBudgetsRequestDto, GetBudgetsResponseDto, GetBudgetsResponse>(
                _httpClient,
                "/wallet/v1/api/budgets",
                request,
                _getBudgetsRequestMapper,
                _getBudgetsResponseMapper,
                ct);

        public Task<Result<CreateBudgetResponse>> CreateAsync(CreateBudgetRequest request, CancellationToken ct = default)
            => WalletApiWriteExecutor.ExecuteAsync<CreateBudgetRequest, CreateBudgetRequestDto, CreateBudgetResponseDto, CreateBudgetResponse>(
                _httpClient,
                HttpMethod.Post,
                "/wallet/v1/api/budgets",
                request,
                _createBudgetRequestMapper,
                _createBudgetResponseMapper,
                ct: ct);

        public Task<Result<UpdateBudgetsResponse>> UpdateAsync(UpdateBudgetsRequest request, CancellationToken ct = default)
        {
            string? qs = request is not null && request.ReturnData == true ? "returnData=true" : null;
            return WalletApiWriteExecutor.ExecuteAsync<UpdateBudgetsRequest, List<UpdateBudgetItemDto>, UpdateBudgetsResponseDto, UpdateBudgetsResponse>(
                _httpClient,
                HttpMethod.Patch,
                "/wallet/v1/api/budgets",
                request!,
                _updateBudgetsRequestMapper,
                _updateBudgetsResponseMapper,
                qs,
                ct);
        }
    }
}
