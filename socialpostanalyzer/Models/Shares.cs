using System.ComponentModel.DataAnnotations;

namespace socialpostanalyzer.Models
{
    public class Shares
    {
        [Key]
        public int ShareId { get; set; }

        public Post post { get; set; }

    }
}
