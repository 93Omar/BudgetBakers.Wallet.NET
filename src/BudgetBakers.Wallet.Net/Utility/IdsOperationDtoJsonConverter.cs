using BudgetBakers.Wallet.Net.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BudgetBakers.Wallet.Net.Utility
{
    internal class IdsOperationDtoJsonConverter : JsonConverter<IdsOperationDto>
    {
        public override void WriteJson(JsonWriter writer, IdsOperationDto? value, JsonSerializer serializer)
        {
            if (value?.ReplaceWith is not null)
            {
                serializer.Serialize(writer, value.ReplaceWith);
                return;
            }

            JObject jsonObject = new JObject();

            if (value?.Add is not null)
                jsonObject["add"] = JToken.FromObject(value.Add, serializer);

            if (value?.Remove is not null)
                jsonObject["remove"] = JToken.FromObject(value.Remove, serializer);

            jsonObject.WriteTo(writer);
        }

        public override IdsOperationDto? ReadJson(JsonReader reader, Type objectType, IdsOperationDto? existingValue, bool hasExistingValue, JsonSerializer serializer)
            => throw new NotSupportedException($"{nameof(IdsOperationDto)} is write-only.");
    }
}
