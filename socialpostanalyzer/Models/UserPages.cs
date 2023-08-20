using Microsoft.Extensions.Hosting;

namespace socialpostanalyzer.Models
{
    public class UserPages
    {
     
        public int UserPagesId { get; set; }

        public int UserId{ get; set; }
        public User Users { get; set; }

        public int id { get; set; }
        public Page Pages { get; set; }

    }
}
