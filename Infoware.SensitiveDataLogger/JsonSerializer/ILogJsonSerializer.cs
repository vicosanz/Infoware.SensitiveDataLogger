namespace Infoware.SensitiveDataLogger.JsonSerializer
{
    public interface ILogJsonSerializer
    {
        string SerializeObject(object? value);
    }
}