using AspNetCore6Pet.Data;
using AspNetCore6Pet.EntityFramework;

namespace AspNetCore6Pet.Middleware.MiddlewareForFilm
{
    public class MiddlewareChangeFilm
    {
        private SearchFilmFunction searchFilmFunction = new();
        public async Task<IResult> ChangeFilm(Film filmData, ApplicationContext db)
        {
            var film = await searchFilmFunction.SearchFilm(filmData.Id, db);

            if (film == null)
                return Results.NotFound(new { message = "Данный фильм не найден" });

            FilmDataChange(film, filmData);

            await db.SaveChangesAsync();

            return Results.Json(film);
        }

        private void FilmDataChange(Film film, Film filmData)
        {
            film.TicketPrice = filmData.TicketPrice;
            film.NameFilm = filmData.NameFilm;
        }
    }
}
