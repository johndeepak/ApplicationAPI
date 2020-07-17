using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using System.Net.Http;


namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<PrcticeJoinModels> practice;
            HttpResponseMessage response = Globalvariables.webapiclient.GetAsync("praticejoins").Result;
            practice = response.Content.ReadAsAsync<IEnumerable<PrcticeJoinModels>>().Result;
            return View(practice);
        }
        public ActionResult AddOREdit(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                HttpResponseMessage response = Globalvariables.webapiclient.GetAsync("praticejoins/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<PrcticeJoinModels>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOREdit(PrcticeJoinModels mod)
        {
            if (mod.orderId ==null)
            {
                HttpResponseMessage response = Globalvariables.webapiclient.PostAsJsonAsync("praticejoins", mod).Result;
                TempData["SucessMessage"] = "Saved Sucessfully";
            }
            else
            {

                HttpResponseMessage response = Globalvariables.webapiclient.PutAsJsonAsync("praticejoins/" + mod.orderId, mod).Result;
                TempData["SucessMessage"] = "Saved Sucessfully";
            }
            return RedirectToAction("Index");

        }

      
        public ActionResult Delete(int id)
        {

          
            HttpResponseMessage response = Globalvariables.webapiclient.DeleteAsync("praticejoins/" + id).Result;
            return RedirectToAction("Index");

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}