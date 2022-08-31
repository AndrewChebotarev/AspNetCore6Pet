using Microsoft.AspNetCore.Identity;

namespace AspNetCore6Pet.Data
{
    public class Admin
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Admin(string email, string password, Role role)
        {
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
