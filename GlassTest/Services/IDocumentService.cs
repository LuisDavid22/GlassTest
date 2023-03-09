using GlassTest.Models;

namespace GlassTest.Services
{
    public interface IDocumentService
    {
        public List<Document> SearchDocuments();
        public List<Document> SearchDocuments(string query, bool matchAll);

    }
}
