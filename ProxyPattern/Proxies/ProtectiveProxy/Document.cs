using System;

namespace ProxyPattern.Proxies.ProtectiveProxy
{
    public class Document
    {
        protected Document(string name, string content)
        {
            Name = name;
            Content = content;
        }

        public string Name { get; private set; }
        public string Content { get; }
        public DateTime? DateReviewed { get; private set; }

        public static Document CreateDocument(string name, string content)
        {
            return new ProtectiveProxy(name, content);
        }

        public virtual void CompleteReview(User editor)
        {
            DateReviewed = DateTime.UtcNow;
        }

        public virtual void UpdateName(string newName, User user)
        {
            Name = newName;
        }
    }
}