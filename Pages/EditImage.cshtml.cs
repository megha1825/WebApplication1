using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Database.Context;
using WebApplication1.Pages.models;

namespace WebApplication1.Pages
{
    public class EditImageModel : PageModel
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment _environment;

        public EditImageModel(ApplicationDbContext dbcontext, IWebHostEnvironment env)
        {
            context = dbcontext;
            _environment = env;
        }

        [BindProperty]
        public product Product { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }


        public IActionResult OnGet(int id)
            {
                Product = context.products.Find(id);
                if (Product == null)
                {
                    return NotFound();
                }
                return Page();

            }
        public IActionResult OnPost()
        {

            var existingProduct = context.products.Find(Product.product_id);
            if (existingProduct == null)
            {
                return NotFound();
            }


            existingProduct.product_name = Product.product_name;
            existingProduct.product_quantity = Product.product_quantity;
            existingProduct.product_price = Product.product_price;
            existingProduct.product_description = Product.product_description;
            existingProduct.product_type = Product.product_type;
           
                var filename = Guid.NewGuid().ToString() + Path.GetExtension(Product.ImageFile.FileName);
                var filepath = Path.Combine(_environment.WebRootPath, "upload", filename);
                var filestream = new FileStream(filepath, FileMode.Create);
                Product.ImageFile.CopyToAsync(filestream);
                existingProduct.ImagePath = $"upload/{filename}";
            
            context.SaveChanges();
            return RedirectToPage("Admin");

        }

    }
}
