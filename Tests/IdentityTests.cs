using Functional;

namespace Tests;
public class IdentityTests
{
    [Fact]
    public void FahrenheitConverterTest()
    {
        FahrenheitToCelsiusConverter.Convert(100)
            .Should().Be("37.78 Celsius");
    }
}
