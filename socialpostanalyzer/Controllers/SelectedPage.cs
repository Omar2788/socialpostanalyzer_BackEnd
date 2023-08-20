namespace socialpostanalyzer.Controllers
{
    public class SelectedPage
    {

        public string PageId { get; set; }
        public string PageName { get; set; }
        public string accessToken{ get; set; }

        public FeedData feedData { get; set; }

    }
}