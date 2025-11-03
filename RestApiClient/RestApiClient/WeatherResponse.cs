namespace RestApiClient
{
    internal class WeatherResponse
    {
        public string Name { get; set; }
        public Weather[] Weather { get; set; }
        public TempInfo Main { get; set; }
        public Wind Wind { get; set; }
    }
}
