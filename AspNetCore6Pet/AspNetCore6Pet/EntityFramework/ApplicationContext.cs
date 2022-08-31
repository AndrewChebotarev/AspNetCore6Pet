namespace AspNetCore6Pet.EntityFramework
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Film> films { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().HasData(
                new Film { Id = 1, NameFilm = "Зеленпя миля", TicketPrice = 230 },
                new Film { Id = 2, NameFilm = "Список шиндера", TicketPrice = 225 },
                new Film { Id = 3, NameFilm = "Побег из Шоушенка", TicketPrice = 250 },
                new Film { Id = 4, NameFilm = "Форрест Гамп", TicketPrice = 210 }
                );
        }
    }
}
