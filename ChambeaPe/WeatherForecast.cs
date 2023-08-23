namespace ChambeaPe;

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public int TemperatureK => (int)(((TemperatureF - 32) / 1.8) + 273.15);

    public string? Summary { get; set; }
    
}