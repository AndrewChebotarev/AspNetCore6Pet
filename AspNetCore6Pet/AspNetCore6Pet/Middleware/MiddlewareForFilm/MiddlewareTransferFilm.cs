using AspNetCore6Pet.EntityFramework;

namespace AspNetCore6Pet.Middleware.MiddlewareForFilm
{
    public class MiddlewareTransferFilm
    {
        private SearchFilmFunction searchFilmFunction = new();
        public async Task<IResult> TransferFilm(int id, ApplicationContext db)
        {
            var film = await searchFilmFunction.SearchFilm(id, db);

            if (film == null)
                return Results.NotFound(new { message = "Данный фильм не найден" });

            return Results.Json(film);
        }

        private async Task<Film?> SearchFilm(int id, ApplicationContext db) => await db.films.FirstOrDefaultAsync(x => x.Id == id);
    }
}
