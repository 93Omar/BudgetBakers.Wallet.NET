using BudgetBakers.Wallet.Net.Utility;
using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos
{
    [JsonConverter(typeof(IdsOperationDtoJsonConverter))]
    internal class IdsOperationDto
    {
        public IList<string>? ReplaceWith { get; set; }
        public IList<string>? Add { get; set; }
        public IList<string>? Remove { get; set; }
    }
}
