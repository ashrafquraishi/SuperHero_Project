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
            superHeroes = db.SuperHeroModels.ToList();
            return View(superHeroes);
        }

        //GET:
        public ActionResult Create()
        {
            SuperHeroModel createsuperhero = new SuperHeroModel();
            return View(createsuperhero);
        }



        [HttpPost]
        public ActionResult Create([Bind(Include = "SuperHeroName,primarysuperheroability,secondarysuperheroability,alterego,catchPhrase")] SuperHeroModel newHero)
        {

            db.SuperHeroModels.Add(newHero);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        
        public ActionResult Delete(int Id)
        {
            SuperHeroModel hero = db.SuperHeroModels.Where(s => s.Id == Id).SingleOrDefault();
            db.SuperHeroModels.Remove(hero);
            db.SaveChanges();
            return RedirectToAction("Index");



        }
        
       public ActionResult Details(int Id)
       {
           var hero = db.SuperHeroModels.Where(s => s.Id == Id).First();
            return View(hero);
       }
        [HttpPost]
        public ActionResult Details(int Id, SuperHeroModel superHero)
        {
          SuperHeroModel Hero = db.SuperHeroModels.Where(s => s.Id ==superHero.Id).First();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            var hero = db.SuperHeroModels.Where(h => h.Id == Id).FirstOrDefault();
            return View(hero);
        }
        [HttpPost]
        public ActionResult Edit(SuperHeroModel Hero)
        {
            var foundHero = db.SuperHeroModels.Where(h => h.Id == Hero.Id).FirstOrDefault();
            foundHero.alterego = Hero.alterego;
            foundHero.catchPhrase = Hero.catchPhrase;
            foundHero.primarysuperheroability= Hero.primarysuperheroability;
            foundHero.secondarysuperheroability = Hero.secondarysuperheroability;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}