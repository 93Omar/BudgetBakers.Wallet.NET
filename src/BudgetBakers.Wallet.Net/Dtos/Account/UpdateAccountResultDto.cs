using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.Account
{
    internal class UpdateAccountResultDto
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("account")]
        public AccountDto? Account { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }

        [JsonProperty("errorType")]
        public string? ErrorType { get; set; }
    }
}
