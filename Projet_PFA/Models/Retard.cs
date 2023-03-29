namespace Projet_PFA.Models
{
    public class Retard
    {
        public int? Id { get; set; }
        public DateTime? Date { get; set; }
        public int? Duree { get; set; }
        public Employer? Employer { get; set; }
        public int? EmployerId { get; set; }
        public Superviseur? Superviseur { get; set; }
        public int? SuperviseurId { get; set; }
    }
}
