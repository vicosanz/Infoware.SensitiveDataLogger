using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infoware.SensitiveDataLogger.JsonSerializer
{
    public class SensitiveDataJsonConverter<T> : JsonConverter<T>
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            System.Text.Json.JsonSerializer.Deserialize<T>(ref reader, options);

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) =>
            writer.WriteStringValue(Constants.SensitiveDataLegend);
    }

}
