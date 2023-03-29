using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet_PFA.Models;

namespace Projet_PFA.Controllers
{
    public class PenaliteController : Controller
    {
        MyContext db;
        public PenaliteController(MyContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<Penalite> penalites = db.Penalite.ToList();
            return View(penalites);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Penalite p)
        {
            if(ModelState.IsValid)
            {
                db.Penalite.Add(p);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [Route("Penalite/Update/{id}")]
        public IActionResult Update(int id)
        {
            Penalite p = db.Penalite.First(p => p.Id == id);
            return View(p);
        }
        [HttpPost]
        [Route("Penalite/Update/{id}")]
        public IActionResult Update(Penalite penalite)
        {
            if (ModelState.IsValid)
            {
                Penalite p = db.Penalite.First(p => p.Id == penalite.Id);
                if (p != null)
                {
                    p = penalite;
                    db.Update(p);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        [Route("Penalite/Delete/id")]
        public IActionResult Delete(int id)
        {
            Penalite p = db.Penalite.First(p => p.Id == id);
            db.Penalite.Remove(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
