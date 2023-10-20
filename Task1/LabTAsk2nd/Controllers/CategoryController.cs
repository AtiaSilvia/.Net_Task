using LabTAsk2nd.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTAsk2nd.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Caegory data)
        {
            FoodPandaEntities db = new FoodPandaEntities();
            db.Caegories.Add(data);
            db.SaveChanges();
            return RedirectToAction("List");

        }

        public ActionResult List()
        {
            FoodPandaEntities db = new FoodPandaEntities();
            var data = db.Caegories.ToList();
            return View(data);

        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {

            FoodPandaEntities db = new FoodPandaEntities();
            var data = db.Caegories.Find(ID);
            var data1 = (from d in db.Caegories where d.ID == ID select d).SingleOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Caegory caegory)
        {
            FoodPandaEntities db = new FoodPandaEntities();
            var data = db.Caegories.Find(caegory.ID);
            data.Name = caegory.Name;
            
            db.SaveChanges();
            return RedirectToAction("List");

        }

        public ActionResult Delete(int ID)
        {
            FoodPandaEntities db = new FoodPandaEntities();

            var data = db.Caegories.Find(ID);
            db.Caegories.Remove(data);
            db.SaveChanges();
            return RedirectToAction("List");

        }
    }
}