using Microsoft.AspNetCore.Mvc;
using ProxyPattern.Proxies.Smart_Proxy;

namespace ProxyPattern.Controllers
{
    public class SmartProxyController : Controller
    {
        private readonly IFileWriter _fileWriter;

        public SmartProxyController(IFileWriter fileWriter)
        {
            _fileWriter = fileWriter;
        }

        public string WriteToFiles()
        {
            _fileWriter.WriteTwiceToSameFile("file.txt", "Writing the smart proxy message");

            return "Finished writing to your files.";
        }
    }
}