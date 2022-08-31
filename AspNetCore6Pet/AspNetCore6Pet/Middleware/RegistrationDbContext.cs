namespace AspNetCore6Pet.Middleware
{
    public class RegistrationDbContext
    {
        public void AddDbContext(WebApplicationBuilder builder)
        {
            string connection = "Server=(localdb)\\mssqllocaldb;Database=aplicationdb;Trusted_Connection=True;";
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
        }
    }
}
