using static Functional.FunctionsPOC;

namespace Tests;

public class FunctionsPocTests
{
    [Fact]
    public void HasAnyOfDashDollarUnderScoreAndShouldBeTrue()
    {
        HasAnyOfDashDollarUnderScoreAnd(AddDashDollarUnderScoreAnd(""))
            .Should().BeTrue();
    }

    [Fact]
    public void HasAllOfDashDollarUnderScoreAndAtShouldBeFalse()
    {
        HasAllOfDashDollarUnderScoreAndAt(AddDashDollarUnderScoreAnd(""))
            .Should().BeFalse();
    }


    [Fact]
    public void AltTest()
    {
        var input = "Major Martin";
        var output = input.Alt(ReturnsNull, ReturnsDrTitle);
        output.Should().Be("Dr. Major Martin");
    }

    [Fact]
    public void ForkTest()
    {
        var input = "aaabbbcccc";
        var output = input.Fork(x => x.Sum(),
            x => x.Count(y => y == 'a'),
            x => x.Count(y => y == 'b'),
            x => x.Count(y => y == 'c'));

        Assert.Equal(10, output);
    }
}