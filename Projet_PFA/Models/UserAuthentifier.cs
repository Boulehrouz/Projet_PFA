using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_PFA.Models
{
    public class UserAuthentifier
    {
        public int? Id { get; set; }
        public  string? Login { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [NotMapped]
        [DataType(DataType.Password)]
        public string? ConfirmerPassword { get; set; }
        [Required]
        public string? Nom { get; set; }
        [Required]
        public string? Prenom { get; set; }
        [Required]
        public string? CIN { get; set; }
        [Required]
        public DateTime?  DateNaissance { get; set; }
        [Required]
        public string? Adress { get; set; }
        [Required]
        public string? Tel { get; set; }
        [Required]
        public string? RIB { get; set; }
        [Required]
        public float? Salaire { get; set; }
    }
}
