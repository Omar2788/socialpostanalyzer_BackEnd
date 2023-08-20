namespace socialpostanalyzer.Controllers
{
    public class SavePublicPagesRequest
    {
        public string Name { get; set; }
        public string PageId { get; set; }
        public string PageName { get; set; }
        public List<SelectedPublicPage> SelectedPublicPages { get; set; }
    }


}