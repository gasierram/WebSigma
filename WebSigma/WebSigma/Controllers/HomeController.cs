using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebSigma.Models;
using WebSigma.Models.ViewModels;

namespace WebSigma.Controllers
{
    public class HomeController : Controller
    {
        string Baseurl = "https://sigma-studios.s3-us-west-2.amazonaws.com/test/colombia.json";
        public ActionResult index()
        {

            return View();
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

        [HttpPost]
        public ActionResult Index(VisitorViewModel obj)
        {
            ViewBag.Message = "To OK";
            if (ModelState.IsValid)
            {
                SIGMAEntities db = new SIGMAEntities();
                Visitor visitor = new Visitor();
                visitor.NAME = obj.Name;
                visitor.EMAIL = obj.Email;
                visitor.CITY = obj.City;
                visitor.STATE = obj.State;
                db.Visitor.Add(visitor);
                db.SaveChanges();
            }
            return View(obj);
        }
    }
}