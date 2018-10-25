using Super_Heroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Super_Heroes.Controllers
{
    public class SuperHeroController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: SuperHero
      
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SuperHeroModel newHero)
        {
            if (ModelState.IsValid)
            {
                db.Superhero.Add(newHero);
                db.SaveChanges();
                return View();
            }

            else
            {
                return View();
            }
        }

            [HttpPost]
        public ActionResult Delete(int Id)
        {
            SuperHeroModel hero = db.Superhero.Where(s => s.Id == Id).Single();
            db.Superhero.Remove(hero);
            db.SaveChanges();
            return View();



        }
        
       public ActionResult Details(int Id)
       {
            SuperHeroModel hero = db.Superhero.Where(s => s.Id == Id).FirstOrDefault();
            return View(hero);
       }
        public ActionResult Edit(int Id)
        {
            var hero = db.Superhero.Where(h => h.Id == Id).FirstOrDefault();
            return View(hero);
        }
        [HttpPost]
        public ActionResult Edit(SuperHeroModel Hero)
        {

        }


    }
}