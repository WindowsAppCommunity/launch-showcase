using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LaunchShowcase.Sdk
{
    public class NewtonsoftSerializer : ISerializer
    {
        private readonly JsonSerializerSettings _settings;

        public static NewtonsoftSerializer Instance { get; } = new NewtonsoftSerializer();

        public NewtonsoftSerializer()
        {
            _settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
            };
        }

        public T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data, _settings);
        }

        public string Serialize(object data)
        {
            return JsonConvert.SerializeObject(data, _settings);
        }
    }
}
