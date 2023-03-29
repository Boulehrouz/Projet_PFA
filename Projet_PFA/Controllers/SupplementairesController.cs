using Microsoft.AspNetCore.Mvc;
using Projet_PFA.Models;

namespace Projet_PFA.Controllers
{
    public class SupplementairesController : Controller
    {
        MyContext db;//creation un objet mycontext
        public SupplementairesController(MyContext db)
        {
            this.db = db; //injection de dependance 

        }
        public IActionResult AffichageListe()
        {
            List<Supplementaire> supplementaires = db.Supplementaire.ToList();
            return View(supplementaires);

        }
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(Supplementaire supp)
        {
            if (ModelState.IsValid)
            {
                db.Supplementaire.Add(supp);
                db.SaveChanges();
            }

            return RedirectToAction("AffichageListe");
        }
        [Route("Supplementaires/Update/{id}")]//definire le chemin de l'action
        public IActionResult Update(int id)
        {
            Supplementaire supp = db.Supplementaire.First(supp => supp.Id == id);
            return View(supp);
        }
        [HttpPost]
        [Route("Supplementaires/Update/{id}")]//definire le chemin de l'action
        public IActionResult Update(Supplementaire supp)
        {
            if (ModelState.IsValid)
            {
                Supplementaire suppl = db.Supplementaire.First(suppl => suppl.Id == supp.Id);//E kanjibouh men la base de donne fih ga3 les info le9dam 
                if (suppl != null)//hna kanchofo wech E li hia objet employe wech jat khawia 
                {
                    suppl = supp;  //copier les infos li kaynin f formulaire emp f E (E<==emp) 
                    db.Update(suppl);//modifier les info dyal Employer 
                    db.SaveChanges();//sauvegarder les info dans la base de donnée 
                }
            }
            return RedirectToAction("AffichageListe");//la redirection vers AffichageList 
        }
        [Route("Supplementaires/delete/id")]
        public IActionResult delete(int id)
        {
            Supplementaire suppl = db.Supplementaire.First(suppl => suppl.Id == id);
            db.Supplementaire.Remove(suppl);
            db.SaveChanges();

            return RedirectToAction("AffichageListe");
        }
    }
}
