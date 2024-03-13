namespace Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Place> Places => Set<Place>();
    public DbSet<UserFriendPair> Friends => Set<UserFriendPair>();
    public DbSet<PlacesFavouritesPair> FavPlaces => Set<PlacesFavouritesPair>();
}