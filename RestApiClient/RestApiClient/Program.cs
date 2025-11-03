using Newtonsoft.Json;

namespace RestApiClient
{
    internal class Program
    {
        private const string ApiKey = "d26f056868fcb6af91918424f3ffecf4"; 
        private const string openWeatherMapUrl = "https://api.openweathermap.org/data/2.5/weather";


        static void Main(string[] args)
        {
            Console.WriteLine("Enter city name to display weather information for: ");
            var city = Console.ReadLine();

            if(string.IsNullOrEmpty(city))
            {
                Console.WriteLine("The city name is required");
                return;
            }

            TestRestApi(city);
            Console.ReadKey();
        }

        private static async void TestRestApi(string city)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $"{openWeatherMapUrl}?q={city}&appid={ApiKey}&units=metric";

                    HttpResponseMessage response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    WeatherResponse weatherData = JsonConvert.DeserializeObject<WeatherResponse>(responseBody);

                    Console.WriteLine($"\n\nCity: {weatherData.Name}");
                    Console.WriteLine($"Temperature: {weatherData.Main.Temp}");
                    Console.WriteLine($"Humidity: {weatherData.Main.Humidity}");
                    Console.WriteLine($"Wind Speed: {weatherData.Wind.Speed}");
                    Console.WriteLine($"Deg: {weatherData.Wind.Deg}");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request Error: {e.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An unexpected error occurred: {e.Message}");
                }
            }
        }
    }
}
