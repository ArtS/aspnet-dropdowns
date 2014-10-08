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
            var states = GetAllStates();

            var m = new SignUpModel
            {
                States = GetSelectListItems(states)
            };

            return View(m);
        }

        [HttpPost]
        public ActionResult SignUp(SignUpModel model)
        {
            var states = GetAllStates();
            model.States = GetSelectListItems(states);

            return View("Index", model);
        }

        private IEnumerable<string> GetAllStates()
        {
            return new List<string>
            {
                "ACT",
                "New South Wales",
                "Northern Territories",
                "Queensland",
                "South Australia",                    
                "Victoria",                    
                "Western Australia",
            };
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
    }
}