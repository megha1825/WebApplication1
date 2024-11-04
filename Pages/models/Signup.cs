using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Pages.models
{
    public class Signup
    {
        [Key]
        public string FirstName { get; set; }

       
        public string Password {  get; set; }
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword {  get; set; }
        public int isactive { get; set; } = 1;

        public string ImagePath { get; set; }
        [NotMapped] // Indicates that this property should not be included in the database schema
        public IFormFile ImageFile { get; set; } // File uploaded by the user





    }
}
