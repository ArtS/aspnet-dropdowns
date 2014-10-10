using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dropdowns.Models;

namespace Dropdowns.Controllers
{
    public class SignUpController : Controller
    {
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

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }

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

            if (ModelState.IsValid)
            {
                Session["SignUpModel"] = model;
                return RedirectToAction("Done");
            }
            return View("Index", model);
        }

        public ActionResult Done()
        {
            SignUpModel model = Session["SignUpModel"] as SignUpModel;
            return View(model);
        }
    }
}