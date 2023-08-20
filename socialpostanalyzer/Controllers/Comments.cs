using socialpostanalyzer.Models;

namespace socialpostanalyzer.Controllers
{
    public class Comments
    {
        public string Text { get; set; }

        public string CommentCreatedAt { get; set; }

        public CommentReaction Reactions { get; set; }
    }
}