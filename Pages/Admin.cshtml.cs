using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;
using WebApplication1.Database.Context;
using WebApplication1.Pages.models;

namespace WebApplication1.Pages
{
    public class AdminModel : PageModel
    {
        private readonly ApplicationDbContext context;//reference

        public AdminModel(ApplicationDbContext dbcontext)
        {
            context = dbcontext;//storing locally........

        }
        public List<Signup> userslist { get; set; }

        public void OnGet()
        {
            userslist = context.Signups.ToList();

        }
        public IActionResult OnPostUpdate(string id, int status)
        {
            var user = context.Signups.Find(id);
            if (user != null)
            {
                user.isactive = status;

                context.SaveChanges();
            }
            return RedirectToPage();



        }
        public IActionResult OnPostDelete(string id, int status)
        {
            var user = context.Signups.Find(id);
            if (user != null)
            {
                user.isactive = status;
                context.SaveChanges();
            }
            return RedirectToPage();



        }
        public IActionResult OnPostDeleteUsers(string id)
        {
            var user = context.Signups.Find(id);
            if (user != null)
            {
                context.Signups.Remove(user);
                context.SaveChanges();
            }
           return RedirectToPage(); 
        }
        


    }
}
