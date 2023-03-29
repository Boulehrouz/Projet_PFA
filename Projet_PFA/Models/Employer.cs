namespace Projet_PFA.Models
{
    public class Employer : UserAuthentifier
    {
        public Superviseur? Superviseur { get; set; }
        public int? SuperviseurId { get; set; }
        public ICollection<Pointage>? Pointages { get; set; }
        public ICollection<HeuresSupp>? HeuresSupps { get; set; }
        public ICollection<Retard>? Retards { get; set; }
        public ICollection<Absence>? Absences { get; set; }

    }
}
