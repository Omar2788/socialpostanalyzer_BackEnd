using System.ComponentModel.DataAnnotations;

namespace socialpostanalyzer.Models
{
    public class Reaction
    {
        [Key]
        public int ReactionId { get; set; }

        public int  Love { get; set;}
        public int Like { get; set; }
        public int Wow { get; set; }
        public int Sad { get; set; }
        public int Angry { get; set; }
        public int Haha { get; set; }


        public Post post { get; set; }

        public Comment comment { get; set; }

    }
}
