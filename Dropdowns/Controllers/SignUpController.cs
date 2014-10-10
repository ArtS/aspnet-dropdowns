using System.Collections.Generic;
using System.Web.Mvc;
using Dropdowns.Models;

namespace Dropdowns.Controllers
{
    public class SignUpController : Controller
    {
        public ActionResult SignUp()
        {
            // Let's get all states that we need for a dropdown
            var states = GetAllStates();

            var m = new SignUpModel
            {
                // Create a list of SelectListItems so these can be rendered on the page
                States = GetSelectListItems(states)
            };

            return View(m);
        }

        [HttpPost]
        public ActionResult SignUp(SignUpModel model)
        {
            // Get all states again
            var states = GetAllStates();

            // Set these states on the model. We need to do this because
            // only selected in the dropdown value is posted back, not the whole
            // list of states
            model.States = GetSelectListItems(states);

            // In case everything is fine - i.e. both "Name" and "State" are entered/selected,
            // redirect user to the "Done" page, and pass the user object along via Session
            if (ModelState.IsValid)
            {
                Session["SignUpModel"] = model;
                return RedirectToAction("Done");
            }

            // Something is not right - so render the registration page again,
            // keeping the data user has entered by supplying the model.
            return View("SignUp", model);
        }

        public ActionResult Done()
        {
            SignUpModel model = Session["SignUpModel"] as SignUpModel;
            return View(model);
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
    }
}