using Microsoft.EntityFrameworkCore;
using TypeExtensionProjectionDemo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<MyDbContext>(b => b.UseInMemoryDatabase(databaseName: "MyDatabase"));

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddTypeExtension<MyEntityTypeExtension>()
    .AddProjections();

var app = builder.Build();

app.MapGraphQL();

app.Run();
