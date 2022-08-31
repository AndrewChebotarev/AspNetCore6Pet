namespace AspNetCore6Pet.Middleware.MiddlewareForPage
{
    public class MiddlewareForStartPage
    {
        public async Task StartPage(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.SendFileAsync("wwwroot/src/html/StartPage.html");
        }
    }
}
