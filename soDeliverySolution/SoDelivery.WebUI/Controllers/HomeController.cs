using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoDelivery.WebUI.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult StartUp()
        {
            return View();
        }
        public ActionResult Index(int Id)
        {
            
            if(Id == 1)
            {
                ViewBag.Title = "Boss";
            }
            else
            {
                ViewBag.Title = "Deliverer";
            }
            ViewBag.Id = Id;
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
    }
}