﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Projet_PFA.Models;


namespace Projet_PFA.Controllers
{
    public class LoginController : Controller
    {
        MyContext db;
        public LoginController(MyContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Login u)
        {
            string msg = "";
            if (ModelState.IsValid)
            {
                Directeur d = db.Directeur.FirstOrDefault(d => d.Login == u.login && d.Password == u.Password);
                Employer e = db.Employer.FirstOrDefault(e => e.Login == u.login && e.Password == u.Password);
                Superviseur s = db.Superviseur.FirstOrDefault(s => s.Login == u.login && s.Password == u.Password);
                if(d != null)
                {
                    HttpContext.Session.SetString("Name",d.Nom  + " " + d.Prenom );
                    HttpContext.Session.SetString("Role", "Directeur");
                    HttpContext.Session.SetString("Id", d.Id.ToString());
                    return RedirectToAction("Directeur","Profile");
                }
                else if(e !=null)
                {
                    HttpContext.Session.SetString("Name", e.Nom + " " + e.Prenom);
                    HttpContext.Session.SetString("Role", "Employer");
                    HttpContext.Session.SetString("Id", e.Id.ToString());
                    return RedirectToAction("Employer","Profile");
                }
                else if (s != null)
                {
                    HttpContext.Session.SetString("Name", s.Nom + " " + s.Prenom);
                    HttpContext.Session.SetString("Role", "Superviseur");
                    HttpContext.Session.SetString("Id", s.Id.ToString());
                    return RedirectToAction("Superviseur","Profile");
                }
                else msg = "Login/Password incorrect!!";
            }

            ViewBag.msg = msg;
                return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
