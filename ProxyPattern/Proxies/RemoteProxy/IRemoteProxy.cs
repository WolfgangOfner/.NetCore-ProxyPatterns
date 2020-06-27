using System.Threading.Tasks;
using GreeterService;

namespace ProxyPattern.Proxies.RemoteProxy
{
    public interface IRemoteProxy
    {
        Task<HelloReply> GetGreetingMessage();
    }
}