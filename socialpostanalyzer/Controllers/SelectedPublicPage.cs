namespace socialpostanalyzer.Controllers
{
    public class SelectedPublicPage
    {
        public string PageId { get; set; }
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
        

        public string Text { get; set; }
        public string ReactionId { get; set; }
        public string ReactionName { get; set; }

        public List<Comments> comment { get; set; }

    }

}