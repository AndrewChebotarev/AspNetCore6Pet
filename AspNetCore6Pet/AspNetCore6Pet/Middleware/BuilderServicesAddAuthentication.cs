namespace AspNetCore6Pet.Middleware
{
    public class BuilderServicesAddAuthentication
    {
        public void addAuthentication(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/";
                options.AccessDeniedPath = "/accessdenied";
            });
        }
    }
}
