using GlassTest.Helpers;
using GlassTest.Models;
using GlassTest.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GlassTest.Services
{
    /// <summary>
    /// This IDocumentService implementation uses "Like" comparison to performs the search
    /// </summary>
    public class DocumentServiceAlternative : IDocumentService
    {
        private readonly DocumentsDbContext _dbContext;

        public DocumentServiceAlternative(DocumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Document> SearchDocuments()
        {
            return _dbContext.Documents.ToList();
        }

        public List<Document> SearchDocuments(string query, bool matchAll)
        {
            if (matchAll)
                return GetDocumentsMatchingAll(query); //call method that return documents matching the whole query


            return GetDocumentsMatchingAny(query); //call method that return documents mathching any of the keywords
        }
        /// <summary>
        /// This method returns documents matching the whole query.
        /// </summary>
        private List<Document> GetDocumentsMatchingAll(string query)
        {
            return _dbContext.Documents
                    .Where(d => EF.Functions.Like(d.Content, $"%{query}%")).ToList();
        }
        /// <summary>
        /// This method returns documents mathching any of the keywords
        /// </summary>
        private List<Document> GetDocumentsMatchingAny(string query)
        {
            var likeStatement = SqlHelper.GetLikeStatement(nameof(Document.Content), query);

            return _dbContext.Documents.FromSqlRaw($"SELECT Id,Title,Content FROM Documents WHERE {likeStatement}").ToList();

        }
    }
}
