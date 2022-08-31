RoleInfo roleInfo = new();
RegistrationMiddleware registrationMiddleware = new();

var builder = WebApplication.CreateBuilder(args);

registrationMiddleware.builderServicesAddAuthentication.addAuthentication(builder);
registrationMiddleware.registrationDbContext.AddDbContext(builder);

roleInfo.RoleInitialization();
builder.Services.AddAuthorization();

var webApplication = builder.Build();

webApplication.UseAuthentication();
webApplication.UseAuthorization();

webApplication.UseStaticFiles();


webApplication.Map("/", async (HttpContext context) => await registrationMiddleware.middlewareForStart.StartPage(context));

webApplication.MapPost("/", async (HttpContext context) => await registrationMiddleware.redirectToNewPage.Redirect(context, roleInfo));


webApplication.MapGet("/api/films", async (ApplicationContext db) => await registrationMiddleware.transferAllFilms.TramsferAllMovies(db));

webApplication.MapGet("/api/films/{id:int}", async (int id, ApplicationContext db) => await registrationMiddleware.transferFilm.TransferFilm(id, db));

webApplication.MapDelete("/api/films/{id:int}", async (int id, ApplicationContext db) => await registrationMiddleware.middlewareDeleteFilm.DeleteFilm(id, db));

webApplication.MapPost("/api/films", async (Film film, ApplicationContext db) => await registrationMiddleware.transferNewFilm.NewFilmAdd(film, db));

webApplication.MapPut("/api/films", async (Film filmData, ApplicationContext db) => await registrationMiddleware.middlewareChangeFilm.ChangeFilm(filmData, db));


webApplication.Run();
