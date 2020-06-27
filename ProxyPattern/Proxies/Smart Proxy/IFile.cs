using System.IO;

namespace ProxyPattern.Proxies.Smart_Proxy
{
    public interface IFile
    {
        FileStream OpenWrite(string path);
    }
}