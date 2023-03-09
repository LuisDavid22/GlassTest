using GlassTest.Helpers;
using GlassTest.Models;
using GlassTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlassTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet(Name = "GetDocuments")]
        public IActionResult Get(string? query, bool matchAll)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var documents = new List<Document>();

            if (string.IsNullOrWhiteSpace(query))
            {
                documents = _documentService.SearchDocuments(); //Returns all documents
            }
            else
            {
                documents = _documentService.SearchDocuments(query, matchAll); //Returns documents filtering by query
            }

            return Ok(documents);

        }
    }
}

