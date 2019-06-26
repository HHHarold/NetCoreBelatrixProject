using System.ComponentModel.DataAnnotations;

namespace Chinook.WebApi.ViewModels
{
    public class User
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
