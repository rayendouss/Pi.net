
using Pidev.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Pidev.web.Controllers
{
    public class EmployeController : Controller
    {
        // GET: Employe
        public ActionResult Index()
        {
            List<tp_jsf_employe> employes = Session["employes"] as List<tp_jsf_employe>;
            return View(employes);
        }

        // GET: Employe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tp_jsf_employe e)
        {
         
            return View();
        }

        // GET: Employe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employe/Edit/5
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

        // GET: Employe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employe/Delete/5
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
        public ActionResult ndex2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ndex2(tp_jsf_employe e)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("PI_GL-web/api/users/login?email=" + e.email + "&password=" + e.password).Result;
            if (response.IsSuccessStatusCode)
            {
                // ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Emp>>().Result;
                return RedirectToAction("acc");
            }
            else
            {
                return RedirectToAction("About");
            }
        }
        public ActionResult acc()
        {
            return View();
        }
        [HttpGet]
        public ActionResult accEmp()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("projetutilisateurs-web/api/users/all").Result;
           
            if (response.IsSuccessStatusCode)
            {

               ViewBag.result = response.Content.ReadAsAsync<IEnumerable<tp_jsf_employe>>().Result;
                return View();
            }
            else
            {
                return ViewBag.result = "error";
            }
        }
        public ActionResult del(tp_jsf_employe  e)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("PI_GL-web/api/users/del?id="+e.id).Result;

                if (response.IsSuccessStatusCode)
                {

                return RedirectToAction("accEmp");
                }
                else
                {
                return View();
                }
        }
    }
}
