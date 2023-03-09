using System.ComponentModel.DataAnnotations;

namespace GlassTest.Models
{

    public class Document
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
