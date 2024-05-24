using System.Text.Json;

namespace Infoware.SensitiveDataLogger.JsonSerializer
{
    public interface ILogJsonSerializer
    {
        string SerializeObject(object? value, JsonSerializerOptions? settings = null);
        string Serialize<T>(T? value, JsonSerializerOptions? settings = null);
    }
}