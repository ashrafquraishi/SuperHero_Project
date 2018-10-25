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
            List<SuperHeroModel> superHeroes = new List<SuperHeroModel>();
            superHeroes = db.Superhero.ToList();
            return View(superHeroes);
        }

        //GET:
        public ActionResult Create()
        {
            SuperHeroModel createsuperhero = new SuperHeroModel();
            return View();
        }



        [HttpPost]
        public ActionResult Create([Bind(Include = "SuperHeroName,primarysuperheroability,secondarysuperheroability,alterego,catchPhrase")] SuperHeroModel newHero)
        {

            db.Superhero.Add(newHero);
            db.SaveChanges();
            return View("Index");

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
            return RedirectToAction("Index");
        }


    }
}