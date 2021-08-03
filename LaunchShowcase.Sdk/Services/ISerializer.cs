using System.IO;
using System.Threading.Tasks;

namespace LaunchShowcase.Sdk.Services
{
    public interface ISerializer
    {
        string Serialize(object data);

        T Deserialize<T>(string data);
    }
}
