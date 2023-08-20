using socialpostanalyzer.Models;

namespace socialpostanalyzer.Controllers
{
    public class CommentData
    {
        public List<CommentPost> Data { get; set; }
        public Summary Summary { get; set; }
    }
}