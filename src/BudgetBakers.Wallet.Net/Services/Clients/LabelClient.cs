using System.Collections.Generic;
using FluentResults;
using BudgetBakers.Wallet.Net.Dtos.Label;
using BudgetBakers.Wallet.Net.Models.Label;
using BudgetBakers.Wallet.Net.Services.Executors;
using BudgetBakers.Wallet.Net.Services.Mappers;

namespace BudgetBakers.Wallet.Net.Services.Clients
{
    public class LabelClient : IWalletClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper<GetLabelsRequest, GetLabelsRequestDto> _getLabelsRequestMapper = new GetLabelsRequestMapper();
        private readonly IMapper<GetLabelsResponseDto, GetLabelsResponse> _getLabelsResponseMapper = new GetLabelsResponseMapper();
        private readonly IMapper<CreateLabelRequest, CreateLabelRequestDto> _createLabelRequestMapper = new CreateLabelRequestMapper();
        private readonly IMapper<CreateLabelResponseDto, CreateLabelResponse> _createLabelResponseMapper = new CreateLabelResponseMapper();
        private readonly IMapper<UpdateLabelsRequest, List<UpdateLabelItemDto>> _updateLabelsRequestMapper = new UpdateLabelsRequestMapper();
        private readonly IMapper<UpdateLabelsResponseDto, UpdateLabelsResponse> _updateLabelsResponseMapper = new UpdateLabelsResponseMapper();

        public LabelClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Result<GetLabelsResponse>> GetAsync(GetLabelsRequest request, CancellationToken ct = default)
            => WalletApiGetExecutor.ExecuteAsync<GetLabelsRequest, GetLabelsRequestDto, GetLabelsResponseDto, GetLabelsResponse>(
                _httpClient,
                "/wallet/v1/api/labels",
                request,
                _getLabelsRequestMapper,
                _getLabelsResponseMapper,
                ct);

        public Task<Result<CreateLabelResponse>> CreateAsync(CreateLabelRequest request, CancellationToken ct = default)
            => WalletApiWriteExecutor.ExecuteAsync<CreateLabelRequest, CreateLabelRequestDto, CreateLabelResponseDto, CreateLabelResponse>(
                _httpClient,
                HttpMethod.Post,
                "/wallet/v1/api/labels",
                request,
                _createLabelRequestMapper,
                _createLabelResponseMapper,
                ct: ct);

        public Task<Result<UpdateLabelsResponse>> UpdateAsync(UpdateLabelsRequest request, CancellationToken ct = default)
        {
            string? qs = request is not null && request.ReturnData == true ? "returnData=true" : null;
            return WalletApiWriteExecutor.ExecuteAsync<UpdateLabelsRequest, List<UpdateLabelItemDto>, UpdateLabelsResponseDto, UpdateLabelsResponse>(
                _httpClient,
                HttpMethod.Patch,
                "/wallet/v1/api/labels",
                request!,
                _updateLabelsRequestMapper,
                _updateLabelsResponseMapper,
                qs,
                ct);
        }
    }
}
