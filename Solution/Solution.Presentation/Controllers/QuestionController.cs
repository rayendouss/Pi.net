using Solution.Data;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solution.Presentation.Controllers
{
    public class QuestionController : Controller
    {
        IQuestionService questionService = null;

        public QuestionController()
        {
            questionService = new QuestionService();
        }
        // GET: Question
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/quetion").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<QuestionModel>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(QuestionModel evm)
        {
            {

                HttpClient Client = new HttpClient();
                Client.BaseAddress = new Uri("http://localhost:9080");

                Client.PostAsJsonAsync<QuestionModel>("pidev-web/api/quetion/addQuestion", evm)
                    .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
              
                    return RedirectToAction("Index");
                
            }
            //   catch
           
            //return View();
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        public IList<QuestionModel> GetEmployeeList()
        {
            ff db = new ff();
            var employeeList = (from e in db.questions
                                
                                select new QuestionModel
                                {
                                    id_Qst = e.id_Qst,
                                    descriptionQst = e.descriptionQst,
                                    typeQst = e.typeQst,
                                }).ToList();
            return employeeList;
        }
        public ActionResult ExportToExcel()
        {
            var gv = new GridView();
            gv.DataSource = this.GetEmployeeList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("Index");
        }

        // POST: Question/Edit/5
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

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
             HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("/api/quetion/supprimer/" + id).Result;
                QuestionModel domain = new QuestionModel();
                if (response.IsSuccessStatusCode)
                {

                    domain = response.Content.ReadAsAsync<QuestionModel>().Result;

                }
                else
                {
                    ViewBag.project = "erreur";
                }

                return View(domain);
            }
        

        // POST: Question/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            {

                try
                {
                    // TODO: Add delete logic here
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");

                    // TODO: Add insert logic here
                    client.DeleteAsync("api/quetion/supprimer/" + id)
                            .ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
        }
    }
}
