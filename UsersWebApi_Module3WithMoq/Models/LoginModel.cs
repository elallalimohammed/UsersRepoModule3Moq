using System.ComponentModel.DataAnnotations;

namespace UsersWebApi_Module3WithMoq.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
