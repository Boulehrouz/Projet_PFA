namespace Projet_PFA.Models
{
    public class Pointage
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime HeureEntree { get; set; }
        public DateTime HeureSortie { get; set; }
        public Employer Employer { get; set; }
        public int EmployerId { get; set; }
        public Superviseur Superviseur { get; set; }
        public int SuperviseurId { get; set; }
    }
}
