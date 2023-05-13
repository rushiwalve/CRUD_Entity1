using CRUD_Entity1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace CRUD_Entity1.Controllers
{
    public class ProductController : Controller
    {
        MVCEntities2 db = new MVCEntities2();
        // GET: Product
        public ActionResult Index(int? i)
        {
            var data = db.categories.ToList().ToPagedList(i ?? 1,10);
            return View(data);
            
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(category c)
        {
            db.categories.Add(c);
            int i = db.SaveChanges();
            if (i > 0)
            {
                TempData["InsertMsg"] = "<script>alert('Inserted....!!!!');</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["InsertMsg"] = "<script>alert(' Not Inserted....!!!!');</script>";
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var row = db.categories.Where(model => model.productId == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(category cat)
        {
            db.Entry(cat).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            int i = db.SaveChanges();
            if (i > 0)
            {
                TempData["UpdateMsg"] = "<script>alert('Updated....!!!!');</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["UpdateMsg"] = "<script>alert(' Not Updated....!!!!');</script>";
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var row = db.categories.Where(model => model.productId == id).FirstOrDefault();
            db.Entry(row).State = System.Data.Entity.EntityState.Deleted;
            int i = db.SaveChanges();
            if (i > 0)
            {
                TempData["DeleteMsg"] = "<script>alert('Deleted....!!!!');</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["DeleteMsg"] = "<script>alert(' Not deleted....!!!!');</script>";
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var row = db.categories.Where(model => model.productId == id).FirstOrDefault();
            return View(row);
        }
    }
}

 