# Stub application for [Issue 4133](https://github.com/ChilliCream/hotchocolate/issues/4133)

`/MyEntity.cs`
``` csharp
public class MyEntity
{
    public int Id { get; set; }
}
```

`/MyEntity.cs`
``` csharp
public class MyEntity
{
    public int Id { get; set; }
}
```

`/MyDbContext.cs`
``` csharp
public class MyDbContext : DbContext
{
    public DbSet<MyEntity> MyEntities { get; set; } = null!;

    public MyDbContext(DbContextOptions options) : base(options) { }
}
```

`/Query.cs`
``` csharp
public class Query
{
    [UseDbContext(typeof(MyDbContext))]
    [UseProjection]
    public IQueryable<MyEntity> GetMyEntities([ScopedService] MyDbContext dbContext) => dbContext.MyEntities;
}
```

`/Program.cs`
``` csharp
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureServices((webHost, services) =>
{
    services.AddPooledDbContextFactory<MyDbContext>(builder =>
    {
        builder.UseInMemoryDatabase(databaseName: "MyDatabase");
    });

    services.AddGraphQLServer()
        .AddQueryType<Query>()
        .AddTypeExtension<MyEntityTypeExtension>()
        .AddProjections();
});

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(e => e.MapGraphQL());

app.Run();
```


