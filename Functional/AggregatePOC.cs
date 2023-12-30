namespace Functional;

public static class AggregatePocFunction
{
    
}

public static class AggregatePOC
{
    public static NumberPair[] NumberPairs =>
        new NumberPair[]
        {
            new NumberPair(1,3),
            new NumberPair(2,4),
            new NumberPair(3,5),
            new NumberPair(4,6),
            new NumberPair(5,7),
        };
}

public class NumberPair
{
    public int XValue { get; init; }

    public int YValue { get; init; }

    public NumberPair(int x, int y)
    {
        XValue = x; 
        YValue = y;
    }
}
