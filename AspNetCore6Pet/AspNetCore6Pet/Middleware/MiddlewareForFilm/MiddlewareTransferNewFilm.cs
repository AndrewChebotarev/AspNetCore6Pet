using AspNetCore6Pet.EntityFramework;

namespace AspNetCore6Pet.Middleware.MiddlewareForFilm
{
    public class MiddlewareTransferNewFilm
    {
        public async Task<Film> NewFilmAdd(Film film, ApplicationContext db)
        {
            await db.films.AddAsync(film);
            await db.SaveChangesAsync();
            return film;
        }
    }
}
