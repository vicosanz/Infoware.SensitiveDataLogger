using Newtonsoft.Json;

namespace Infoware.SensitiveDataLogger.JsonSerializer
{
    public class LogJsonSerializer : ILogJsonSerializer
    {
        private readonly JsonSerializerSettings _settings;

        public LogJsonSerializer()
        {
            _settings = new JsonSerializerSettings() { ContractResolver = new CustomDataResolver() };
        }

        public string SerializeObject(object? value)
        {
            return JsonConvert.SerializeObject(value, _settings);
        }
    }
}

