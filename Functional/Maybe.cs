namespace Functional;
public abstract class Maybe<T>
{
    public abstract T Value { get; }
    public static implicit operator T(Maybe<T> @this) => @this.Value;
}

public class Just<T> : Maybe<T>
{
    public override T Value { get; }

    public Just(T value)
    {
        Value = value;
    }
}

public class Nothing<T> : Maybe<T>
{
    public override T Value => default;
}

public static class MaybeExtensions
{
    public static Maybe<T> ToMaybe<T>(this T value) => new Just<T>(value);

    public static Maybe<TToType> Bind<TFromType, TToType>(
        this Maybe<TFromType> @this, Func<TFromType, TToType> f)
    {
        switch(@this)
        {
            case Just<TFromType> sth when !EqualityComparer<TFromType>.Default.Equals(sth.Value, default):
                try
                {
                    return f(sth).ToMaybe();
                }
                catch(Exception)
                {
                    return new Nothing<TToType>();
                }
            default:
                return new Nothing<TToType>();
        }
    }
}