using DemoProject.Models;
using DemoProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject;

[Route("[controller]/[action]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<IEnumerable<Car>> GetCar()
    {
        var result = await _carService.GetAsync();
        return result;
    }

    [HttpPost]
    public IActionResult CreateCar(Car car)
    {
        var result = _carService.CreatCarAsync(car);

        Task.WhenAll(result);

        return Ok("OK");
    }

    [HttpPut]
    public async Task<IActionResult> Update(Car car)
    {
        var result = await _carService.UpdateCarAsync(car);

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(Car car)
    {
        var result = await _carService.DeleteCarAsync(car);

        return Ok(result);
    }
    
    
    
    
}