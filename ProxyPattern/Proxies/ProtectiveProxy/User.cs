using System.Collections.Generic;

namespace ProxyPattern.Proxies.ProtectiveProxy
{
    public class User
    {
        public string Name { get; set; }

        public Roles Role { get; set; }

        public List<Document> AuthoredDocuments { get; } = new List<Document>();

        public void AddDocument(string documentName, string documentContent)
        {
            var document = Document.CreateDocument(documentName, documentContent);
            AuthoredDocuments.Add(document);
        }
    }
}