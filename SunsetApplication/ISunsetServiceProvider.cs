
namespace SunsetApplication
{
    public interface ISunsetServiceProvider
    {
        DateTimeOffset GetSunrise(DateTime date);
        DateTimeOffset GetSunset(DateTime date);
    }
}