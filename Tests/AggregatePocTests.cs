using Functional;

namespace Tests;
public class AggregatePocTests
{
    [Fact]
    public void AggregateTest()
    {
        var (x, y) = AggregatePOC.NumberPairs.Aggregate(
            (0,0),
            (acc, curr) => (
                    acc.Item1 + curr.XValue,
                    acc.Item2 + curr.YValue
                )
            );

        x.Should().Be(15);
        y.Should().Be(25);
    }
}
