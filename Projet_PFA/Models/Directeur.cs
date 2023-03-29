namespace Projet_PFA.Models
{
    public class Directeur: UserAuthentifier
    {
        public ICollection<Superviseur>? Superviseurs { get; set; }
    }
}
