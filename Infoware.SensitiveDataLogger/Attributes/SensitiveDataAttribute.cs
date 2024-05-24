using Infoware.SensitiveDataLogger.JsonSerializer;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Infoware.SensitiveDataLogger.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SensitiveDataAttribute : JsonConverterAttribute
    {
        public override JsonConverter? CreateConverter(Type typeToConvert)
        {
            JsonConverter converter = (JsonConverter)Activator.CreateInstance(
                typeof(SensitiveDataJsonConverter<>)
                    .MakeGenericType([typeToConvert]),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: null,
                culture: null)!;

            return converter;
        }
    }
}
