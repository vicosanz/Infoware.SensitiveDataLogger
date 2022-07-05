using Infoware.SensitiveDataLogger.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace Infoware.SensitiveDataLogger.JsonSerializer
{
    public class CustomDataResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (member is PropertyInfo prop)
            {
                if (Attribute.IsDefined(prop, typeof(SensitiveDataAttribute)))
                {
                    property.ValueProvider = new StringValueProvider("**SensitiveData**");
                }
            }

            return property;
        }
    }
}
