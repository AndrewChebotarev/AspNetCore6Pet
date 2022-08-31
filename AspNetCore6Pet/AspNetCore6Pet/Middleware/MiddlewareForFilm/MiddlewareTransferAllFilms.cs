using AspNetCore6Pet.EntityFramework;

namespace AspNetCore6Pet.Middleware.MiddlewareForFilm
{
    public class MiddlewareTransferAllFilms
    {
        public async Task<List<Film>> TramsferAllMovies(ApplicationContext db) => await db.films.ToListAsync();

    }
}
