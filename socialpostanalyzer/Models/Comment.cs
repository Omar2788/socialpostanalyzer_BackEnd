using System.ComponentModel.DataAnnotations;

namespace socialpostanalyzer.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public string CreatedAt { get; set; }
        public string Text { get; set; }


        public Post post { get; set; }


    }
}
