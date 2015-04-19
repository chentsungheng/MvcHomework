using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class CRUDController : Controller
    {
        FabricsEntities db = new FabricsEntities();

        // GET: CRUD
        public ActionResult Index()
        {
            var data = from p
                       in db.Products
                       where p.ProductName.StartsWith("C") //&& p.Price >= 5 && p.Price <= 10
                       orderby p.ProductId descending
                       select p;

            return View(data);
        }

        // GET: CRUD/Details/5
        public ActionResult Details(int id)
        {
            Product prod = db.Products.FirstOrDefault(p => p.ProductId == id);

            return View(prod);
        }

        // GET: CRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRUD/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Product newProd = new Product();

                newProd.ProductName = collection["ProductName"];
                newProd.Price = Convert.ToDecimal(collection["Price"]);
                newProd.Stock = Convert.ToDecimal(collection["Stock"]);
                newProd.Active = true;

                db.Products.Add(newProd);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public ActionResult BatchUpdate()
        {
            foreach (Product item in db.Products.Where(p => p.ProductName.StartsWith("C")))
            {
                item.Price = item.Price * 2;
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var allErrors = new List<string>();

                foreach (DbEntityValidationResult re in ex.EntityValidationErrors)
                {
                    foreach (DbValidationError err in re.ValidationErrors)
                    {
                        allErrors.Add(err.ErrorMessage);
                    }
                }

                ViewBag.Errors = allErrors;
            }

            return RedirectToAction("Index");
        }

        // GET: CRUD/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CRUD/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CRUD/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CRUD/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
