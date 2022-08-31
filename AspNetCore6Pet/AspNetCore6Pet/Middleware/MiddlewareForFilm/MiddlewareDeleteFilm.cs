using AspNetCore6Pet.EntityFramework;

namespace AspNetCore6Pet.Middleware.MiddlewareForFilm
{
    public class MiddlewareDeleteFilm
    {
        private SearchFilmFunction searchFilmFunction = new();
        public async Task<IResult> DeleteFilm(int id, ApplicationContext db)
        {
            var film = await searchFilmFunction.SearchFilm(id, db);

            if (film == null)
                return Results.NotFound(new { message = "Данный фильм не найден" });

            db.films.Remove(film);
            await db.SaveChangesAsync();

            return Results.Json(film);
        }
    }
}
