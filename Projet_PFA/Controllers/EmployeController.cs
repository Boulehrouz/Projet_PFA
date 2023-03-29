using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet_PFA.Models;
 

namespace Projet_PFA.Controllers
{
    public class EmployeController : Controller
    {
        MyContext db;//creation un objet mycontext
        public EmployeController(MyContext db)
        {
                this.db = db; //injection de dependance 

        }
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(Employer E)//Employe E katjib les info li kaynin f formulaire 
        {
            if (ModelState.IsValid)
            {
                db.Employer.Add(E);//kat ajouter les info li kaynin f formulaire local 
                db.SaveChanges();//katsefto la base de donne makatkhelihch local 
            }

            return RedirectToAction("AffichageListe");//une fois y ajouter un employer yedih la liste dyal les employes 
        }
        public IActionResult AffichageListe()
        {
            List<Employer> Employers = db.Employer.ToList();           
            return View(Employers);
        }
        [Route("Employe/Update/{id}")]//definire le chemin de l'action
        public IActionResult Update(int id )//Action  1 pour afficher les info dans le formulaire 
        {
            Employer E = db.Employer.First(E => E.Id == id);//Creation d'un objet Employer Et charger leur info men la base de donnée 
            //FirstOrDefault jib ster lwl 
            //db.Employer hia li katjib les info men la base de donnée ye3ni hia la requete

           return View(E);
        }
        [HttpPost]
        [Route("Employe/Update/{id}")]//definire le chemin de l'action

        public IActionResult Update(Employer emp)//Action 2 pour recuperer les info men l formulaire 
        {
            if(ModelState.IsValid)//kat2eked beli les info li kaynin f formulaire ka yresctper les condictions les kaynin f class
            {
                //emp kanjibouh men formulaire kaykon login w mdp null hit ma kandiroch 3lihom une modification 
                Employer E = db.Employer.First(E => E.Id == emp.Id);//E kanjibouh men la base de donne fih ga3 les info le9dam 
                if (E != null)//hna kanchofo wech E li hia objet employe wech jat khawia 
                {
                    emp.Login = E.Login;//kandiro login dyal emp kan3emrouh b login dyal E ye3ni li ja men lformulaire khasna n3ewdouh  beli rah f la base de donnée  
                    emp.Password = E.Password;//la meme chose benesba l mdp
                    E = emp;  //copier les infos li kaynin f formulaire emp f E (E<==emp) 
                    db.Update(E);//modifier les info dyal Employer 
                    db.SaveChanges();//sauvegarder les info dans la base de donnée 
                }
            }
            return RedirectToAction("AffichageListe");//la redirection vers AffichageList 
        }
        [Route("Employe/delete/id")]
        public IActionResult delete(int id )
        {
            Employer emp = db.Employer.First(E => E.Id == id);
            db.Employer.Remove(emp);
            db.SaveChanges();

            return RedirectToAction("AffichageListe");
        }

    }
}
