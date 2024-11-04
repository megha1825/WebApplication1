using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using WebApplication1.Database.Context;
using WebApplication1.Pages.models;

namespace WebApplication1.Pages
{
    public class loginModel : PageModel
    {
        private readonly ApplicationDbContext context;//reference

        public loginModel(ApplicationDbContext dbcontext)
        {
            context = dbcontext;//storing locally........

        }
        [BindProperty]
        public login Input { get; set; }
    
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var user = new login
            {
                Name = Input.Name,
                Password = Input.Password,
            };
           
            if(ModelState.IsValid)
            {
                TempData["message"] = "login successfull";
                return RedirectToPage("signup");

            }
            TempData["message"] = "Signup is Required";
            return Page();
          
            
        }
    }
}
