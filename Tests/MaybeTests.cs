using Functional;

namespace Tests;
public class MaybeTests
{
    [Fact]
    public void MaybeReturnsNothing()
    {
        var id = Guid.NewGuid();

        string result = id.ToMaybe()
            .Bind(DatabaseReturnsNull)
            .Bind(x => string.Join(' ', x, " this shouldn't be added").ToString());           

        result.Should().BeNull();
    }

    [Fact]
    public void MaybeReturnsSomething()
    {
        var id = Guid.NewGuid();

        string result = id.ToMaybe()
            .Bind(DatabaseReturnsName)
            .Bind(x => string.Join(' ', x, "the FP master").ToString());

        result.Should().Be("Martin the FP master");
    }

    private Func<Guid, string> DatabaseReturnsNull => null;

    private Func<Guid, string> DatabaseReturnsName = x => "Martin";
}
