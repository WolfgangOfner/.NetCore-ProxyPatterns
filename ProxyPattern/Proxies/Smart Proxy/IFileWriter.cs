namespace ProxyPattern.Proxies.Smart_Proxy
{
    public interface IFileWriter
    {
        void WriteTwiceToSameFile(string outputFile, string message);
    }
}