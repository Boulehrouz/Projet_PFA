namespace Projet_PFA.Models
{
    public class HeuresSupp
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Duree { get; set; }
        public string Unitee { get; set; }
        public Employer Employer { get; set; }
        public int EmployerId { get; set; }
        public Superviseur Superviseur { get; set; }
        public int SuperviseurId { get; set; }

    }
}
