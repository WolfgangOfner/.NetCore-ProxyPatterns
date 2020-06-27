using System;
using FluentAssertions;
using Xunit;

namespace ProxyPattern.Proxies.ProtectiveProxy
{
    public class ProtectiveProxyTests
    {
        private string _documentName = "name";
        private string _documentContent = "content";

        [Fact]
        public void ThrowsUnauthorizedExceptionGivenUserNotInAuthorRole()
        {
            var editor = new User
            {
                Role = Roles.Editor
            };
            var document = new ProtectiveProxy(_documentName, _documentContent);

            document.Invoking(x => x.UpdateName(_documentName, editor)).Should().Throw<UnauthorizedAccessException>();
        }

        [Fact]
        public void UpdatesNameGivenUserInAuthorRole()
        {
            var author = new User
            {
                Role = Roles.Author
            };
            var document = Document.CreateDocument(_documentName, _documentContent);

            var newName = "new name";
            document.UpdateName(newName, author);

            document.Name.Should().Be(newName);
        }

        [Fact]
        public void SetsDateReviewedToCurrentDateTime()
        {
            var editor = new User { Role = Roles.Editor };
            var document = Document.CreateDocument(_documentName, _documentContent);

            document.CompleteReview(editor);

            (DateTime.UtcNow - document.DateReviewed).Should().BeLessThan(TimeSpan.FromMilliseconds(500));
        }

        [Fact]
        public void ThrowsUnauthorizedExceptionAndDoesNotSetDateReviewed()
        {
            var author = new User { Role = Roles.Author };
            var document = Document.CreateDocument(_documentName, _documentContent);

            document.Invoking(x => x.CompleteReview(author)).Should().Throw<UnauthorizedAccessException>();
            document.DateReviewed.Should().BeNull();
        }

        [Fact]
        public void AddsDocumentToAuthoredDocuments()
        {
            var author = new User { Role = Roles.Author };

            author.AddDocument(_documentName, _documentContent);

            author.AuthoredDocuments.Should().Contain(x => x.Name == _documentName);
        }
    }
}