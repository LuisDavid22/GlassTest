using GlassTest.Helpers;
using GlassTest.Models;
using GlassTest.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GlassTest.Services
{
    /// <summary>
    /// This IDocumentService implementation uses the SQL Server Full-Text Search capabilities.
    /// </summary>
    public class DocumentService : IDocumentService
    {
        private readonly DocumentsDbContext _dbContext;

        public DocumentService(DocumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Document> SearchDocuments()
        {
            return _dbContext.Documents.ToList(); 
        }

        public List<Document> SearchDocuments(string query, bool matchAll)
        {
            try
            {
                if (matchAll)
                    return GetDocumentsMatchingAll(query);


                return GetDocumentsMatchingAny(query);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// This method returns documents matching the whole query.
        /// </summary>
        private List<Document> GetDocumentsMatchingAll(string query)
        {
            return _dbContext.Documents
                    .Where(d => EF.Functions.Contains(d.Content, $"\"{query}\"")).ToList();
        }
        /// <summary>
        /// This method returns documents mathching any of the keywords
        /// </summary>
        private List<Document> GetDocumentsMatchingAny(string query)
        {
            var keywords = SqlHelper.SplitQueryByKeywords(query);

            return _dbContext.Documents
                    .Where(d => EF.Functions.Contains(d.Content, $"{keywords}")).ToList();
        }


    }
}
