using Microsoft.AspNetCore.Mvc;

namespace LessonApi.Controlles;

[ApiController]
[Route("api/[controller]/[action]")]
public class WeatherController:Controller
{
    [HttpGet]
    public IActionResult GetHello()
    {
        return Ok("Hello word");
    }
    
    
}