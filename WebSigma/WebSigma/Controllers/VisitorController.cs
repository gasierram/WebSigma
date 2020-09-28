using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebSigma.Models;
using WebSigma.Models.ViewModels;

namespace WebSigma.Controllers
{
    public class VisitorController : Controller
    {
        // GET: Visitor
        //public async Task<ActionResult> Index()
        public ActionResult Index()
        {

            return View();
        }

        //public List<State> GetStates()
        //{
        //    //var httpClient = new HttpClient();
        //    //var json = httpClient.GetStringAsync("https://sigma-studios.s3-us-west-2.amazonaws.com/test/colombia.json");
        //    //JsonConvert.SerializeObject(json);
        //    //var log = JsonConvert.DeserializeObject<State>(json);
        //    //return log;
        //}




        static async Task<State> GetStates(string path)
        {
            var httpClient = new HttpClient();


            State product = null;
            HttpResponseMessage response = await httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<State>();
            }
            return product;
        }

        [HttpPost]
        public ActionResult Nuevo(VisitorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SIGMAEntities db = new SIGMAEntities())
                    {
                        var oVisitor = new Visitor();
                        oVisitor.NAME = model.Name;
                        oVisitor.EMAIL = model.Email;
                        oVisitor.STATE = model.State;
                        oVisitor.CITY = model.City;

                        db.Visitor.Add(oVisitor);
                        db.SaveChanges();
                    }
                    return Redirect("Visitor/index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}