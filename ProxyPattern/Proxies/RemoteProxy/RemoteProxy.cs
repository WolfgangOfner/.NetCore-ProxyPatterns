using System.Threading.Tasks;
using GreeterService;
using Grpc.Net.Client;

namespace ProxyPattern.Proxies.RemoteProxy
{
    public class RemoteProxy : IRemoteProxy
    {
        public async Task<HelloReply> GetGreetingMessage()
        {
            // todo the GreeterService must run for this test to pass
            const string name = "Wolfgang";
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            
            var request = new HelloRequest
            {
                Name = name
            };

            return await client.SayHelloAsync(request);
        }
    }
}