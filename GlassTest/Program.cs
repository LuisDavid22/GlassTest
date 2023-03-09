using GlassTest.Persistence;
using GlassTest.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IDocumentService, DocumentService>();
//builder.Services.AddScoped<IDocumentService, DocumentServiceAlternative>(); //This is the alternate implementation of IDocumentService
builder.Services.AddDbContext<DocumentsDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DocumentDBConnection")));

var app = builder.Build();

app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
