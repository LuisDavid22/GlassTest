using GlassTest.Models;
using Microsoft.EntityFrameworkCore;

namespace GlassTest.Persistence
{
    public class DocumentsDbContext : DbContext
    {
        public DocumentsDbContext(DbContextOptions<DocumentsDbContext> options) : base(options)
        {
            
        }
        public DbSet<Document> Documents { get; set; } = null!;
    }
}
