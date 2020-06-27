using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProxyPattern.Proxies.RemoteProxy;

namespace ProxyPattern.Controllers
{
    public class RemoteProxyController : Controller
    {
        private readonly IRemoteProxy _remoteProxy;

        public RemoteProxyController(IRemoteProxy remoteProxy)
        {
            _remoteProxy = remoteProxy;
        }

        public async Task<string> HelloMessage()
        {
            var greetingMessage =  await _remoteProxy.GetGreetingMessage();

            return greetingMessage.Message;
        }
    }
}