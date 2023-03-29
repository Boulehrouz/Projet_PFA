using Microsoft.AspNetCore.Mvc;
using Projet_PFA.Models;

namespace Projet_PFA.Controllers
{
    public class AbsenceController : Controller
    {
        MyContext db;//creation un objet mycontext
        public AbsenceController(MyContext db)
        {
            this.db = db; //injection de dependance 

        }

        [Route("Absence/AddAbsn/{id}")]
        public IActionResult AddAbsn(int id )
        {
          
            HttpContext.Session.SetString("idEmploye", id.ToString());
            return View();
        }
        [HttpPost]
        [Route("Absence/AddAbsn/{id}")]
        public IActionResult AddAbsn(Absence A, DateTime dateAbsn)//A creation d'un object
        {
            if (ModelState.IsValid)
            {
                A.Date = dateAbsn;
                int idSupeviseur = int.Parse(HttpContext.Session.GetString("Id"));
                int idEmploye = int.Parse(HttpContext.Session.GetString("idEmploye"));
                A.SuperviseurId=idSupeviseur;
                A.EmployerId = idEmploye;
                A.Id = null;
                db.Absence.Add(A);//kat ajouter les info li kaynin f formulaire local 
                db.SaveChanges();//katsefto la base de donne makatkhelihch local 
            }

            return RedirectToAction("AffichageListe");//une fois y ajouter un employer yedih la liste dyal les employes
           
        }
        public IActionResult AffichageListe()
        {
            List<Absence> Absences = db.Absence.ToList();//kanjibo la liste dyal les absences
            return View(Absences);
        }
        [Route("Absence/Update/{id}")]//chemin url
        public IActionResult Update(int id)
        {
            Absence A = db.Absence.First(A => A.Id == id);//Requete
            return View(A);
        }
        [HttpPost]
        [Route("Absence/Update/{id}")]//chemin url
        public IActionResult Update(Absence abs,DateTime date)//Action 2 pour recuperer les info men l formulaire 
        {
            if (ModelState.IsValid)//kat2eked beli les info li kaynin f formulaire ka yresctper les condictions les kaynin f class
            {

                //emp kanjibouh men formulaire kaykon login w mdp null hit ma kandiroch 3lihom une modification 
               Absence A = db.Absence.First(A => A.Id == abs.Id);//E kanjibouh men la base de donne fih ga3 les info le9dam 
                if (A != null)//hna kanchofo wech E li hia objet employe wech jat khawia 
                {
                    abs.EmployerId = A.EmployerId;
                    abs.SuperviseurId = A.SuperviseurId;
                     abs.Date=date;//kandiro login dyal emp kan3emrouh b login dyal E ye3ni li ja men lformulaire khasna n3ewdouh  beli rah f la base de donnée  
                    A = abs;   
                    db.Update(A);//modifier les info dyal Employer 
                    db.SaveChanges();//sauvegarder les info dans la base de donnée 
                }
            }

            return RedirectToAction("AffichageListe");//la redirection vers AffichageList 
        }
        [Route("Absence/delete/{id}")]
        public IActionResult delete(int id)
        {
            Absence abs = db.Absence.First(A => A.Id == id);
            db.Absence.Remove(abs);
            db.SaveChanges();
            return RedirectToAction("AffichageListe");
        }
    }
}
