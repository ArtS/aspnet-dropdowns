using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dropdowns.Models
{
    public class SignUpModel
    {
        public string State { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
    }
}