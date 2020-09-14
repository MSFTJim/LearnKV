using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Timmy.Models;

namespace Timmy.Pages
{

    public class WhoAmI : PageModel
    {

        [BindProperty]
        public DrawerModel Drawer { get; set; }

        public void OnGet()
        {
            //run this code when page is displayed

        }

        public IActionResult OnPost()
        {
            if  (ModelState.IsValid == false)
            {
                 return Page();
            }

            return RedirectToPage("./Index", new{ PageUser = Drawer.Name});
            

        }

        

    
        
    }
}