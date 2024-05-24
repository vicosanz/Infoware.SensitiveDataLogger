using System.Text.Json;

namespace Infoware.SensitiveDataLogger.JsonSerializer
{
    public class LogJsonSerializer : ILogJsonSerializer
    {
        private readonly JsonSerializerOptions _defaultSettings;

        public LogJsonSerializer()
        {
            _defaultSettings = new JsonSerializerOptions();
        }

        public string SerializeObject(object? value, JsonSerializerOptions? settings = null) =>
            System.Text.Json.JsonSerializer.Serialize(value, settings ?? _defaultSettings);

        public string Serialize<T>(T? value, JsonSerializerOptions? settings = null) =>
            System.Text.Json.JsonSerializer.Serialize(value, settings ?? _defaultSettings);
    }
}

