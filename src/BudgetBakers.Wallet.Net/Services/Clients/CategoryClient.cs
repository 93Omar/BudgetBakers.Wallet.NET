using System.Collections.Generic;
using FluentResults;
using BudgetBakers.Wallet.Net.Dtos.Category;
using BudgetBakers.Wallet.Net.Models.Category;
using BudgetBakers.Wallet.Net.Services.Executors;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Services.Clients
{
    public class CategoryClient : IWalletClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetCategoriesRequest, GetCategoriesRequestDto> _getCategoriesRequestMapper = new GetCategoriesRequestMapper();
        private readonly IMapper<GetCategoriesResponseDto, GetCategoriesResponse> _getCategoriesResponseMapper = new GetCategoriesResponseMapper();
        private readonly IMapper<CreateSubcategoryRequest, CreateSubcategoryRequestDto> _createSubcategoryRequestMapper = new CreateSubcategoryRequestMapper();
        private readonly IMapper<CreateCategoryResponseDto, CreateCategoryResponse> _createCategoryResponseMapper = new CreateCategoryResponseMapper();
        private readonly IMapper<UpdateCategoriesRequest, List<UpdateCategoryItemDto>> _updateCategoriesRequestMapper = new UpdateCategoriesRequestMapper();
        private readonly IMapper<UpdateCategoriesResponseDto, UpdateCategoriesResponse> _updateCategoriesResponseMapper = new UpdateCategoriesResponseMapper();

        public CategoryClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Result<GetCategoriesResponse>> GetAsync(GetCategoriesRequest request, CancellationToken ct = default)
            => WalletApiGetExecutor.ExecuteAsync<GetCategoriesRequest, GetCategoriesRequestDto, GetCategoriesResponseDto, GetCategoriesResponse>(
                _httpClient,
                "/wallet/v1/api/categories",
                request,
                _getCategoriesRequestMapper,
                _getCategoriesResponseMapper,
                ct);

        public Task<Result<CreateCategoryResponse>> CreateCustomAsync(CreateSubcategoryRequest request, CancellationToken ct = default)
            => WalletApiWriteExecutor.ExecuteAsync<CreateSubcategoryRequest, CreateSubcategoryRequestDto, CreateCategoryResponseDto, CreateCategoryResponse>(
                _httpClient,
                HttpMethod.Post,
                "/wallet/v1/api/categories/custom",
                request,
                _createSubcategoryRequestMapper,
                _createCategoryResponseMapper,
                ct: ct);

        public Task<Result<UpdateCategoriesResponse>> UpdateAsync(UpdateCategoriesRequest request, CancellationToken ct = default)
        {
            string? qs = request is not null && request.ReturnData == true ? "returnData=true" : null;
            return WalletApiWriteExecutor.ExecuteAsync<UpdateCategoriesRequest, List<UpdateCategoryItemDto>, UpdateCategoriesResponseDto, UpdateCategoriesResponse>(
                _httpClient,
                HttpMethod.Patch,
                "/wallet/v1/api/categories",
                request!,
                _updateCategoriesRequestMapper,
                _updateCategoriesResponseMapper,
                qs,
                ct);
        }
    }
}
