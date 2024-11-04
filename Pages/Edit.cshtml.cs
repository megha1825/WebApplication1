using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Database.Context;
using WebApplication1.Pages.models;


namespace WebApplication1.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext context; 

        public EditModel(ApplicationDbContext dbcontext)
        {
            context = dbcontext; 
        }

        [BindProperty]
        public Signup user { get; set; }

        public IActionResult OnGet(string id)
        {
           
            user = context.Signups.SingleOrDefault(u => u.FirstName == id); 

            if (user == null)
            {
                return NotFound(); 
            }

            return Page();
        }


        public IActionResult OnPost()
        {
           
            var userToUpdate = context.Signups.Find(user.FirstName);
            if (userToUpdate == null)
            {
                return NotFound();
            }


            
            userToUpdate.Password = user.Password;
          

            context.SaveChanges();
            return RedirectToPage("Admin"); 
        }
    }
}
 