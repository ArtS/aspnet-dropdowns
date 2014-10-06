using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dropdowns.Models;

namespace Dropdowns.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var states = new List<string>
            {
                "ACT",
                "New South Wales",
                "Northern Territories",
                "Queensland",
                "South Australia",                    
                "Victoria",                    
                "Western Australia",
            };

            var m = new SignUpModel
            {
                States = GetSelectListItems(states)
            };

            return View(m);
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements) {
            var result = new List<SelectListItem>();
            foreach(var element in elements) 
            {
                result.Add(new SelectListItem 
                {
                    Value = element,
                    Text = element
                });
            }

            return result;
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