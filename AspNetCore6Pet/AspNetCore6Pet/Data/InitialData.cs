namespace AspNetCore6Pet.Data
{
    public class InitialData
    {
        public List<Person> users = new List<Person>()
        {
            new() { Id = Guid.NewGuid().ToString(), Name = "Максим", Age = 24},
            new() { Id = Guid.NewGuid().ToString(), Name = "Елена", Age = 32},
            new() { Id = Guid.NewGuid().ToString(), Name = "Андрей", Age = 19},
            new() { Id = Guid.NewGuid().ToString(), Name = "Андрей", Age = 25},
            new() { Id = Guid.NewGuid().ToString(), Name = "Андрей", Age = 23}
        };
    }
}
