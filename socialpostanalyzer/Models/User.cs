using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace socialpostanalyzer.Models
{
    public class User
    {
        [Key]
        public int UserId{ get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }

        public ICollection<UserPages> UserPages { get; set; }

    }
}
