using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Pages.models
{
    public class product
    {
        [Key]
        public int product_id { get; set; }
        [Required]
        public string product_name { get; set; }
       
        [Required]
       
        public string product_description { get; set; }
        [Required]
        public int product_price { get; set; }
        [Required]
        public string product_type { get; set; }
        [Required]
        public int product_quantity { get;set; }
        [Required]
        public int product_isactive{ get; set; } = 1;

        public string ImagePath { get; set; }
        [NotMapped] // Indicates that this property should not be included in the database schema
        public IFormFile ImageFile { get; set; } // File uploaded by the user


    }
}
