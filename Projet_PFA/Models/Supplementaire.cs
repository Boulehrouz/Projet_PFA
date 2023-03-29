using Microsoft.EntityFrameworkCore.Migrations;

namespace Projet_PFA.Models
{
    public class Supplementaire
    {
        public int? Id { get; set; }
        public int Duree { get; set; }
        public float Prime { get; set; }
        public string Unite { get; set; }
        
    }
}
