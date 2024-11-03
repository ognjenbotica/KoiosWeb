using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;

namespace Koios.UI.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get { return _httpClient; }
        }

        static partial void UpdateJsonSerializerSettings(JsonSerializerSettings settings)
        {
            settings.ContractResolver = new SafeContractResolver();
        }

        class SafeContractResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var jsonProp = base.CreateProperty(member, memberSerialization);
                jsonProp.Required = Required.Default;
                return jsonProp;
            }
        }
    }
}
