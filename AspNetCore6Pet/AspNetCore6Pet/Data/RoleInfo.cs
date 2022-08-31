namespace AspNetCore6Pet.Data
{
    public class RoleInfo
    {
        public List<Admin> admin = new();
        public void RoleInitialization()
        {
            var adminRole = new Role("admin");

            admin.Add(new Admin("wizi@gmail.com", "55555", adminRole));
        }
    }
}
