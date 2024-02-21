using DemoProject.Models;

namespace DemoProject.Services;

public interface ICarService
{

    Task<List<Car>> GetAsync();
    Task<Car> CreatCarAsync(Car car);

    Task<bool> UpdateCarAsync(Car car);

    Task<bool> DeleteCarAsync(Car car);

}