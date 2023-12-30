namespace Functional;
public abstract class Either<T>
{
    public abstract T Value { get; }
    public static implicit operator T(Either<T> @this) => @this.Value;
}

public class Right<T> : Either<T>
{
    public override T Value { get; }

    public Right(T val)
    {
        Value = val;
    }
}

public class Left<T> : Either<T>
{
    public override T Value => default;

    public Exception Exception { get; set; }

    public Left(Exception exception)
    {
        Exception = exception;
    }
}


public static class EitherExtensions
{
    public static Either<T> ToEither<T>(this T value) => new Right<T>(value);

    public static Either<TToType> Bind<TFromType, TToType>(this Either<TFromType> @this, Func<TFromType, TToType> f)
    {
        switch (@this)
        {
            case Right<TFromType> rgt when !EqualityComparer<TFromType>.Default.Equals(rgt.Value, default):
                try 
                {
                    return f(rgt.Value).ToEither();
                }
                catch (Exception ex)
                {
                    return new Left<TToType>(ex);
                }
            case Left<TFromType> lft:
                return new Left<TToType>(lft.Exception);
            default:
                return new Left<TToType>(new Exception("Default value"));
        }
    }
}