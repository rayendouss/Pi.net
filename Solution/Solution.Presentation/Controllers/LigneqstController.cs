using Solution.Data;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class LigneqstController : Controller
    {
        private ff db = new ff();
        ILigneqst ligneqstService = null;
        ILigneqst sc = new LigneqstService();
        public LigneqstController()
        {
            ligneqstService = new LigneqstService();
        }
        // GET: Ligneqst
        public ActionResult Index()
        {
            var ligneqs = new List<LigneqstsModel>();
            foreach (ligneqst qdomain in ligneqstService.GetMany())
            {
                ligneqs.Add(new LigneqstsModel()
                {
                    Id_LigneQst = qdomain.Id_LigneQst,
                    noteQst = qdomain.noteQst,
                    evaluation_id_Eval = qdomain.evaluation_id_Eval,
                    question_id_Qst = qdomain.question_id_Qst,

                });
            }
            return View(ligneqs);
          
        }
        public ActionResult GetAllligneqst()
        {
            return View(db.ligneqsts.Include("noteQst").OrderBy(e => e.Id_LigneQst));
        }

        // GET: Ligneqst/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ligneqst/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ligneqst/Create
        [HttpPost]
        public ActionResult Create(LigneqstsModel pvm)
        {
            ligneqst c = new ligneqst();
          

            c.Id_LigneQst = pvm.Id_LigneQst;
            c.question_id_Qst = pvm.question_id_Qst;
            c.evaluation_id_Eval = pvm.evaluation_id_Eval;
            c.noteQst = pvm.noteQst;

            



            sc.Add(c);
            sc.Commit();
           // ligneqstService.Dispose();


            return RedirectToAction("Index");


        }

        // GET: Ligneqst/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ligneqst/Edit/5
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

        // GET: Ligneqst/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ligneqst/Delete/5
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
