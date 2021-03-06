﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class ClientsController : BaseController
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(CustomLoginViewModel LoginModel)
        {
            return View("LoginResult", LoginModel);
        }

        private FabricsEntities db = new FabricsEntities();

        // GET: Clients
        public ActionResult Index()
        {
            //var clients = db.Clients.Include(c => c.Occupation).Take(10);
            var clients = repClient.All().Take(10);

            return View(clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Client client = db.Clients.Find(id);
            Client client = repClient.Find(id.Value);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.OccupationId = new SelectList(db.Occupations, "OccupationId", "OccupationName");
            return View();
        }

        // POST: Clients/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,FirstName,MiddleName,LastName,Gender,DateOfBirth,CreditRating,XCode,OccupationId,TelephoneNumber,Street1,Street2,City,ZipCode,Longitude,Latitude,Notes")] Client client)
        {
            if (ModelState.IsValid)
            {
                //db.Clients.Add(client);
                //db.SaveChanges();
                repClient.Add(client);
                repClient.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            //ViewBag.OccupationId = new SelectList(db.Occupations, "OccupationId", "OccupationName", client.OccupationId);
            ViewBag.OccupationId = new SelectList(repOccupation.All(), "OccupationId", "OccupationName", client.OccupationId);
            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Client client = db.Clients.Find(id);
            Client client = repClient.Find(id.Value);
            if (client == null)
            {
                return HttpNotFound();
            }
            //ViewBag.OccupationId = new SelectList(db.Occupations, "OccupationId", "OccupationName", client.OccupationId);
            ViewBag.OccupationId = new SelectList(repOccupation.All(), "OccupationId", "OccupationName", client.OccupationId);
            return View(client);
        }

        // POST: Clients/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,FirstName,MiddleName,LastName,Gender,DateOfBirth,CreditRating,XCode,OccupationId,TelephoneNumber,Street1,Street2,City,ZipCode,Longitude,Latitude,Notes")] Client client)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(client).State = EntityState.Modified;
                //db.SaveChanges();
                repClient.UnitOfWork.Context.Entry(client).State = EntityState.Modified;
                repClient.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            //ViewBag.OccupationId = new SelectList(db.Occupations, "OccupationId", "OccupationName", client.OccupationId);
            ViewBag.OccupationId = new SelectList(repOccupation.All(), "OccupationId", "OccupationName", client.OccupationId);
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Client client = db.Clients.Find(id);
            Client client = repClient.Find(id.Value);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Client client = db.Clients.Find(id);
            //db.Clients.Remove(client);
            //db.SaveChanges();
            Client client = repClient.Find(id);
            repClient.Delete(client);
            repClient.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Usp()
        {
            var result = db.usp_LookupClients().AsQueryable();
            return View(result);
        }

#if DEBUG
        public override JsonResult Debug()
        {
            return Json("This is DEBUG action", JsonRequestBehavior.AllowGet);
        }
#endif
    }
}
