using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Database.Context;
using WebApplication1.Migrations;
using WebApplication1.Pages.models;

namespace WebApplication1.Pages
{
    public class signupModel : PageModel
    {
        private readonly ApplicationDbContext context;//reference
        private readonly IWebHostEnvironment _environment;

        public signupModel(ApplicationDbContext dbcontext, IWebHostEnvironment _env)
        {
            context = dbcontext;
            _environment = _env;//storing locally........

        }
        [BindProperty]
        public Signup user { get; set; }
        [BindProperty]
        public IFormFile ImageFile { get; set; }



        public List<SelectListItem> Roles { get; set; }

        public void OnGet()
        {
            //page loader//

        }
        public IActionResult OnPost()
        {
            var filename = Guid.NewGuid().ToString() + Path.GetExtension(user.ImageFile.FileName);
            var filepath = Path.Combine(_environment.WebRootPath, "upload", filename);
            var filestream = new FileStream(filepath, FileMode.Create);
            user.ImageFile.CopyToAsync(filestream);
            var newsignup = new Signup()
            {
                FirstName = user.FirstName,
                Password = user.Password,
                ConfirmPassword = user.ConfirmPassword,
                ImagePath = $"upload/{filename}",
            };
            context.Add(newsignup);
            context.SaveChanges();

            var authuser = context.logins.Where(p => p.Name == user.FirstName && p.Password == user.Password).FirstOrDefault();
            if (authuser != null)
            {
                TempData["message"] = "successful";
                return RedirectToPage("Index");

            }
            return Page();




        }
    }
}