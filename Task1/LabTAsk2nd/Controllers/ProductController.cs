using LabTAsk2nd.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTAsk2nd.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductList()
        {
            FoodPandaEntities db = new FoodPandaEntities();
            return View(db.Products.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product data)
        {
            FoodPandaEntities db = new FoodPandaEntities();
            db.Products.Add(data);
            db.SaveChanges();
            return RedirectToAction("List");

        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {

            FoodPandaEntities db = new FoodPandaEntities();
            var data = db.Products.Find(ID);
            var data1 = (from d in db.Products where d.ID == ID select d).SingleOrDefault();  
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            FoodPandaEntities db = new FoodPandaEntities();
            var data = db.Products.Find(product.ID);
            data.Name = product.Name;
            data.Price = product.Price;
            data.CaegoriesID = product.CaegoriesID;
            db.SaveChanges();
            return RedirectToAction("List");

        }

        public ActionResult List()
        {
            FoodPandaEntities db = new FoodPandaEntities();
            var data = db.Products.ToList();
            return View(data);
           
        }


        public ActionResult Delete(int ID)
        {
            FoodPandaEntities db = new FoodPandaEntities();
         
            var data = db.Products.Find(ID);
            db.Products.Remove(data);
            db.SaveChanges();
            return RedirectToAction("List");

        }


    }
}