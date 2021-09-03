using HotChocolate;
using HotChocolate.Data;

namespace TypeExtensionProjectionDemo;

public class Query
{
    [UseDbContext(typeof(MyDbContext))]
    [UseProjection]
    public IQueryable<MyEntity> GetMyEntities([ScopedService] MyDbContext dbContext) => dbContext.MyEntities;
}
