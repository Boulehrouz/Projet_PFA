using Microsoft.AspNetCore.Mvc;
using Projet_PFA.Models;

namespace Projet_PFA.Controllers
{
    public class ChangepsdController : Controller
    {
        MyContext db;
        public ChangepsdController(MyContext db)
        {
            this.db = db;
        }
        public IActionResult test()
        {
            return View();
        }
        public IActionResult Change()
        {
            return View();
        }

        [Route("Changepsd/Change/{id?}")]
        [HttpPost]
        public IActionResult Change(Mdp u)
        {
            if(ModelState.IsValid)
            {
                int id= int.Parse(HttpContext.Session.GetString("Id"));
                string role = HttpContext.Session.GetString("Role");
                if (role == "Directeur")
                {
                    Directeur d = db.Directeur.First(d => d.Id==id);
                    if(d.Password==u.Password)
                    {
                        if(u.NewPassword==u.ConfirmerPassword)
                        {
                            d.Password = u.NewPassword;
                            db.Update(d);
                            db.SaveChanges();
                        }
                    }
                    return RedirectToAction("test");
                }
                    
                
                else if (role == "Employer")
                {
                        Employer e = db.Employer.First(e => e.Id == id);
                        if (e.Password == u.Password)
                        {
                            if (u.NewPassword == u.ConfirmerPassword)
                            {
                                e.Password = u.NewPassword;
                                db.Update(e);
                                db.SaveChanges();
                            }
                        }
                        return RedirectToAction("test");
                    
                }
                else if (role == "Superviseur")
                {
                        Superviseur s = db.Superviseur.First(s => s.Id == id);
                        if (s.Password == u.Password)
                        {
                            if (u.NewPassword == u.ConfirmerPassword)
                            {
                                s.Password = u.NewPassword;
                                db.Update(s);
                                db.SaveChanges();
                            }
                        }
                        return RedirectToAction("test");
                }
            }
            
            return View();
        }
    }
}
