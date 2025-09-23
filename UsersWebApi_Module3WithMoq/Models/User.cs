using System.ComponentModel.DataAnnotations;

namespace UsersWebApi_Module3WithMoq.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // ⚠️ In real apps store hashed passwords!
    }
}
