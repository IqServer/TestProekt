using Microsoft.AspNetCore.Mvc;
using models;
using services;
namespace Service.Controllers;
//апи контроллер
//[Produces("application/json")]
[ApiController]
//
[Route("api/[controller]/[action]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    readonly StudentService _studentService;
    public WeatherForecastController(ILogger<WeatherForecastController> logger, StudentService studentService)
    {
        _studentService = studentService;
        _logger = logger;
    }

    [HttpGet(Name = "GetAllStudents")]
    public List<Student> GetAllStudents(){
        var student =  _studentService.GetStudents();
        return student;
    }


    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    [HttpGet(Name = "Myget")]
    public string MyGet()
    {
        return "Это гет запрос";
    }
}
