using static Functional.FunctionsPOC;

namespace Functional;

public static class FahrenheitToCelsiusConverter
{
    //Monad example
    public static string Convert(decimal input) =>
        input.ToIdentity()
            .Bind(Subtract(32))
            .Bind(Multiply(5))
            .Bind(Divide(9))
            .Bind(x => Math.Round(x, 2))
            .Bind(x => $"{x} Celsius");       
}

public class Identity<T>
{
    public T Value { get; }

    public Identity(T value)
    {
        Value = value;
    }

    public static implicit operator Identity<T>(T @this) => @this.ToIdentity();
    public static implicit operator T(Identity<T> @this) => @this.Value;
}

public static class IdentityExtensions
{
    public static Identity<T> ToIdentity<T>(this T @this) => new Identity<T>(@this);

    public static Identity<TToType> Bind<TFromType, TToType>(this Identity<TFromType> @this,
        Func<TFromType, TToType> f) => 
            f(@this.Value).ToIdentity();
}
