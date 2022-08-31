using AspNetCore6Pet.EntityFramework;

namespace AspNetCore6Pet.Middleware.MiddlewareForFilm
{
    public class SearchFilmFunction
    {
        public async Task<Film?> SearchFilm(int id, ApplicationContext db) => await db.films.FirstOrDefaultAsync(x => x.Id == id);
    }
}
