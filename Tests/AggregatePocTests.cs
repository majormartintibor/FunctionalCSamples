using Functional;
using System.Collections.Immutable;
using System.Security.Cryptography;

namespace Tests;
public class AggregatePocTests
{
    private IImmutableList<int> Values = [1, 3, 6, 7];

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

    [Fact]
    public void AggregateNoSeed()
    {
        Values.Aggregate((a, b) => a + b).Should().Be(17);
    }

    [Fact]
    public void AggregateSeed()
    {
        Values.Aggregate(3, (a, b) => a + b).Should().Be(20);
    }

    [Fact]
    public void FindAndSumTwoGreatestNumbersTest()
    {
        int ProduceSum((int max, int next, int count) tuple) =>
            tuple.count == 2 ? tuple.max + tuple.next : 1;

        (int max, int next, int count) AdvanceRaw((int max, int next, int count) tuple, string item) =>
            int.TryParse(item, out int number) ? Advance(tuple, number) : tuple;

        (int max, int next, int count) Advance((int max, int next, int count) tuple, int number) => tuple switch
        {
            (_, _, 0) => (number, 0, 1),
            (var max, _, 1) when number > max => (number, max, 2),
            (var max, _, 1) => (max, number, 2),
            (var max, _, 2) when number > max => (number, max, 2),
            (var max, var next, 2) when number > next => (max, number, 2),
            _ => tuple
        };

        int FindAndSumTwoGreatestNumbers(IEnumerable<string> items) =>
            items.Aggregate((max: 0, next: 0, count: 0), AdvanceRaw, ProduceSum);

        IImmutableList<string> Items = ["3, 5", "18", "2", "8", "1"];

        FindAndSumTwoGreatestNumbers(Items).Should().Be(26);
    }
}
