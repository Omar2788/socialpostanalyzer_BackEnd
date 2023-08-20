using System.ComponentModel.DataAnnotations;

namespace socialpostanalyzer.Models
{
    public class Post
    {
        [Key]
        public string PostId { get; set; }

        public string ImgAdress { get; set; }
        public string Description { get; set; }

        public int LikesNum { get; set; }
        public int LoveNum { get; set; }

        public int WowNum { get; set; }

        public int SadNum { get; set; }

        public int AngryNum { get; set; }
        public int HahaNum { get; set; }

        public int SharesNum { get; set; }
        public int CommentsNum { get; set; }

        public DateTime CreatedAt { get; set; }

        public int PageId { get; set; }
        public Page page { get; set; }
        public ICollection<Comment> comments { get; set; }
        
    }
}
