using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Pidev.data;
using Pidev.service;

namespace Pidev.web.Controllers
{
    public class tp_jsf_timesheetController : Controller
    {
        timesheetService ts ;
        Employe em =new Employe();
        

        
        public tp_jsf_timesheetController()
        {
     
            ts = new timesheetService();
        }
        // GET: tp_jsf_timesheet
        public ActionResult Index()
        {
            return View(ts.GetAll().ToList());
        }

        public ActionResult Details()
        {
            return View();
        }
        // GET: tp_jsf_timesheet/Details/5
        [HttpPost]
        /*  public ActionResult Details(int id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
            IEnumerable<tp_jsf_timesheet> tt=<tp_jsf_timesheet> tp_jsf_timesheet;
            tp_jsf_timesheet tp_jsf_timesheet = ts.GetById(id);
            
            if (tp_jsf_timesheet == null)
              {
                  return HttpNotFound();
              }
              
              return View(tp_jsf_timesheet);
          }
          */


        // POST: tp_jsf_timesheet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        public ActionResult Create2()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.idEmploye = new SelectList(em.GetAll(), "id", "nom");


            return View();
        }
        [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Create([Bind(Include = "idT,EtatTache,NbreConge,NbreHeureTRavJour,NbreHeureTRavS,idEmploye,idp,idpfk,etat")] tp_jsf_timesheet tp_jsf_timesheet)
          {
            tp_jsf_timesheet timesheet = new tp_jsf_timesheet();
           // Employe ee = new Employe();
            //var myModel = new testt();
           // myModel.listA = ee.GetAll();
            if (ModelState.IsValid)
              {
               
                /*  List<object> m = new List<object>();
                   m.Add(em.GetAll().ToList());
                   m.Add(tp_jsf_timesheet);*/

                ts.Add(tp_jsf_timesheet);
                  ts.Commit();
                ViewBag.idEmploye = new SelectList(em.GetAll(), "id", "nom", tp_jsf_timesheet.idEmploye);
                return RedirectToAction("Index");
              }
            

            
            return View();
          }
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tp_jsf_timesheet tp_jsf_timesheet = ts.GetById(id);
            if (tp_jsf_timesheet == null)
            {
                return HttpNotFound();
            }
            return View(tp_jsf_timesheet);
        }

        // POST: tp_jsf_timesheet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tp_jsf_timesheet tp_jsf_timesheet = ts.GetById(id);
           ts.Delete(tp_jsf_timesheet);
            ts.Commit();
            return RedirectToAction("Index");
        }
       /*
          // GET: tp_jsf_timesheet/Edit/5
          public ActionResult Edit(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              tp_jsf_timesheet tp_jsf_timesheet = ts.Find(id);
              if (tp_jsf_timesheet == null)
              {
                  return HttpNotFound();
              }
              return View(tp_jsf_timesheet);
          }
        
          // POST: tp_jsf_timesheet/Edit/5
          // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
          // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit([Bind(Include = "idT,EtatTache,NbreConge,NbreHeureTRavJour,NbreHeureTRavS,idEmploye,idp,idpfk,etat")] tp_jsf_timesheet tp_jsf_timesheet)
          {
              if (ModelState.IsValid)
              {
                  db.Entry(tp_jsf_timesheet).State = EntityState.Modified;
                  db.SaveChanges();
                  return RedirectToAction("Index");
              }
              return View(tp_jsf_timesheet);
          }

          // GET: tp_jsf_timesheet/Delete/5
          

          protected override void Dispose(bool disposing)
          {
              if (disposing)
              {
                  db.Dispose();
              }
              base.Dispose(disposing);
          }*/
    }
}
