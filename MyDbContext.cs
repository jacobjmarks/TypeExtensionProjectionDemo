using Microsoft.EntityFrameworkCore;

namespace TypeExtensionProjectionDemo;

public class MyDbContext : DbContext
{
    public DbSet<MyEntity> MyEntities { get; set; } = null!;

    public MyDbContext(DbContextOptions options) : base(options) { }
}
