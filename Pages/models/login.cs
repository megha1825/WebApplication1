using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages.models
{
    public class login
    {

        [Required]
        [Key]
        public string? Name {  get; set; }
        [Required]
        public string Password { get; set; }
    }
}
