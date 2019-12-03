using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pidev.data;

namespace Pidev.web.Controllers
{
    public class tp_jsf_reclamationController : Controller
    {
        private Model1 db = new Model1();

        // GET: tp_jsf_reclamation
        public ActionResult Index()
        {
            return View(db.tp_jsf_reclamation.ToList());
        }

        // GET: tp_jsf_reclamation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tp_jsf_reclamation tp_jsf_reclamation = db.tp_jsf_reclamation.Find(id);
            if (tp_jsf_reclamation == null)
            {
                return HttpNotFound();
            }
            return View(tp_jsf_reclamation);
        }

        // GET: tp_jsf_reclamation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tp_jsf_reclamation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRec,description,idemp,name,rep,emps_id")] tp_jsf_reclamation tp_jsf_reclamation)
        {
            if (ModelState.IsValid)
            {
                db.tp_jsf_reclamation.Add(tp_jsf_reclamation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tp_jsf_reclamation);
        }

        // GET: tp_jsf_reclamation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tp_jsf_reclamation tp_jsf_reclamation = db.tp_jsf_reclamation.Find(id);
            if (tp_jsf_reclamation == null)
            {
                return HttpNotFound();
            }
            return View(tp_jsf_reclamation);
        }

        // POST: tp_jsf_reclamation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRec,description,idemp,name,rep,emps_id")] tp_jsf_reclamation tp_jsf_reclamation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tp_jsf_reclamation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tp_jsf_reclamation);
        }

        // GET: tp_jsf_reclamation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tp_jsf_reclamation tp_jsf_reclamation = db.tp_jsf_reclamation.Find(id);
            if (tp_jsf_reclamation == null)
            {
                return HttpNotFound();
            }
            return View(tp_jsf_reclamation);
        }

        // POST: tp_jsf_reclamation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tp_jsf_reclamation tp_jsf_reclamation = db.tp_jsf_reclamation.Find(id);
            db.tp_jsf_reclamation.Remove(tp_jsf_reclamation);
            db.SaveChanges();
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
    }
}
