using Microsoft.AspNetCore.Mvc;
using Projet_PFA.Models;

namespace Projet_PFA.Controllers
{
    public class ProfileController : Controller
    {
        MyContext db;
        public ProfileController(MyContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            string role = HttpContext.Session.GetString("Role");
            if (role == "Directeur")
            {
                return RedirectToAction("Directeur");
            }
            else if (role == "Employer")
            {
                return RedirectToAction("Employer");
            }
            else if (role == "Superviseur")
            {
                return RedirectToAction("Superviseur");
            }
            return View();
        }
        public IActionResult Directeur()
        {
            int id = int.Parse(HttpContext.Session.GetString("Id"));
            Directeur d = db.Directeur.First(d => d.Id == id);
            return View(d);
        }
        [HttpPost]
        [Route("Profile/Directeur/{id?}")]
        public IActionResult Directeur(Directeur u)
        {
            if (ModelState.IsValid)
            {
                int id = int.Parse(HttpContext.Session.GetString("Id"));
                Directeur d = db.Directeur.First(d => d.Id == id);
                if (d != null)
                {
                    u.Id = id;
                    u.Login = d.Login;
                    u.Password = d.Password;
                    d = u;
                    db.Update(d);
                    db.SaveChanges();
                }
            }
            return View("../Login/Admin");
        }
        public IActionResult Employer()
        {
            int id = int.Parse(HttpContext.Session.GetString("Id"));
            Employer e = db.Employer.First(e => e.Id == id);
            return View(e);
        }
        [HttpPost]
        [Route("Profile/Employer/{id?}")]
        public IActionResult Employer(Employer u)
        {
            if (ModelState.IsValid)
            {
                int id = int.Parse(HttpContext.Session.GetString("Id"));
                Employer e = db.Employer.First(e => e.Id == id);
                if (e != null)
                {
                    u.Id = id;
                    u.Login = e.Login;
                    u.Password = e.Password;
                    u.SuperviseurId = e.SuperviseurId;
                    e = u;
                    db.Update(e);
                    db.SaveChanges();
                }
            }
            return View("../Login/Emp");
        }
        public IActionResult Superviseur()
        {
            int id = int.Parse(HttpContext.Session.GetString("Id"));
            Superviseur s = db.Superviseur.First(s => s.Id == id);
            return View(s);
        }
        [HttpPost]
        [Route("Profile/Superviseur/{id?}")]
        public IActionResult Superviseur(Superviseur u)
        {
            if (ModelState.IsValid)
            {
                int id = int.Parse(HttpContext.Session.GetString("Id"));
                Superviseur s = db.Superviseur.First(s => s.Id == id);
                if (s != null)
                {
                    u.Id = id;
                    u.Login = s.Login;
                    u.Password = s.Password;
                    s = u;
                    db.Update(s);
                    db.SaveChanges();
                }
            }
            return View("../Login/Sup");
        }
    }
}
