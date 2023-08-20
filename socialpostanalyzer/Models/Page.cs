using System.ComponentModel.DataAnnotations;

namespace socialpostanalyzer.Models
{
    public class Page
    {
        [Key]

        public int id { get; set; }

        public string PageId { get; set; }
        public string PageName { get; set; }
        public string Token { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
        public string? DeletedBy { get; set; }

        public string type { get; set; }
        public ICollection<Post> Posts { get; set; }

        public ICollection<UserPages> UserPages { get; set; }
    }
}
