using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
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

        static HttpClient client = new HttpClient();

        public async Task<ActionResult> index()
        {
            List<State> product = await GetJson(Baseurl);
            return View();
        }

        public static async Task<List<State>> GetJson(string path)
        {
            List<State> states = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var json = await client.GetStringAsync(path);
                //states = await response.Content.ReadAsAsync<List<State>>();
                //json = json.Replace(@"(?<=[:,])(.*?)(?=\}[,\]])", json);
                var rsp = JsonConvert.DeserializeObject<List<Object>> (json);
            }
            return states;
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