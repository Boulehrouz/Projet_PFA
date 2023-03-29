using System.ComponentModel.DataAnnotations;

namespace Projet_PFA.Models
{
    public class Login
    {
        [Required]
        public string login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
