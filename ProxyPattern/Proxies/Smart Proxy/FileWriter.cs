using System.Text;

namespace ProxyPattern.Proxies.Smart_Proxy
{
    public class FileWriter : IFileWriter
    {
        public void WriteTwiceToSameFile(string outputFile, string message)
        {
            var smartProxy = new SmartProxy();

            using var file = smartProxy.OpenWrite(outputFile);
            using var file2 = smartProxy.OpenWrite(outputFile);

            file.Write(Encoding.ASCII.GetBytes(message));
            file2.Write(Encoding.ASCII.GetBytes(message));

            file.Close();
            file2.Close();
        }
    }
}