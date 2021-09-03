using Microsoft.EntityFrameworkCore;
using TypeExtensionProjectionDemo;

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
