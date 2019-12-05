using Newtonsoft.Json;
using PagedList;
using Solution.Data;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class EvaluationController : Controller
    {

        IServiceEvaluation evaluationservice = null;
        IServiceEvaluation sc = new ServiceEvaluation();

        public EvaluationController()
        {
            evaluationservice = new ServiceEvaluation();
        }
        // GET: Evaluation
        public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        {
            int pageSize = 2;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.CurrentSort = sortOrder;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "description" : sortOrder;
            IPagedList<evaluation> employees = null;
            switch (sortOrder)
            {
                case "TypeEval":
                    if (sortOrder.Equals(CurrentSort))
                        employees = db.evaluations.OrderByDescending
                                (m => m.TypeEval).ToPagedList(pageIndex, pageSize);
                    else
                        employees = db.evaluations.OrderBy
                              (m => m.TypeEval).ToPagedList(pageIndex, pageSize);
                    break;
                 case "commentaire":
                    if (sortOrder.Equals(CurrentSort))
                        employees = db.evaluations.OrderByDescending
                                (m => m.commentaire).ToPagedList(pageIndex, pageSize);
                    else
                        employees = db.evaluations.OrderBy
                              (m => m.commentaire).ToPagedList(pageIndex, pageSize);
                    break;
                case "contexteEval":
                    if (sortOrder.Equals(CurrentSort))
                        employees = db.evaluations.OrderByDescending
                                (m => m.contexteEval).ToPagedList(pageIndex, pageSize);
                    else
                        employees = db.evaluations.OrderBy
                              (m => m.contexteEval).ToPagedList(pageIndex, pageSize);
                    break;
                case "dateEval":
                    if (sortOrder.Equals(CurrentSort))
                        employees = db.evaluations.OrderByDescending
                                (m => m.dateEval).ToPagedList(pageIndex, pageSize);
                    else
                        employees = db.evaluations.OrderBy
                              (m => m.dateEval).ToPagedList(pageIndex, pageSize);
                    break;
                case "description":
                    if (sortOrder.Equals(CurrentSort))
                        employees = db.evaluations.OrderByDescending
                                (m => m.description).ToPagedList(pageIndex, pageSize);
                    else
                        employees = db.evaluations.OrderBy
                              (m => m.description).ToPagedList(pageIndex, pageSize);
                    break;

                case "idCandidat":
                    if (sortOrder.Equals(CurrentSort))
                        employees = db.evaluations.OrderByDescending
                                (m => m.idCandidat).ToPagedList(pageIndex, pageSize);
                    else
                        employees = db.evaluations.OrderBy
                              (m => m.idCandidat).ToPagedList(pageIndex, pageSize);
                    break;

                case "noteEmploye":
                    if (sortOrder.Equals(CurrentSort))
                        employees = db.evaluations.OrderByDescending
                                (m => m.noteEmploye).ToPagedList(pageIndex, pageSize);
                    else
                        employees = db.evaluations.OrderBy
                              (m => m.noteEmploye).ToPagedList(pageIndex, pageSize);
                    break;
                case "noteManager":
                    if (sortOrder.Equals(CurrentSort))
                        employees = db.evaluations.OrderByDescending
                                (m => m.noteManager).ToPagedList(pageIndex, pageSize);
                    else
                        employees = db.evaluations.OrderBy
                              (m => m.noteManager).ToPagedList(pageIndex, pageSize);
                    break;

                case "periodEval":
                    if (sortOrder.Equals(CurrentSort))
                        employees = db.evaluations.OrderByDescending
                                (m => m.periodEval).ToPagedList(pageIndex, pageSize);
                    else
                        employees = db.evaluations.OrderBy
                              (m => m.periodEval).ToPagedList(pageIndex, pageSize);
                    break;

                case "employe_id_Emp":
                    if (sortOrder.Equals(CurrentSort))
                        employees = db.evaluations.OrderByDescending
                                (m => m.employe_id_Emp).ToPagedList(pageIndex, pageSize);
                    else
                        employees = db.evaluations.OrderBy
                              (m => m.employe_id_Emp).ToPagedList(pageIndex, pageSize);
                    break;

                    /*List<EvaluationModel> dataPoints = new List<EvaluationModel>();
                    var evaluationss = new List<EvaluationModel>();
                     foreach (evaluation qdomain in evaluationservice.GetMany())
                    {
                        evaluationss.Add(new EvaluationModel()
                        {
                            id_Eval = qdomain.id_Eval,
                            TypeEval = qdomain.TypeEval,
                           contexteEval = qdomain.contexteEval,
                            dateEval = qdomain.dateEval,
                            description = qdomain.description,
                            noteEmploye = qdomain.noteEmploye,
                            noteManager = qdomain.noteManager,
                            periodEval = qdomain.periodEval,
                            employe_id_Emp = qdomain.employe_id_Emp


                        });
                    }


                    dataPoints.Add(new EvaluationModel("TypeEval"));


                    ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints); */
            }
            ViewBag.nbprojet = employees.Count;
            ViewBag.total = employees.Count(x => +x.noteEmploye>=10);

            ViewBag.reus = ViewBag.total * 100 / ViewBag.nbprojet;

            //   ViewBag.supAdix = employees.Where();


            return View(employees);
            //return View(evaluationss);
        }       

        public ActionResult DataFromDataBase()
        {
            try
            {
                ViewBag.DataPoints = JsonConvert.SerializeObject(db.evaluations.ToList(), _jsonSetting);

                return View();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                return View("Error");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return View("Error");
            }
        }
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        private ff db = new ff();
        public ActionResult PrintAllEmployee()
        {
            var report = new Rotativa.ActionAsPdf("Index");
            return report;
        }
        public ActionResult EmployeeImage(int id)
        {
            var report = new Rotativa.ActionAsImage("Index", new { id = id });
            return report;
        }

        // GET: Evaluation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Evaluation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evaluation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(evaluation pvm)
        {

           
            ff db = new ff();
            db.evaluations.Add(pvm);
            db.SaveChanges();
            return RedirectToAction("Index");

            /*  evaluation productdomain = new evaluation()
              {
                  id_Eval = pvm.id_Eval,
                  TypeEval = pvm.TypeEval,
                  contexteEval = pvm.contexteEval,
                  dateEval = pvm.dateEval,
                  description = pvm.description,
                  noteEmploye = pvm.noteEmploye,
                  noteManager = pvm.noteManager,
                  periodEval = pvm.periodEval,
                  employe_id_Emp = pvm.employe_id_Emp

              };
              evaluationservice.Add(productdomain);
              evaluationservice.Commit();
              evaluationservice.Dispose();

              return RedirectToAction("Index");*/
        }

        // GET: Evaluation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Evaluation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, evaluation ord)
        {
            ILigneqst ac = new LigneqstService();

            List<ligneqst> ordd1 = ac.GetMany(x => x.evaluation_id_Eval == id).ToList();

            ViewBag.total = ordd1.Sum(x => +x.noteQst);
            //ord.NombreHeuresEstimer = ordd1.Sum(x => +x.NombreHeuresEstimer);
            // ViewBag.ordd = ordd1;
            // ViewBag.total2 = ordd1.Sum(x => +x.NombreHeuresTravailler);

            try
            {

                evaluation order = sc.GetById(id);
                order.id_Eval = ord.id_Eval;
                order.TypeEval = ord.TypeEval;
                order.commentaire = ord.commentaire;
                order.contexteEval = ord.contexteEval;
                order.dateEval = ord.dateEval;
                order.description = ord.description;
                order.idCandidat = ord.idCandidat;
                order.employe_id_Emp = ord.employe_id_Emp;
                order.noteEmploye = ViewBag.total;
                //order.NombreHeuresTravailler = ViewBag.total2;


                // if ((ViewBag.total2 - ViewBag.total) > 0)
                // {
                //order.NombreHeuresEnRetard = ViewBag.total2 - ViewBag.total;
                //}
                //else
                //{ order.NombreHeuresEnRetard = 0; }
                sc.Update(order);
                sc.Commit();


                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Evaluation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Evaluation/Delete/5
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
        public ActionResult ConfirmOrder(int id)
        {
            List<evaluation> ordd1 = sc.GetMany(x => x.id_Eval == id).ToList();

            foreach (var itemmm in ordd1)
            {
                if ((itemmm.noteEmploye > 10) )
                {

                    MailMessage mail = new MailMessage();

                   
                    foreach (var item in ordd1)
                    {
                        
                    }
                    mail.From = new MailAddress("aadvteam@gmail.com");
                    mail.To.Add("firas.zoghlami@esprit.tn");
                    mail.Subject = "Note inferieure à 10";
                    string ordersdettail = "your order that contains this Projec ";

                    foreach (var item in ordd1)
                    {
                        ordersdettail += " project name : " + item.noteEmploye + "| description = " + item.description;
                    }

                    mail.Body = ordersdettail;
                    // MailMessage.Priority = MailPriority.Normal;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    NetworkCredential nc = new System.Net.NetworkCredential("aadvteam@gmail.com", "123advteamm");

                    smtp.EnableSsl = true;
                    smtp.Credentials = nc;
                    smtp.Send(mail);




                }

                
                


            }

            /*
                        MailMessage mail = new MailMessage();

                        String nom="";
                        foreach (var item in ordd1)
                        {
                            nom =  item.mailClient ;
                        }
                        mail.From = new MailAddress(nom);
                        mail.To.Add("takwa.souai@esprit.tn");
                        mail.Subject = "project completed with succes";
                        string ordersdettail = "your order that contains this Project ";

                        foreach (var item in ordd1)
                        {
                            ordersdettail += " project name : " + item.nom + "| description = " + item.description  ;
                        }

                        mail.Body = ordersdettail ;
                       // MailMessage.Priority = MailPriority.Normal;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        NetworkCredential nc = new System.Net.NetworkCredential("aadvteam@gmail.com", "123advteamm");

                        smtp.EnableSsl = true;
                        smtp.Credentials = nc;
                        smtp.Send(mail);



                        return RedirectToAction("Index", "Home");
                        */

            return RedirectToAction("Index", "Home");


        }
    }
}
