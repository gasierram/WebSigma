using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using WebSigma.Models;
using WebSigma.Models.ViewModels;

namespace WebSigma.Controllers
{
    public class HomeController : Controller
    {
        string Baseurl = "https://sigma-studios.s3-us-west-2.amazonaws.com/test/colombia.json";

        static HttpClient client = new HttpClient();

        public ActionResult index()
        {
            //List<State> product = GetJson(Baseurl);
            //State_Bind();
            return View();
        }

        public List<State> GetJson(string path)
        {
            List<State> states = null;
            string json = @"";

            states = JsonConvert.DeserializeObject<List<State>>(json);
            return states;
        }

        public void State_Bind()
        {
            string[] items = null;

            using (StreamReader r = new StreamReader(@"C:\Users\Alejandro Sierra\Desktop\departamentos.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<string[]>(json);
            }
            List<SelectListItem> statelist = new List<SelectListItem>();
            foreach (var dr in items)
            {

                statelist.Add(new SelectListItem { Text = dr.ToString(), Value = dr.ToString() });

            }
            ViewBag.Country = statelist;

        }


        //public JsonResult City_bind(string city_id)
        //{
        //    List<SelectListItem> statelist = new List<SelectListItem>();
        //    foreach (DataRow dr in State_Bind())
        //    {
        //        statelist.Add(new SelectListItem { Text = dr["City"].ToString(), Value = dr["city"].ToString() });
        //    }
        //    return Json(statelist, JsonRequestBehavior.AllowGet);

        //}
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

        public ActionResult Confirmation()
        {
            ViewBag.Message = "Confirmation page.";

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
                return Redirect("/Home/Confirmation");
            }
            return View(obj);
        }
    }
}