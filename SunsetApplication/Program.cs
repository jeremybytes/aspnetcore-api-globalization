namespace SunsetApplication;

class Program
{
    static void Main(string[] args)
    {
        //45.6382,-122.7013 = Vancouver, WA, USA
        //28.4810,-81.5074 = Orlando, FL
        //28.4672,-81.4687 = Royal Pacific Hotel

        double latitude = 45.6382;
        double longitude = -122.7013;

        ISunsetServiceProvider provider = new SunsetServiceControllerProvider(latitude, longitude);
        var sunsetTomorrow = provider.GetSunset(DateTime.Now.Date);
        Console.WriteLine($"(From Controller Service) Sunset Tomorrow: {sunsetTomorrow:G}");

        provider = new SunsetServiceMinimalAPIProvider(latitude, longitude);
        sunsetTomorrow = provider.GetSunset(DateTime.Now.Date);
        Console.WriteLine($"(From Minimal API Service) Sunset Tomorrow: {sunsetTomorrow:G}");
    }
}
