using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projet_PFA.Models
{
    public class Mdp
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [NotMapped]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [NotMapped]
        [DataType(DataType.Password)]
        public string ConfirmerPassword { get; set; }
    }
}
