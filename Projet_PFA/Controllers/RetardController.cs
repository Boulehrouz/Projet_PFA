using Microsoft.AspNetCore.Mvc;
using Projet_PFA.Models;

namespace Projet_PFA.Controllers
{
    public class RetardController : Controller
    {
        MyContext db;//creation un objet mycontext
        public RetardController(MyContext db)
        {
            this.db = db; //injection de dependance 

        }

        [Route("Retard/Add/{id?}")]
        public IActionResult Add(int id)
        {

            HttpContext.Session.SetString("idEmploye", id.ToString());
            return View();
        }
        [HttpPost]
        [Route("Retard/Add/{id?}")]
        public IActionResult Add(Retard R,DateTime date)//A creation d'un object
        {
            if (ModelState.IsValid)
            {
                int idSupeviseur = int.Parse(HttpContext.Session.GetString("Id"));
                int idEmploye = int.Parse(HttpContext.Session.GetString("idEmploye"));
                R.SuperviseurId = idSupeviseur;
                R.EmployerId = idEmploye;
                R.Date = date;
                R.Id = null;
                db.Retard.Add(R);
                db.SaveChanges();
            }

            return RedirectToAction("Index");//une fois y ajouter un employer yedih la liste dyal les employes

        }
        public IActionResult Index()
        {
            List<Retard> Retards = db.Retard.ToList();
            return View(Retards);
        }
        [Route("Retard/Update/{id}")]
        public IActionResult Update(int id)
        {
            Retard R = db.Retard.First(R => R.Id == id);
            return View(R);
        }
        [HttpPost]
        [Route("Retard/Update/{id}")]
        public IActionResult Update(Retard R,DateTime date)
        {
            if (ModelState.IsValid)
            {
                Retard Re = db.Retard.First(Re => Re.Id == R.Id);
                if (Re != null)
                {
                    R.SuperviseurId = Re.SuperviseurId;
                    R.EmployerId = Re.EmployerId;
                    R.Date = date;
                    Re = R;
                    db.Update(Re);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult delete(int id)
        {
            Retard R = db.Retard.First(R => R.Id == id);
            db.Retard.Remove(R);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
