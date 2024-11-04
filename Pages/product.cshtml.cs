using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Database.Context;
using WebApplication1.Pages.models;

namespace WebApplication1.Pages
{
    public class productModel : PageModel
    {
        private readonly ApplicationDbContext context;//reference
        private readonly IWebHostEnvironment _environment;

        public productModel(ApplicationDbContext dbcontext,IWebHostEnvironment _env)
        {
            context = dbcontext;
            _environment = _env;//storing locally........

        }
        [BindProperty]
        public product Product {  get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            var filename=Guid.NewGuid().ToString()+Path.GetExtension(Product.ImageFile.FileName);
            var filepath = Path.Combine(_environment.WebRootPath, "upload", filename);
            var filestream=new FileStream(filepath, FileMode.Create);
            Product.ImageFile.CopyToAsync(filestream);

            var name = new product()
            {
                product_id = Product.product_id,
                product_name = Product.product_name,
                product_quantity=Product.product_quantity,
                product_price=Product.product_price,
                product_description=Product.product_description,
                product_type=Product.product_type,
                ImagePath = $"upload/{filename}",

            };
            context.products.Add(name);
            context.SaveChanges();
            return RedirectToPage("Admin");

        }
        
    }
}
