namespace AspNetCore6Pet.Middleware
{
    public class RegistrationMiddleware
    {
        public MiddlewareTransferAllFilms transferAllFilms = new();
        public MiddlewareTransferFilm transferFilm = new();
        public MiddlewareDeleteFilm middlewareDeleteFilm = new();
        public MiddlewareTransferNewFilm transferNewFilm = new();
        public MiddlewareChangeFilm middlewareChangeFilm = new();

        public MiddlewareForStartPage middlewareForStart = new();
        public RedirectToNewPage redirectToNewPage = new();

        public BuilderServicesAddAuthentication builderServicesAddAuthentication = new();
        public RegistrationDbContext registrationDbContext = new();
    }
}
