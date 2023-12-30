namespace Functional;

public static class FunctionsPOC
{

    private static readonly Func<string, string> AddDash = x => x + "-";
    private static readonly Func<string, string> AddDollar = x => x + "$";
    private static readonly Func<string, string> AddUnderscore = x => x + "_";
    private static readonly Func<string, string> AddAnd = x => x + "&";

    public static readonly Func<string, string> AddDashDollarUnderScoreAnd
        = x => AddAnd(AddUnderscore(AddDollar(AddDash(x))));

    public static readonly Func<string, bool> HasDash = x => x.Contains('-');
    public static readonly Func<string, bool> HasDollar = x => x.Contains('$');
    public static readonly Func<string, bool> HasUnderscore = x => x.Contains('_');
    public static readonly Func<string, bool> HasAnd = x => x.Contains('&');
    public static readonly Func<string, bool> HasAt = x => x.Contains('@');

    public static bool HasAnyOfDashDollarUnderScoreAnd(string input) =>
        new[]
        {
            HasDash,
            HasDollar,
            HasUnderscore,
            HasAnd
        }.Any(x => x(input));

    public static bool HasAllOfDashDollarUnderScoreAndAt(string input) =>
        new[]
        {
            HasDash,
            HasDollar,
            HasUnderscore,
            HasAnd,
            HasAt
        }.All(x => x(input));

    public static void ValidateHasAllAndPrint(this string @this, params Func<string, bool>[] predicates)
        => Console.WriteLine(predicates.All(x => x(@this)));

    public static readonly Func<string, string> ReturnsNull = x => null;
    public static readonly Func<string, string> ReturnsDrTitle = x => "Dr. " + x;


    public static TOutput Alt<TInput, TOutput>(this TInput @this,
        Func<TInput, TOutput> f1,
        Func<TInput, TOutput> f2) => f1(@this).IfDefaultDo(f2, @this);

    private static TOutput IfDefaultDo<TInput, TOutput>(this TOutput @this,
        Func<TInput, TOutput> elseF,
        TInput input) =>
        EqualityComparer<TOutput>.Default.Equals(@this, default)
            ? elseF(input) : @this;

    private static TToType Map<TFromType, TToType>(this TFromType @this,
        Func<TFromType, TToType> f) => f(@this);

    public static TOutput Fork<TInput, TOutput>(this TInput @this,
        Func<IEnumerable<TOutput>, TOutput> joinFunc,
        params Func<TInput, TOutput>[] prongs) =>
            prongs.Select(x => x(@this)).Map(joinFunc);

    public static Func<decimal, decimal> Add(decimal x) => y => x + y;
    public static Func<decimal, decimal> Subtract(decimal x) => y => y - x;
    public static Func<decimal, decimal> Multiply(decimal x) => y => x * y;
    public static Func<decimal, decimal> Divide(decimal x) => y => y / x;
}