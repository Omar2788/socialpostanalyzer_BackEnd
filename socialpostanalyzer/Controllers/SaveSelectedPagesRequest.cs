namespace socialpostanalyzer.Controllers
{
    public class SaveSelectedPagesRequest
    {
        public string Name { get; set; }
        public List<SelectedPage> SelectedPages { get; set; }
    }
}
