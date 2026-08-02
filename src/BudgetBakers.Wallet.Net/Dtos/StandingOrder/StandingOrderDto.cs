using System.Collections.Generic;
using Newtonsoft.Json;

namespace BudgetBakers.Wallet.Net.Dtos.StandingOrder
{
    internal class StandingOrderDto
    {
        [JsonProperty("accountId")]
        public string? AccountId { get; set; }

        [JsonProperty("amount")]
        public double? Amount { get; set; }

        [JsonProperty("categoryId")]
        public string? CategoryId { get; set; }

        [JsonProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [JsonProperty("currencyCode")]
        public string? CurrencyCode { get; set; }

        [JsonProperty("dueDate")]
        public string? DueDate { get; set; }

        [JsonProperty("dueDateNotificationEnabled")]
        public bool DueDateNotificationEnabled { get; set; }

        [JsonProperty("generateFromDate")]
        public string? GenerateFromDate { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("labels")]
        public IList<BudgetBakers.Wallet.Net.Dtos.Label.LabelDto> Labels { get; set; } = [];

        [JsonProperty("manualPayment")]
        public bool ManualPayment { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("note")]
        public string? Note { get; set; }

        [JsonProperty("counterParty")]
        public string? CounterParty { get; set; }

        [JsonProperty("recurrenceRule")]
        public string? RecurrenceRule { get; set; }

        [JsonProperty("reminder")]
        public string? Reminder { get; set; }

        [JsonProperty("threeDaysBeforeNotificationEnabled")]
        public bool ThreeDaysBeforeNotificationEnabled { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; set; }
    }
}
