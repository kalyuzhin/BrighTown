namespace Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Place> Places => Set<Place>();
}