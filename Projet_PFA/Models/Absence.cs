using System.ComponentModel.DataAnnotations;

namespace Projet_PFA.Models
{
    public class Absence
    {
        public int? Id { get; set; }
        public DateTime? Date { get; set; }
        public Employer? Employer { get; set; }
        public int? EmployerId { get; set; }
        public Superviseur? Superviseur { get; set; }
        public int? SuperviseurId { get; set; }
    }
}
