namespace AspNetCore6Pet.Middleware.MiddlewareForPage
{
    public class RedirectToNewPage
    {
        private RoleInfo? roleInfo;
        MiddlewareForStartPage MiddlewareForStartPage = new();
        private void ReceivingRole(RoleInfo roleInfo) => this.roleInfo = roleInfo;

        public async Task Redirect(HttpContext context, RoleInfo roleInfo)
        {
           ReceivingRole(roleInfo);
           await SearchKeysButton(context);
        }

        private async Task SearchKeysButton(HttpContext context)
        {
            foreach (var KeysButton in context.Request.Form.Keys)
                await RedirectToPage(KeysButton, context, roleInfo);
        }

        private async Task RedirectToPage(string KeysButton, HttpContext context, RoleInfo? roleInfo)
        {
            switch (KeysButton)
            {
                case "HomefromUser":
                    await MiddlewareForStartPage.StartPage(context);
                    break;

                case "user":
                    await TransitionCinemaUserPage(context);
                    break;

                case "admin":
                    await TransitionAdminAuthorizationPage(context);
                    break;

                case "login":
                    await TransitionafterAdminAuthorizationPage(context);
                    break;

                case "BackForWrongData":
                    await TransitionAdminAuthorizationPage(context);
                    break;
            }
        }

        private async Task TransitionCinemaUserPage(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.SendFileAsync("wwwroot/src/html/CinemaUserPage.html");
        }

        private async Task TransitionAdminAuthorizationPage(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.SendFileAsync("wwwroot/src/html/AdminAuthorizationPage.html");
        }


        private async Task TransitionafterAdminAuthorizationPage(HttpContext context)
        {
            var email = EmailAcquisition(context);
            var password = PasswordAcquisition(context);

            var adminData = SearchAdminData(roleInfo, email, password);

            if (adminData == null)
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.SendFileAsync("wwwroot/src/html/WrongDataPage.html");
            }

            else
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.SendFileAsync("wwwroot/src/html/CinemaAdminPage.html");
            }
        }
        private StringValues EmailAcquisition(HttpContext context)
        {
            var email = context.Request.Form["email"];
            return email;
        }
        private StringValues PasswordAcquisition(HttpContext context)
        {
            var password = context.Request.Form["password"];
            return password;
        }


#pragma warning disable CS8602
        private Admin? SearchAdminData(RoleInfo? roleInfo, StringValues email, StringValues password) => roleInfo.admin.FirstOrDefault(x => x.Email == email && x.Password == password);
#pragma warning restore CS8602


        private IResult NotFound() => Results.NotFound(new { message = "Данный фильм не найден" });
    }
}
