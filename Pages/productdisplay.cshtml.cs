using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Database.Context;
using WebApplication1.Pages.models;

namespace WebApplication1.Pages
{
    public class productdisplayModel : PageModel
    {
        private readonly ApplicationDbContext context;//reference

        public productdisplayModel(ApplicationDbContext dbcontext)
        {
            context = dbcontext;//storing locally........

        }
        public List<product> productlist
            { get; set; }
        public void OnGet()
        {
            productlist=context.products.ToList();
        }
    }
}
