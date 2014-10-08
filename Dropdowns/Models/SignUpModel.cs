using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Dropdowns.Models
{
    public class SignUpModel
    {
        [Required]
        [Display(Name="Name")]        
        public string Name { get; set; }

        [Required]
        [Display(Name="State")]
        public string State { get; set; }

        public IEnumerable<SelectListItem> States { get; set; }
    }
}