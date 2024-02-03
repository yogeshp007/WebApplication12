using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ManageCategoryController : Controller
    {
        private MyAppDBEntities db = new MyAppDBEntities();

        public ActionResult AddCatgory()
        {
            ViewBag.categoryList = db.tblCategories;
            return View();
        }


        [HttpPost]
        public ActionResult AddCatgory(FormCollection fc)
        {
            tblCategory category = new tblCategory()
            {
                catName = fc["catName"]
            };

            db.tblCategories.Add(category);
            db.SaveChanges();

            ViewBag.categoryList = db.tblCategories;

            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            tblCategory category = db.tblCategories.Find(id);
            if(category != null)
            {
                db.tblCategories.Remove(category);
                db.SaveChanges();
            }

            return RedirectToAction("AddCatgory");
        }
    }
}