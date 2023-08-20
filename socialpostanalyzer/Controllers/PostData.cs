namespace socialpostanalyzer.Controllers
{
    public class PostData
    {
        public string created_time { get; set; }
        public string message { get; set; }
        public CommentData comments { get; set; }
        public ReactionData like { get; set; }
        public ReactionData love { get; set; }
        public ReactionData wow { get; set; }
        public ReactionData sad { get; set; }
        public ReactionData angry { get; set; }
        public ReactionData haha { get; set; }

        public string full_picture { get; set; }
        public string id { get; set; }
    }
}