using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebSigma.Models;
using WebSigma.Models.ViewModels;

namespace WebSigma.Controllers
{
    public class VisitorController : Controller
    {
        // GET: Visitor
        //[HttpPost]
        //public async Task<ActionResult> Index(VisitorViewModel model)
        public async Task<ActionResult> Index()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://sigma-studios.s3-us-west-2.amazonaws.com/test/colombia.json");
            var states = JsonConvert.SerializeObject(json);



            return View();
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