using HotChocolate.Types;

namespace TypeExtensionProjectionDemo;

[ExtendObjectType(typeof(MyEntity))]
public class MyEntityTypeExtension
{
    public IEnumerable<string> GetMyList() => new List<string> { "foo", "bar" };
}
